namespace Wavelet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalImagePb = new System.Windows.Forms.PictureBox();
            this.waveletImagePb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.origImageLoadBtn = new System.Windows.Forms.Button();
            this.scaleTb = new System.Windows.Forms.TextBox();
            this.offsetTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.waveletLoadBtn = new System.Windows.Forms.Button();
            this.waveletSaveBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yTb = new System.Windows.Forms.TextBox();
            this.xTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.minLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveletImagePb)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalImagePb
            // 
            this.originalImagePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImagePb.Location = new System.Drawing.Point(12, 50);
            this.originalImagePb.Name = "originalImagePb";
            this.originalImagePb.Size = new System.Drawing.Size(512, 512);
            this.originalImagePb.TabIndex = 1;
            this.originalImagePb.TabStop = false;
            // 
            // waveletImagePb
            // 
            this.waveletImagePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveletImagePb.Location = new System.Drawing.Point(558, 50);
            this.waveletImagePb.Name = "waveletImagePb";
            this.waveletImagePb.Size = new System.Drawing.Size(512, 512);
            this.waveletImagePb.TabIndex = 2;
            this.waveletImagePb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Original Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(552, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wavelet Image";
            // 
            // origImageLoadBtn
            // 
            this.origImageLoadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origImageLoadBtn.Location = new System.Drawing.Point(12, 581);
            this.origImageLoadBtn.Name = "origImageLoadBtn";
            this.origImageLoadBtn.Size = new System.Drawing.Size(66, 32);
            this.origImageLoadBtn.TabIndex = 5;
            this.origImageLoadBtn.Text = "Load";
            this.origImageLoadBtn.UseVisualStyleBackColor = true;
            this.origImageLoadBtn.Click += new System.EventHandler(this.origImageLoadBtn_Click);
            // 
            // scaleTb
            // 
            this.scaleTb.Location = new System.Drawing.Point(66, 22);
            this.scaleTb.Name = "scaleTb";
            this.scaleTb.Size = new System.Drawing.Size(65, 20);
            this.scaleTb.TabIndex = 7;
            this.scaleTb.Text = "10";
            // 
            // offsetTb
            // 
            this.offsetTb.Location = new System.Drawing.Point(66, 62);
            this.offsetTb.Name = "offsetTb";
            this.offsetTb.Size = new System.Drawing.Size(65, 20);
            this.offsetTb.TabIndex = 8;
            this.offsetTb.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Scale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Offset";
            // 
            // waveletLoadBtn
            // 
            this.waveletLoadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveletLoadBtn.Location = new System.Drawing.Point(1004, 571);
            this.waveletLoadBtn.Name = "waveletLoadBtn";
            this.waveletLoadBtn.Size = new System.Drawing.Size(66, 32);
            this.waveletLoadBtn.TabIndex = 11;
            this.waveletLoadBtn.Text = "Load";
            this.waveletLoadBtn.UseVisualStyleBackColor = true;
            // 
            // waveletSaveBtn
            // 
            this.waveletSaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveletSaveBtn.Location = new System.Drawing.Point(913, 571);
            this.waveletSaveBtn.Name = "waveletSaveBtn";
            this.waveletSaveBtn.Size = new System.Drawing.Size(66, 32);
            this.waveletSaveBtn.TabIndex = 12;
            this.waveletSaveBtn.Text = "Save";
            this.waveletSaveBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yTb);
            this.groupBox1.Controls.Add(this.xTb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.scaleTb);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.offsetTb);
            this.groupBox1.Location = new System.Drawing.Point(558, 571);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vizualize Wavelet";
            // 
            // yTb
            // 
            this.yTb.Location = new System.Drawing.Point(172, 59);
            this.yTb.Name = "yTb";
            this.yTb.Size = new System.Drawing.Size(65, 20);
            this.yTb.TabIndex = 14;
            this.yTb.Text = "256";
            // 
            // xTb
            // 
            this.xTb.Location = new System.Drawing.Point(172, 23);
            this.xTb.Name = "xTb";
            this.xTb.Size = new System.Drawing.Size(65, 20);
            this.xTb.TabIndex = 13;
            this.xTb.Text = "256";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(154, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "x";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1076, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 26);
            this.button1.TabIndex = 14;
            this.button1.Text = "Analysis H1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1076, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 26);
            this.button2.TabIndex = 15;
            this.button2.Text = "Analysis V1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1168, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 26);
            this.button3.TabIndex = 17;
            this.button3.Text = "Synthesis V1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1168, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 26);
            this.button4.TabIndex = 16;
            this.button4.Text = "Synthesis H1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1168, 165);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 26);
            this.button5.TabIndex = 21;
            this.button5.Text = "Synthesis V2";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(1168, 133);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 26);
            this.button6.TabIndex = 20;
            this.button6.Text = "Synthesis H2";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(1076, 165);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 26);
            this.button7.TabIndex = 19;
            this.button7.Text = "Analysis V2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(1076, 133);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(86, 26);
            this.button8.TabIndex = 18;
            this.button8.Text = "Analysis H2";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(1168, 249);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(86, 26);
            this.button9.TabIndex = 25;
            this.button9.Text = "Synthesis V3";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(1168, 217);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(86, 26);
            this.button10.TabIndex = 24;
            this.button10.Text = "Synthesis H3";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(1076, 249);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(86, 26);
            this.button11.TabIndex = 23;
            this.button11.Text = "Analysis V3";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(1076, 217);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(86, 26);
            this.button12.TabIndex = 22;
            this.button12.Text = "Analysis H3";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(1168, 334);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(86, 26);
            this.button13.TabIndex = 29;
            this.button13.Text = "Synthesis V4";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(1168, 302);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(86, 26);
            this.button14.TabIndex = 28;
            this.button14.Text = "Synthesis H4";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(1076, 334);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(86, 26);
            this.button15.TabIndex = 27;
            this.button15.Text = "Analysis V4";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(1076, 302);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(86, 26);
            this.button16.TabIndex = 26;
            this.button16.Text = "Analysis H4";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(1168, 415);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(86, 26);
            this.button17.TabIndex = 33;
            this.button17.Text = "Synthesis V5";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(1168, 383);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(86, 26);
            this.button18.TabIndex = 32;
            this.button18.Text = "Synthesis H5";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(1076, 415);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(86, 26);
            this.button19.TabIndex = 31;
            this.button19.Text = "Analysis V5";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(1076, 383);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(86, 26);
            this.button20.TabIndex = 30;
            this.button20.Text = "Analysis H5";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Location = new System.Drawing.Point(801, 597);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(78, 40);
            this.refreshBtn.TabIndex = 86;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // minLabel
            // 
            this.minLabel.AutoSize = true;
            this.minLabel.Location = new System.Drawing.Point(17, 52);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(33, 13);
            this.minLabel.TabIndex = 88;
            this.minLabel.Text = "Min =";
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(17, 26);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(36, 13);
            this.maxLabel.TabIndex = 87;
            this.maxLabel.Text = "Max =";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxLabel);
            this.groupBox2.Controls.Add(this.minLabel);
            this.groupBox2.Location = new System.Drawing.Point(164, 585);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 77);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Error";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 683);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.waveletSaveBtn);
            this.Controls.Add(this.waveletLoadBtn);
            this.Controls.Add(this.origImageLoadBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.waveletImagePb);
            this.Controls.Add(this.originalImagePb);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wavelet";
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveletImagePb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImagePb;
        private System.Windows.Forms.PictureBox waveletImagePb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button origImageLoadBtn;
        private System.Windows.Forms.TextBox scaleTb;
        private System.Windows.Forms.TextBox offsetTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button waveletLoadBtn;
        private System.Windows.Forms.Button waveletSaveBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.TextBox yTb;
        private System.Windows.Forms.TextBox xTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

