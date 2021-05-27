namespace Shooter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelScoreNumber = new System.Windows.Forms.Label();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.buttonNameConfirmation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pBar1
            // 
            this.pBar1.Location = new System.Drawing.Point(24, 26);
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(426, 23);
            this.pBar1.TabIndex = 0;
            this.pBar1.Value = 100;
            this.pBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(551, 25);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(56, 13);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "labelScore";
            this.labelScore.Visible = false;
            // 
            // labelScoreNumber
            // 
            this.labelScoreNumber.AutoSize = true;
            this.labelScoreNumber.Location = new System.Drawing.Point(613, 25);
            this.labelScoreNumber.Name = "labelScoreNumber";
            this.labelScoreNumber.Size = new System.Drawing.Size(93, 13);
            this.labelScoreNumber.TabIndex = 3;
            this.labelScoreNumber.Text = "labelScoreNumber";
            this.labelScoreNumber.Visible = false;
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(551, 56);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(35, 13);
            this.labelPlayerName.TabIndex = 4;
            this.labelPlayerName.Text = "label2";
            this.labelPlayerName.Visible = false;
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Location = new System.Drawing.Point(613, 53);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(100, 21);
            this.textBoxPlayerName.TabIndex = 5;
            this.textBoxPlayerName.Visible = false;
            // 
            // buttonNameConfirmation
            // 
            this.buttonNameConfirmation.Location = new System.Drawing.Point(741, 50);
            this.buttonNameConfirmation.Name = "buttonNameConfirmation";
            this.buttonNameConfirmation.Size = new System.Drawing.Size(75, 23);
            this.buttonNameConfirmation.TabIndex = 6;
            this.buttonNameConfirmation.Text = "Confirm";
            this.buttonNameConfirmation.UseVisualStyleBackColor = true;
            this.buttonNameConfirmation.Visible = false;
            this.buttonNameConfirmation.Click += new System.EventHandler(this.buttonNameConfirmation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonNameConfirmation);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.labelScoreNumber);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBar1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelScoreNumber;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Button buttonNameConfirmation;
    }
}

