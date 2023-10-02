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
            queueLabel = new Label();
            authorLabel = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // queueLabel
            // 
            queueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            queueLabel.AutoSize = true;
            queueLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            queueLabel.Location = new Point(12, 59);
            queueLabel.Name = "queueLabel";
            queueLabel.Size = new Size(425, 37);
            queueLabel.TabIndex = 8;
            queueLabel.Text = "You have: 0 pending story uploads";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            authorLabel.ForeColor = Color.FromArgb(153, 0, 0);
            authorLabel.Location = new Point(299, 9);
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
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(queueLabel);
            Controls.Add(authorLabel);
            Controls.Add(label2);
            Name = "HomeScreen";
            Text = "HomeScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label queueLabel;
        private Label authorLabel;
        private Label label2;
    }
}