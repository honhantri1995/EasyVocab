namespace VocabManager
{
    partial class StudyFinishConfirmDialogFrm
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
            this.Lbl_FinishNotification = new System.Windows.Forms.Label();
            this.Btn_Ok = new System.Windows.Forms.Button();
            this.Btn_Review = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl_FinishNotification
            // 
            this.Lbl_FinishNotification.AutoSize = true;
            this.Lbl_FinishNotification.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_FinishNotification.Location = new System.Drawing.Point(12, 18);
            this.Lbl_FinishNotification.Name = "Lbl_FinishNotification";
            this.Lbl_FinishNotification.Size = new System.Drawing.Size(80, 23);
            this.Lbl_FinishNotification.TabIndex = 0;
            this.Lbl_FinishNotification.Text = "Finished!";
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ok.Location = new System.Drawing.Point(16, 60);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(88, 35);
            this.Btn_Ok.TabIndex = 1;
            this.Btn_Ok.Text = "OK";
            this.Btn_Ok.UseVisualStyleBackColor = true;
            this.Btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // Btn_Review
            // 
            this.Btn_Review.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Review.Location = new System.Drawing.Point(138, 60);
            this.Btn_Review.Name = "Btn_Review";
            this.Btn_Review.Size = new System.Drawing.Size(93, 35);
            this.Btn_Review.TabIndex = 2;
            this.Btn_Review.Text = "Review";
            this.Btn_Review.UseVisualStyleBackColor = true;
            this.Btn_Review.Click += new System.EventHandler(this.Btn_Review_Click);
            // 
            // StudyFinishConfirmDialogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 121);
            this.Controls.Add(this.Btn_Review);
            this.Controls.Add(this.Btn_Ok);
            this.Controls.Add(this.Lbl_FinishNotification);
            this.Name = "StudyFinishConfirmDialogFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_FinishNotification;
        private System.Windows.Forms.Button Btn_Ok;
        private System.Windows.Forms.Button Btn_Review;
    }
}