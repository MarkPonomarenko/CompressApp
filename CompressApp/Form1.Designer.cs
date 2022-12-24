
namespace CompressApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputFileTextBox = new System.Windows.Forms.TextBox();
            this.beforeCompressKb = new System.Windows.Forms.TextBox();
            this.afterCompressKb = new System.Windows.Forms.TextBox();
            this.kbDiff = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.outputFileTextBox = new System.Windows.Forms.TextBox();
            this.compressButton = new System.Windows.Forms.Button();
            this.decompressButton = new System.Windows.Forms.Button();
            this.inputFilePickButton = new System.Windows.Forms.Button();
            this.outputFilePickButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.swapButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grouper = new System.Windows.Forms.GroupBox();
            this.percentDiff = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mbDiff = new System.Windows.Forms.TextBox();
            this.afterCompressMb = new System.Windows.Forms.TextBox();
            this.beforeCompressMb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.arithmeticAlgButton = new System.Windows.Forms.RadioButton();
            this.lzwAlgButton = new System.Windows.Forms.RadioButton();
            this.algorithmsBox = new System.Windows.Forms.GroupBox();
            this.grouper.SuspendLayout();
            this.algorithmsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputFileTextBox
            // 
            this.inputFileTextBox.Location = new System.Drawing.Point(95, 44);
            this.inputFileTextBox.Name = "inputFileTextBox";
            this.inputFileTextBox.Size = new System.Drawing.Size(353, 22);
            this.inputFileTextBox.TabIndex = 0;
            this.inputFileTextBox.Text = "Виберіть або вставте шлях";
            // 
            // beforeCompressKb
            // 
            this.beforeCompressKb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.beforeCompressKb.Location = new System.Drawing.Point(187, 38);
            this.beforeCompressKb.Name = "beforeCompressKb";
            this.beforeCompressKb.ReadOnly = true;
            this.beforeCompressKb.Size = new System.Drawing.Size(106, 15);
            this.beforeCompressKb.TabIndex = 3;
            // 
            // afterCompressKb
            // 
            this.afterCompressKb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.afterCompressKb.Location = new System.Drawing.Point(189, 59);
            this.afterCompressKb.Name = "afterCompressKb";
            this.afterCompressKb.ReadOnly = true;
            this.afterCompressKb.Size = new System.Drawing.Size(104, 15);
            this.afterCompressKb.TabIndex = 4;
            // 
            // kbDiff
            // 
            this.kbDiff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kbDiff.Location = new System.Drawing.Point(187, 80);
            this.kbDiff.Name = "kbDiff";
            this.kbDiff.ReadOnly = true;
            this.kbDiff.Size = new System.Drawing.Size(106, 15);
            this.kbDiff.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // outputFileTextBox
            // 
            this.outputFileTextBox.Location = new System.Drawing.Point(94, 112);
            this.outputFileTextBox.Name = "outputFileTextBox";
            this.outputFileTextBox.Size = new System.Drawing.Size(353, 22);
            this.outputFileTextBox.TabIndex = 6;
            this.outputFileTextBox.Text = "Виберіть або вставте шлях";
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(155, 162);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(102, 26);
            this.compressButton.TabIndex = 8;
            this.compressButton.Text = "Стиснути";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // decompressButton
            // 
            this.decompressButton.Location = new System.Drawing.Point(298, 162);
            this.decompressButton.Name = "decompressButton";
            this.decompressButton.Size = new System.Drawing.Size(102, 26);
            this.decompressButton.TabIndex = 9;
            this.decompressButton.Text = "Розтиснути";
            this.decompressButton.UseVisualStyleBackColor = true;
            this.decompressButton.Click += new System.EventHandler(this.decompressButton_Click);
            // 
            // inputFilePickButton
            // 
            this.inputFilePickButton.Location = new System.Drawing.Point(454, 44);
            this.inputFilePickButton.Name = "inputFilePickButton";
            this.inputFilePickButton.Size = new System.Drawing.Size(30, 22);
            this.inputFilePickButton.TabIndex = 10;
            this.inputFilePickButton.Text = "...";
            this.inputFilePickButton.UseVisualStyleBackColor = true;
            this.inputFilePickButton.Click += new System.EventHandler(this.inputFilePickButton_Click);
            // 
            // outputFilePickButton
            // 
            this.outputFilePickButton.Location = new System.Drawing.Point(453, 112);
            this.outputFilePickButton.Name = "outputFilePickButton";
            this.outputFilePickButton.Size = new System.Drawing.Size(30, 22);
            this.outputFilePickButton.TabIndex = 11;
            this.outputFilePickButton.Text = "...";
            this.outputFilePickButton.UseVisualStyleBackColor = true;
            this.outputFilePickButton.Click += new System.EventHandler(this.outputFilePickButton_Click);
            // 
            // swapButton
            // 
            this.swapButton.BackColor = System.Drawing.Color.Transparent;
            this.swapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swapButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.swapButton.FlatAppearance.BorderSize = 0;
            this.swapButton.Image = ((System.Drawing.Image)(resources.GetObject("swapButton.Image")));
            this.swapButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.swapButton.Location = new System.Drawing.Point(77, 43);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(17, 91);
            this.swapButton.TabIndex = 12;
            this.swapButton.UseVisualStyleBackColor = false;
            this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Шлях до файлу що буде оброблено";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Шлях куди зберегти результат";
            // 
            // grouper
            // 
            this.grouper.Controls.Add(this.percentDiff);
            this.grouper.Controls.Add(this.label12);
            this.grouper.Controls.Add(this.label11);
            this.grouper.Controls.Add(this.label10);
            this.grouper.Controls.Add(this.label9);
            this.grouper.Controls.Add(this.label8);
            this.grouper.Controls.Add(this.label7);
            this.grouper.Controls.Add(this.mbDiff);
            this.grouper.Controls.Add(this.afterCompressMb);
            this.grouper.Controls.Add(this.beforeCompressMb);
            this.grouper.Controls.Add(this.label6);
            this.grouper.Controls.Add(this.label5);
            this.grouper.Controls.Add(this.label4);
            this.grouper.Controls.Add(this.label3);
            this.grouper.Controls.Add(this.kbDiff);
            this.grouper.Controls.Add(this.afterCompressKb);
            this.grouper.Controls.Add(this.beforeCompressKb);
            this.grouper.Location = new System.Drawing.Point(32, 364);
            this.grouper.Name = "grouper";
            this.grouper.Size = new System.Drawing.Size(493, 155);
            this.grouper.TabIndex = 15;
            this.grouper.TabStop = false;
            this.grouper.Text = "Результати";
            // 
            // percentDiff
            // 
            this.percentDiff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.percentDiff.Location = new System.Drawing.Point(155, 106);
            this.percentDiff.Name = "percentDiff";
            this.percentDiff.ReadOnly = true;
            this.percentDiff.Size = new System.Drawing.Size(87, 15);
            this.percentDiff.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(311, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Mb:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(311, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "Mb:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Mb:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Kb:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Kb:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Kb:";
            // 
            // mbDiff
            // 
            this.mbDiff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mbDiff.Location = new System.Drawing.Point(348, 80);
            this.mbDiff.Name = "mbDiff";
            this.mbDiff.ReadOnly = true;
            this.mbDiff.Size = new System.Drawing.Size(116, 15);
            this.mbDiff.TabIndex = 12;
            // 
            // afterCompressMb
            // 
            this.afterCompressMb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.afterCompressMb.Location = new System.Drawing.Point(348, 59);
            this.afterCompressMb.Name = "afterCompressMb";
            this.afterCompressMb.ReadOnly = true;
            this.afterCompressMb.Size = new System.Drawing.Size(116, 15);
            this.afterCompressMb.TabIndex = 11;
            // 
            // beforeCompressMb
            // 
            this.beforeCompressMb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.beforeCompressMb.Location = new System.Drawing.Point(348, 38);
            this.beforeCompressMb.Name = "beforeCompressMb";
            this.beforeCompressMb.ReadOnly = true;
            this.beforeCompressMb.Size = new System.Drawing.Size(116, 15);
            this.beforeCompressMb.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Коефіцієнт:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Різниця:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Після стиснення:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "До стиснення:";
            // 
            // arithmeticAlgButton
            // 
            this.arithmeticAlgButton.AutoSize = true;
            this.arithmeticAlgButton.Checked = true;
            this.arithmeticAlgButton.Location = new System.Drawing.Point(32, 30);
            this.arithmeticAlgButton.Name = "arithmeticAlgButton";
            this.arithmeticAlgButton.Size = new System.Drawing.Size(135, 21);
            this.arithmeticAlgButton.TabIndex = 16;
            this.arithmeticAlgButton.TabStop = true;
            this.arithmeticAlgButton.Text = "ArithmeticCoding";
            this.arithmeticAlgButton.UseVisualStyleBackColor = true;
            this.arithmeticAlgButton.CheckedChanged += new System.EventHandler(this.arithmetic_CheckedChanged);
            // 
            // lzwAlgButton
            // 
            this.lzwAlgButton.AutoSize = true;
            this.lzwAlgButton.Location = new System.Drawing.Point(192, 30);
            this.lzwAlgButton.Name = "lzwAlgButton";
            this.lzwAlgButton.Size = new System.Drawing.Size(59, 21);
            this.lzwAlgButton.TabIndex = 17;
            this.lzwAlgButton.Text = "LZW";
            this.lzwAlgButton.UseVisualStyleBackColor = true;
            this.lzwAlgButton.CheckedChanged += new System.EventHandler(this.lzw_CheckedChanged);
            // 
            // algorithmsBox
            // 
            this.algorithmsBox.Controls.Add(this.lzwAlgButton);
            this.algorithmsBox.Controls.Add(this.arithmeticAlgButton);
            this.algorithmsBox.Location = new System.Drawing.Point(123, 226);
            this.algorithmsBox.Name = "algorithmsBox";
            this.algorithmsBox.Size = new System.Drawing.Size(303, 85);
            this.algorithmsBox.TabIndex = 18;
            this.algorithmsBox.TabStop = false;
            this.algorithmsBox.Text = "Алгоритм";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 567);
            this.Controls.Add(this.algorithmsBox);
            this.Controls.Add(this.grouper);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.swapButton);
            this.Controls.Add(this.outputFilePickButton);
            this.Controls.Add(this.inputFilePickButton);
            this.Controls.Add(this.decompressButton);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.outputFileTextBox);
            this.Controls.Add(this.inputFileTextBox);
            this.Name = "Form1";
            this.Text = "Compressor";
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.algorithmsBox.ResumeLayout(false);
            this.algorithmsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.TextBox beforeCompressKb;
        private System.Windows.Forms.TextBox afterCompressKb;
        private System.Windows.Forms.TextBox kbDiff;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox outputFileTextBox;
        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Button decompressButton;
        private System.Windows.Forms.Button inputFilePickButton;
        private System.Windows.Forms.Button outputFilePickButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grouper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox afterCompressMb;
        private System.Windows.Forms.TextBox beforeCompressMb;
        private System.Windows.Forms.TextBox mbDiff;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox percentDiff;
        private System.Windows.Forms.RadioButton arithmeticAlgButton;
        private System.Windows.Forms.RadioButton lzwAlgButton;
        private System.Windows.Forms.GroupBox algorithmsBox;
    }
}

