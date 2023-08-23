namespace AO3SchedulerWin.Forms
{
    partial class SchedulerScreen
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
            schedulePostButton = new Button();
            storyListContainer = new TableLayoutPanel();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // schedulePostButton
            // 
            schedulePostButton.BackColor = Color.FromArgb(153, 0, 0);
            schedulePostButton.Dock = DockStyle.Bottom;
            schedulePostButton.FlatStyle = FlatStyle.Flat;
            schedulePostButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            schedulePostButton.ForeColor = Color.White;
            schedulePostButton.Location = new Point(0, 398);
            schedulePostButton.Name = "schedulePostButton";
            schedulePostButton.Size = new Size(800, 52);
            schedulePostButton.TabIndex = 0;
            schedulePostButton.Text = "Schedule New Post";
            schedulePostButton.UseVisualStyleBackColor = false;
            schedulePostButton.Click += schedulePostButton_Click;
            // 
            // storyListContainer
            // 
            storyListContainer.AutoScroll = true;
            storyListContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            storyListContainer.ColumnCount = 1;
            storyListContainer.ColumnStyles.Add(new ColumnStyle());
            storyListContainer.Dock = DockStyle.Fill;
            storyListContainer.Location = new Point(0, 0);
            storyListContainer.Name = "storyListContainer";
            storyListContainer.RowCount = 1;
            storyListContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            storyListContainer.Size = new Size(800, 366);
            storyListContainer.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 366);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 32);
            panel1.TabIndex = 0;
            // 
            // SchedulerScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(storyListContainer);
            Controls.Add(panel1);
            Controls.Add(schedulePostButton);
            Name = "SchedulerScreen";
            Text = "SchedulerForm";
            ResumeLayout(false);
        }

        #endregion

        private Button schedulePostButton;
        private TableLayoutPanel storyListContainer;
        private Panel panel1;
    }
}