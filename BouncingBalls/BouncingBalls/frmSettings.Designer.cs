namespace BouncingBalls
{
    partial class frmSettings
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
            this.lblNumberOfBallsCaption = new System.Windows.Forms.Label();
            this.txtNumberOfBalls = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumberOfBallsCaption
            // 
            this.lblNumberOfBallsCaption.AutoSize = true;
            this.lblNumberOfBallsCaption.Location = new System.Drawing.Point(40, 46);
            this.lblNumberOfBallsCaption.Name = "lblNumberOfBallsCaption";
            this.lblNumberOfBallsCaption.Size = new System.Drawing.Size(134, 13);
            this.lblNumberOfBallsCaption.TabIndex = 0;
            this.lblNumberOfBallsCaption.Text = "Enter a valid number (1-99)";
            // 
            // txtNumberOfBalls
            // 
            this.txtNumberOfBalls.Location = new System.Drawing.Point(43, 62);
            this.txtNumberOfBalls.Name = "txtNumberOfBalls";
            this.txtNumberOfBalls.Size = new System.Drawing.Size(131, 20);
            this.txtNumberOfBalls.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(43, 118);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(131, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 187);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNumberOfBalls);
            this.Controls.Add(this.lblNumberOfBallsCaption);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumberOfBallsCaption;
        private System.Windows.Forms.TextBox txtNumberOfBalls;
        private System.Windows.Forms.Button btnOk;
    }
}