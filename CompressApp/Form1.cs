using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CompressAlgorithmLib;

namespace CompressApp
{
    public partial class Form1 : Form
    {
        //runtime importing win32 methods for file handling
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetFileSizeEx(IntPtr hFile, out long lpFileSize);
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateFile(string lpFileName,
                                         [MarshalAs(UnmanagedType.U4)] FileAccess dwDesiredAccess,
                                         [MarshalAs(UnmanagedType.U4)] FileShare dwShareMode,
                                         IntPtr lpSecurityAttributes,
                                         [MarshalAs(UnmanagedType.U4)] FileMode dwCreationDisposition,
                                         [MarshalAs(UnmanagedType.U4)] FileAttributes dwFlagsAndAttributes,
                                         IntPtr hTemplateFile);
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int CloseHandle(IntPtr hObject);
        //------------------end import------------

        private static ArithmeticCoding arithCompressor = new ArithmeticCoding();
        private static LZWCompressor lzwCompressor = new LZWCompressor();
        RadioButton selectedAlgorithmButton;

        public Form1()
        {
            InitializeComponent();
        }
        private void inputFilePickButton_Click(object sender, EventArgs e)
        {
            beforeCompressKb.Text = "";
            afterCompressKb.Text = "";
            kbDiff.Text = "";
            openFileDialog1.InitialDirectory = "";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Test result.
            {
                inputFileTextBox.Text = openFileDialog1.FileName;
                string extension = inputFileTextBox.Text.Split('\\').Last().Split('.').Last();
                string[] sub = inputFileTextBox.Text.Split('\\');
                if (extension[0] == 'c')
                    outputFileTextBox.Text = "C:\\" + sub.Last().Split('.').First() + "." + sub.Last().Split('.').Last().Remove(0, 1);
                else
                    outputFileTextBox.Text = "C:\\" + sub.Last().Split('.').First() + ".c" + sub.Last().Split('.').Last();
                IntPtr handle = CreateFile(inputFileTextBox.Text, FileAccess.Read, FileShare.Read, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
                long fileSize;
                GetFileSizeEx(handle, out fileSize);
                CloseHandle(handle);
                double Size = (double)fileSize / 1024;
                beforeCompressKb.Text = Math.Round(Size, 2).ToString();
                beforeCompressMb.Text = Math.Round(Size/1000, 2).ToString();

            }
            else
                MessageBox.Show("Error: can't read file");
        }
        private void outputFilePickButton_Click(object sender, EventArgs e)
        {
            afterCompressKb.Text = "";
            kbDiff.Text = "";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string[] sub = inputFileTextBox.Text.Split('\\');
            string extension = inputFileTextBox.Text.Split('\\').Last().Split('.').Last();
            if (result == DialogResult.OK)
            {
                if (extension[0] == 'c')
                    outputFileTextBox.Text = folderBrowserDialog1.SelectedPath + "\\" + sub.Last().Split('.').First() + "." + sub.Last().Split('.').Last().Remove(0, 1);
                else
                    outputFileTextBox.Text = folderBrowserDialog1.SelectedPath + "\\" + sub.Last().Split('.').First() + ".c" + sub.Last().Split('.').Last();
            }
            else
                MessageBox.Show("Error: can't save file");
        }
        private void compressButton_Click(object sender, EventArgs e)
        {
           
            compressButton.Enabled = false;
            decompressButton.Enabled = false;

            if (selectedAlgorithmButton == arithmeticAlgButton)
            {
                System.Threading.Thread EncodeThread = new System.Threading.Thread( () =>
                { arithCompressor.encodeFile(inputFileTextBox.Text, outputFileTextBox.Text); });
                EncodeThread.Priority = ThreadPriority.Highest;
                EncodeThread.Start();
                arithCompressor.SizeThread = new System.Threading.Thread( () => { getFilesSize(); });
                arithCompressor.SizeThread.Priority = ThreadPriority.BelowNormal;
            } else
            {
                System.Threading.Thread EncodeThread = new System.Threading.Thread( () =>
                { lzwCompressor.compress(inputFileTextBox.Text, outputFileTextBox.Text); });
                EncodeThread.Priority = ThreadPriority.Highest;
                EncodeThread.Start();
                lzwCompressor.SizeThread = new System.Threading.Thread( () => { getFilesSize(); });
                lzwCompressor.SizeThread.Priority = ThreadPriority.BelowNormal;
            }

            compressButton.Enabled = true;
            decompressButton.Enabled = true;
        }
        private void decompressButton_Click(object sender, EventArgs e)
        {
            beforeCompressKb.Text = "";
            afterCompressKb.Text = "";
            kbDiff.Text = "";
            if (selectedAlgorithmButton == arithmeticAlgButton)
            {
                System.Threading.Thread DecodeThread = new System.Threading.Thread( () =>
                { arithCompressor.decodeFile(inputFileTextBox.Text, outputFileTextBox.Text); });
                DecodeThread.Priority = ThreadPriority.Highest;
                DecodeThread.Start();
            } else
            {
                System.Threading.Thread DecodeThread = new System.Threading.Thread( () =>
                { lzwCompressor.decompress(inputFileTextBox.Text, outputFileTextBox.Text); });
                DecodeThread.Priority = ThreadPriority.Highest;
                DecodeThread.Start();
            }

        }

        public void getFilesSize()
        {
            double fileSize1 = Convert.ToDouble(beforeCompressKb.Text);
            IntPtr handle = CreateFile(outputFileTextBox.Text, FileAccess.Read, FileShare.Read, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
            long fileSize2;
            GetFileSizeEx(handle, out fileSize2);
            double Size2 = (double)fileSize2 / 1024;
            CloseHandle(handle);
            afterCompressKb.Invoke((MethodInvoker)delegate { afterCompressKb.Text = Math.Round(Size2, 2).ToString(); afterCompressMb.Text = Math.Round(Size2/1000, 2).ToString(); });
            String Size3 = afterCompressKb.Text;
            double fileSize4 = Convert.ToDouble(Size3);
            double fileSize3;
            fileSize3 = fileSize1 - fileSize4;
            kbDiff.Invoke((MethodInvoker)delegate { kbDiff.Text = Math.Round(fileSize3, 2).ToString(); mbDiff.Text = Math.Round(fileSize3 / 1000, 2).ToString(); });
            percentDiff.Invoke((MethodInvoker)delegate { percentDiff.Text = 
                Math.Round(Convert.ToDouble(afterCompressKb.Text) / Convert.ToDouble(beforeCompressKb.Text) * 100,2).ToString() + "%"; });
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            string tmp = inputFileTextBox.Text;
            inputFileTextBox.Invoke((MethodInvoker)delegate { inputFileTextBox.Text = outputFileTextBox.Text; outputFileTextBox.Text = tmp; });
        }

        private void arithmetic_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                selectedAlgorithmButton = rb;
                afterCompressKb.Text = "";
                afterCompressMb.Text = "";
                kbDiff.Text = "";
                mbDiff.Text = "";
                percentDiff.Text = "";
            }
        }

        private void lzw_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                selectedAlgorithmButton = rb;
                afterCompressKb.Text = "";
                afterCompressMb.Text = "";
                kbDiff.Text = "";
                mbDiff.Text = "";
                percentDiff.Text = "";
            }
        }
    }
}
