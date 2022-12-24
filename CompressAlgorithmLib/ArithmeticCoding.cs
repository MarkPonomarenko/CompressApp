using System;
using System.IO;
using System.Threading;

namespace CompressAlgorithmLib
{
    public class ArithmeticCoding
    {
        public System.Threading.Thread SizeThread;
        int counter = 0;
        const int registerSize = 16; //size of register with form E[A,B,C,D]X
        const int maxRegisterValue = (int)(((long)1 << registerSize) - 1); //max int value of 16-bit register
        const int registerQuarta = (maxRegisterValue / 4 + 1); //first 1/4 part of register
        const int registerHalf = (2 * registerQuarta);  //half of register
        const int registerThreeQuartas = (3 * registerQuarta); //3/4 part of register
        const int maxCharValue = byte.MaxValue + 1;
        const int symbolEOF = maxCharValue + 1; //defining end of file symbol
        const int totalSymbolsCount = maxCharValue + 1; //total num of symbol program going to use
        const int freqLimit = 16383;  //0x3fff hex value
        public int[] indexChar = new int[totalSymbolsCount]; //relation from index to char
        public int[] charIndex = new int[maxCharValue]; //relation from char to index
        public int[] freqKey = new int[totalSymbolsCount + 1]; //contains chars
        public int[] freqValue = new int[totalSymbolsCount + 1]; //contains frequencies of chars from freqKey array
        public static long low, high; //range of char code
        public static long value; //code
        public static long followingBits; //bits to follow
        public static int buf; //buffer for calculations
        public static int waitingBits; //bits waiting to be processed
        public static int garbageBits; //bits going to trunc
        FileStream inputDataStream; //stream with input file data
        FileStream outputDataStream; //stream with outputfile

        public void initDataMapping()
        {
            int i;
            for (i = 0; i < maxCharValue; i++)
            {
                charIndex[i] = i + 1;
                indexChar[i + 1] = i;
            }
            for (i = 0; i <= totalSymbolsCount; i++)
            {
                freqValue[i] = 1;
                freqKey[i] = totalSymbolsCount - i;
            }
            freqValue[0] = 0;
        }

        void updateMappedData(int symbol)
        {
            int i;
            int ch_i, ch_symbol;
            int cum;
            if (freqKey[0] == freqLimit)
            {
                cum = 0;
                for (i = totalSymbolsCount; i >= 0; i--
                )
                {
                    freqValue[i] = (freqValue[i] + 1) / 2;
                    freqKey[i] = cum;
                    cum += freqValue[i];
                }
            }
            for (i = symbol; freqValue[i] == freqValue[i - 1]; i--) ;
            if (i < symbol)
            {
                ch_i = indexChar[i];
                ch_symbol = indexChar[symbol];
                indexChar[i] = ch_symbol;
                indexChar[symbol] = ch_i;
                charIndex[ch_i] = symbol;
                charIndex[ch_symbol] = i;
            }
            freqValue[i] += 1;
            while (i > 0)
            {
                i -= 1;
                freqKey[i] += 1;
            }
        }

        void initBitsReading()
        {
            waitingBits = 0;
            garbageBits = 0;
        }

        int readBitsOfChar()
        {
            int t;
            if (waitingBits == 0)
            {
                buf = inputDataStream.ReadByte();
                if (buf == -1)
                {
                    garbageBits += 1;
                    if (garbageBits > registerSize - 2)
                    {
                        throw new ArithmeticException("garbage bits overflow");
                    }
                }
                waitingBits = 8;
            }
            t = buf & 1;
            buf >>= 1;
            waitingBits -= 1;
            return t;
        }

        public void initBitsWriting()
        {
            buf = 0;
            waitingBits = 8;
        }
        public void writeBitToOutStream(int bit)
        {
            buf >>= 1;
            if (bit == 1)
                buf |= 0x80;
            waitingBits -= 1;
            if (waitingBits == 0)
            {
                outputDataStream.WriteByte((byte)buf);
                waitingBits = 8;
            }
        }

        public void finishBitsWriting()
        {
            outputDataStream.WriteByte((byte)(buf >> waitingBits));
        }

        public void writeBitWithFollowing(int bit)
        {
            writeBitToOutStream(bit);
            while (followingBits > 0)
            {
                writeBitToOutStream(~bit + 2);
                followingBits--;
            }
        }

        public void initEncoding()
        {
            low = 0L;
            high = maxRegisterValue;
            followingBits = 0L;
        }
        public void finishEncoding()
        {
            followingBits++;
            if (low < registerQuarta)
                writeBitWithFollowing(0);
            else
                writeBitWithFollowing(1);
            counter += 20;
        }
        void initDecoding()
        {
            int i;
            int a;
            value = 0L;
            for (i = 1; i <= registerSize; i++)
            {
                a = readBitsOfChar();
                value = 2 * value + a;
            }
            low = 0L;
            high = maxRegisterValue;
        }

        public void encodeSymbol(int symbol)
        {
            long range;
            range = (long)(high - low) + 1;
            high = low + (range * freqKey[symbol - 1]) / freqKey[0] - 1;
            low = low + (range * freqKey[symbol]) / freqKey[0];
            for (; ; )
            {
                if (high < registerHalf)
                    writeBitWithFollowing(0);
                else if (low >= registerHalf)
                {
                    writeBitWithFollowing(1);
                    low -= registerHalf;
                    high -= registerHalf;
                }
                else if (low >= registerQuarta && high < registerThreeQuartas)
                {
                    followingBits += 1;
                    low -= registerQuarta;
                    high -= registerQuarta;
                }
                else
                    break;
                low = 2 * low;
                high = 2 * high + 1;
            }
        }

        public int decodeSymbol()
        {
            long range;
            int cum;
            int symbol;
            int a;
            range = (long)(high - low) + 1;
            cum = (int)((((long)(value - low) + 1) * freqKey[0] - 1) / range);
            for (symbol = 1; freqKey[symbol] > cum; symbol++) ;
            high = low + (range * freqKey[symbol - 1]) / freqKey[0] - 1;
            low = low + (range * freqKey[symbol]) / freqKey[0];
            for (; ; )
            {
                if (high < registerHalf) { }
                else if (low >= registerHalf)
                {
                    value -= registerHalf;
                    low -= registerHalf;
                    high -= registerHalf;
                }
                else if (low >= registerQuarta && high < registerThreeQuartas)
                {
                    value -= registerQuarta;
                    low -= registerQuarta;
                    high -= registerQuarta;
                }
                else
                    break;
                low = 2 * low;
                high = 2 * high + 1;
                a = readBitsOfChar();
                value = 2 * value + a;
            }
            return symbol;
        }

        public void encodeFile(string infile, string outfile)
        {
            Monitor.Enter(this);
            {
                try
                {
                    int ch, symbol;
                    try
                    {
                        outputDataStream = new FileStream(outfile, FileMode.Create);
                        inputDataStream = new FileStream(infile, FileMode.Open);
                    }
                    catch (Exception exc)
                    {
                        return;
                    }
                    initDataMapping();
                    initBitsWriting();
                    initEncoding();
                    for (; ; )
                    {
                        try
                        {
                            ch = inputDataStream.ReadByte();
                        }
                        catch (Exception exc)
                        {
                            return;
                        }
                        if (ch == -1)
                            break;
                        symbol = charIndex[ch];
                        encodeSymbol(symbol);
                        updateMappedData(symbol);
                    }
                    encodeSymbol(symbolEOF);
                    finishEncoding();
                    finishBitsWriting();
                    outputDataStream.Close();
                    inputDataStream.Close();
                }
                finally
                {
                    Monitor.Exit(this);
                }
            }
            SizeThread.Start();
        }

        public void decodeFile(string infile, string outfile)
        {
            Monitor.Enter(this);
            {
                try
                {
                    int ch, symbol;
                    try
                    {
                        outputDataStream = new FileStream(outfile, FileMode.Create);
                        inputDataStream = new FileStream(infile, FileMode.Open);
                    }
                    catch (Exception exc)
                    {
                        return;
                    }
                    initDataMapping();
                    initBitsReading();
                    initDecoding();
                    for (; ; )
                    {
                        symbol = decodeSymbol();
                        if (symbol == symbolEOF)
                            break;
                        ch = indexChar[symbol];
                        outputDataStream.WriteByte((byte)ch);
                        updateMappedData(symbol);
                    }
                    outputDataStream.Close();
                    inputDataStream.Close();
                }
                finally
                {
                    Monitor.Exit(this);
                }
            }
        }

    }
}
