using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompressAlgorithmLib
{
    public class LZWCompressor
    {
        public System.Threading.Thread SizeThread;
        private const int bitsLimit = 14; //maimxum bits allowed to read
        private const int bitHash = bitsLimit - 8; //hash bit to use with the hasing algorithm to find correct index
        private const int valueMax = (1 << bitsLimit) - 1; //max value allowed based on max bits
        private const int codeMax = valueMax - 1; //max code possible
        private const int arrLimit = 18041; //must be bigger than the maximum allowed by maxbits and prime

        private int[] codeArr = new int[arrLimit]; //code table
        private int[] prefixArr = new int[arrLimit]; //prefix table
        private int[] symbolArr = new int[arrLimit]; //character table

        private byte buf; //bit buffer to temporarily store bytes read from the files
        private int counter; //counter for knowing how many bits are in the bit buffer

        private void init() 
        {
            buf = 0;
            counter = 0;
        }

        public bool compress(string infile, string outfile)
        {
            Stream inputDataStream = null;
            Stream outputDataStream = null;
            Monitor.Enter(this);
            try
            {
                init();
                inputDataStream = new FileStream(infile, FileMode.Open);
                outputDataStream = new FileStream(outfile, FileMode.Create);
                int nextCode = 256;
                int symbol = 0, code = 0, index = 0;

                for (int i = 0; i < arrLimit; i++) 
                    codeArr[i] = -1;

                code = inputDataStream.ReadByte(); 

                while ((symbol = inputDataStream.ReadByte()) != -1) 
                {
                    index = findMatch(code, symbol); 

                    if (codeArr[index] != -1) 
                        code = codeArr[index];
                    else 
                    {
                        if (nextCode <= codeMax)
                        {
                            codeArr[index] = nextCode++; 
                            prefixArr[index] = code;
                            symbolArr[index] = (byte)symbol;
                        }
                        writeCode(outputDataStream, code); 
                        code = symbol;
                    }
                }

                writeCode(outputDataStream, code); 
                writeCode(outputDataStream, valueMax); 
                writeCode(outputDataStream, 0); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                if (outputDataStream != null)
                    outputDataStream.Close();
                File.Delete(outfile);
                return false;
            }
            finally
            {
                Monitor.Exit(this);
                if (inputDataStream != null)
                    inputDataStream.Close();
                if (outputDataStream != null)
                    outputDataStream.Close();
            }
            SizeThread.Start();
            return true;
        }

        private int findMatch(int prefix, int symbol)
        {
            int index = 0, offset = 0;

            index = (symbol << bitHash) ^ prefix;

            offset = (index == 0) ? 1 : arrLimit - index;

            while (true)
            {
                if (codeArr[index] == -1)
                    return index;

                if (prefixArr[index] == prefix && symbolArr[index] == symbol)
                    return index;

                index -= offset;
                if (index < 0)
                    index += arrLimit;
            }
        }

        private void writeCode(Stream outputDataStream, int code)
        {
            buf |= (byte)(code << (32 - bitsLimit - counter)); 
            counter += bitsLimit;

            while (counter >= 8)
            {
                int temp = (byte)((buf >> 24) & 255);
                outputDataStream.WriteByte((byte)((buf >> 24) & 255));
                buf <<= 8;
                counter -= 8;
            }
        }

        public bool decompress(string infile, string outfile)
        {
            Stream inputDataStream = null;
            Stream outputDataStream = null;
            Monitor.Enter(this);
            try
            {
                init();
                inputDataStream = new FileStream(infile, FileMode.Open);
                outputDataStream = new FileStream(outfile, FileMode.Create);
                int nextCode = 256;
                int newCode, previousCode;
                byte symbol;
                int code, counter;
                byte[] decodeArr = new byte[arrLimit];

                previousCode = readCode(inputDataStream);
                symbol = (byte)previousCode;
                outputDataStream.WriteByte((byte)previousCode); 

                newCode = readCode(inputDataStream);

                while (newCode != valueMax)
                {
                    if (newCode >= nextCode)
                    { 
                        decodeArr[0] = symbol;
                        counter = 1;
                        code = previousCode;
                    }
                    else
                    {
                        counter = 0;
                        code = newCode;
                    }

                    while (code > 255)
                    {
                        decodeArr[counter] = (byte)symbolArr[code];
                        ++counter;
                        if (counter >= codeMax)
                            throw new Exception("counter exceeded max code");
                        code = prefixArr[code];
                    }

                    decodeArr[counter] = (byte)code;
                    symbol = decodeArr[counter];

                    while (counter >= 0) 
                    {
                        outputDataStream.WriteByte(decodeArr[counter]);
                        --counter;
                    }

                    if (nextCode <= codeMax) 
                    {
                        prefixArr[nextCode] = previousCode;
                        symbolArr[nextCode] = symbol;
                        ++nextCode;
                    }

                    previousCode = newCode;

                    newCode = readCode(inputDataStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                if (outputDataStream != null)
                    outputDataStream.Close();
                File.Delete(outfile);
                return false;
            }
            finally
            {
                Monitor.Exit(this);
                if (inputDataStream != null)
                    inputDataStream.Close();
                if (outputDataStream != null)
                    outputDataStream.Close();
            }

            return true;
        }

        private int readCode(Stream inputDataStream)
        {
            uint returnCode;

            while (counter <= 24)
            {
                buf |= (byte)(inputDataStream.ReadByte() << (24 - counter));
                counter += 8;
            }

            returnCode = (uint)buf >> (32 - bitsLimit); 
            buf <<= bitsLimit;
            counter -= bitsLimit;

            int temp = (int)returnCode;
            return temp;
        }


    }
}
