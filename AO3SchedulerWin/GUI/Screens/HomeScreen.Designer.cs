namespace AO3SchedulerWin.Forms
{
    partial class HomeScreen
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
            pendingUploadLabel = new Label();
            authorLabel = new Label();
            label2 = new Label();
            failedUploadLabel = new Label();
            SuspendLayout();
            // 
            // pendingUploadLabel
            // 
            pendingUploadLabel.AutoSize = true;
            pendingUploadLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            pendingUploadLabel.Location = new Point(12, 59);
            pendingUploadLabel.Name = "pendingUploadLabel";
            pendingUploadLabel.Size = new Size(425, 37);
            pendingUploadLabel.TabIndex = 8;
            pendingUploadLabel.Text = "You have: 0 pending story uploads";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            authorLabel.ForeColor = Color.FromArgb(153, 0, 0);
            authorLabel.Location = new Point(273, 9);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(95, 50);
            authorLabel.TabIndex = 7;
            authorLabel.Text = "User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(276, 50);
            label2.TabIndex = 6;
            label2.Text = "Welcome back,";
            // 
            // failedUploadLabel
            // 
            failedUploadLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            failedUploadLabel.AutoSize = true;
            failedUploadLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            failedUploadLabel.ForeColor = Color.FromArgb(153, 0, 0);
            failedUploadLabel.Location = new Point(12, 96);
            failedUploadLabel.Margin = new Padding(0);
            failedUploadLabel.Name = "failedUploadLabel";
            failedUploadLabel.Size = new Size(317, 37);
            failedUploadLabel.TabIndex = 9;
            failedUploadLabel.Text = "N stories failed to upload";
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(failedUploadLabel);
            Controls.Add(pendingUploadLabel);
            Controls.Add(authorLabel);
            Controls.Add(label2);
            Name = "HomeScreen";
            Text = "HomeScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label pendingUploadLabel;
        private Label authorLabel;
        private Label label2;
        private Label failedUploadLabel;
    }
}