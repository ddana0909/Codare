namespace Fractal
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.waveletImagePb = new System.Windows.Forms.PictureBox();
            this.originalImagePb = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.origImageLoadBtn = new System.Windows.Forms.Button();
            this.saveProcessedBtn = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.loadInitialImageBtn = new System.Windows.Forms.Button();
            this.loadFractalBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.noOfStepsTb = new System.Windows.Forms.TextBox();
            this.decodeBtn = new System.Windows.Forms.Button();
            this.saveDecodedBtn = new System.Windows.Forms.Button();
            this.rPb = new System.Windows.Forms.PictureBox();
            this.dPb = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelProgressBar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.waveletImagePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPb)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(562, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Decoded Image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Original Image";
            // 
            // waveletImagePb
            // 
            this.waveletImagePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveletImagePb.Location = new System.Drawing.Point(568, 50);
            this.waveletImagePb.Name = "waveletImagePb";
            this.waveletImagePb.Size = new System.Drawing.Size(512, 512);
            this.waveletImagePb.TabIndex = 6;
            this.waveletImagePb.TabStop = false;
            // 
            // originalImagePb
            // 
            this.originalImagePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImagePb.Location = new System.Drawing.Point(22, 50);
            this.originalImagePb.Name = "originalImagePb";
            this.originalImagePb.Size = new System.Drawing.Size(512, 512);
            this.originalImagePb.TabIndex = 5;
            this.originalImagePb.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 578);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1058, 11);
            this.progressBar1.TabIndex = 9;
            // 
            // origImageLoadBtn
            // 
            this.origImageLoadBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origImageLoadBtn.Location = new System.Drawing.Point(22, 595);
            this.origImageLoadBtn.Name = "origImageLoadBtn";
            this.origImageLoadBtn.Size = new System.Drawing.Size(66, 49);
            this.origImageLoadBtn.TabIndex = 10;
            this.origImageLoadBtn.Text = "Load";
            this.origImageLoadBtn.UseVisualStyleBackColor = true;
            // 
            // saveProcessedBtn
            // 
            this.saveProcessedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveProcessedBtn.Location = new System.Drawing.Point(247, 595);
            this.saveProcessedBtn.Name = "saveProcessedBtn";
            this.saveProcessedBtn.Size = new System.Drawing.Size(66, 49);
            this.saveProcessedBtn.TabIndex = 13;
            this.saveProcessedBtn.Text = "Save";
            this.saveProcessedBtn.UseVisualStyleBackColor = true;
            // 
            // processBtn
            // 
            this.processBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processBtn.Location = new System.Drawing.Point(131, 595);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(80, 49);
            this.processBtn.TabIndex = 14;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            // 
            // loadInitialImageBtn
            // 
            this.loadInitialImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadInitialImageBtn.Location = new System.Drawing.Point(568, 595);
            this.loadInitialImageBtn.Name = "loadInitialImageBtn";
            this.loadInitialImageBtn.Size = new System.Drawing.Size(60, 49);
            this.loadInitialImageBtn.TabIndex = 15;
            this.loadInitialImageBtn.Text = "Load Inital";
            this.loadInitialImageBtn.UseVisualStyleBackColor = true;
            // 
            // loadFractalBtn
            // 
            this.loadFractalBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFractalBtn.Location = new System.Drawing.Point(670, 595);
            this.loadFractalBtn.Name = "loadFractalBtn";
            this.loadFractalBtn.Size = new System.Drawing.Size(97, 49);
            this.loadFractalBtn.TabIndex = 16;
            this.loadFractalBtn.Text = "Load *.fc";
            this.loadFractalBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(800, 595);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "no Of Steps";
            // 
            // noOfStepsTb
            // 
            this.noOfStepsTb.Location = new System.Drawing.Point(869, 592);
            this.noOfStepsTb.Name = "noOfStepsTb";
            this.noOfStepsTb.Size = new System.Drawing.Size(65, 20);
            this.noOfStepsTb.TabIndex = 18;
            this.noOfStepsTb.Text = "5";
            // 
            // decodeBtn
            // 
            this.decodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decodeBtn.Location = new System.Drawing.Point(816, 618);
            this.decodeBtn.Name = "decodeBtn";
            this.decodeBtn.Size = new System.Drawing.Size(97, 49);
            this.decodeBtn.TabIndex = 19;
            this.decodeBtn.Text = "Decode No Of Steps";
            this.decodeBtn.UseVisualStyleBackColor = true;
            // 
            // saveDecodedBtn
            // 
            this.saveDecodedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDecodedBtn.Location = new System.Drawing.Point(983, 595);
            this.saveDecodedBtn.Name = "saveDecodedBtn";
            this.saveDecodedBtn.Size = new System.Drawing.Size(97, 49);
            this.saveDecodedBtn.TabIndex = 20;
            this.saveDecodedBtn.Text = "Save";
            this.saveDecodedBtn.UseVisualStyleBackColor = true;
            // 
            // rPb
            // 
            this.rPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rPb.Location = new System.Drawing.Point(1111, 61);
            this.rPb.Name = "rPb";
            this.rPb.Size = new System.Drawing.Size(80, 80);
            this.rPb.TabIndex = 21;
            this.rPb.TabStop = false;
            // 
            // dPb
            // 
            this.dPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dPb.Location = new System.Drawing.Point(1111, 179);
            this.dPb.Name = "dPb";
            this.dPb.Size = new System.Drawing.Size(160, 160);
            this.dPb.TabIndex = 22;
            this.dPb.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1105, 457);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Offset Quantified:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1108, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Scale Quantified:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1108, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Izometry:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1108, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1108, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1148, 595);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "PSNR=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(550, 562);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "%";
            // 
            // labelProgressBar
            // 
            this.labelProgressBar.AutoSize = true;
            this.labelProgressBar.Location = new System.Drawing.Point(531, 562);
            this.labelProgressBar.Name = "labelProgressBar";
            this.labelProgressBar.Size = new System.Drawing.Size(13, 13);
            this.labelProgressBar.TabIndex = 33;
            this.labelProgressBar.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 675);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelProgressBar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dPb);
            this.Controls.Add(this.rPb);
            this.Controls.Add(this.saveDecodedBtn);
            this.Controls.Add(this.decodeBtn);
            this.Controls.Add(this.noOfStepsTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loadFractalBtn);
            this.Controls.Add(this.loadInitialImageBtn);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.saveProcessedBtn);
            this.Controls.Add(this.origImageLoadBtn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.waveletImagePb);
            this.Controls.Add(this.originalImagePb);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractal Coder";
            ((System.ComponentModel.ISupportInitialize)(this.waveletImagePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImagePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox waveletImagePb;
        private System.Windows.Forms.PictureBox originalImagePb;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button origImageLoadBtn;
        private System.Windows.Forms.Button saveProcessedBtn;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.Button loadInitialImageBtn;
        private System.Windows.Forms.Button loadFractalBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox noOfStepsTb;
        private System.Windows.Forms.Button decodeBtn;
        private System.Windows.Forms.Button saveDecodedBtn;
        private System.Windows.Forms.PictureBox rPb;
        private System.Windows.Forms.PictureBox dPb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label labelProgressBar;
    }
}

