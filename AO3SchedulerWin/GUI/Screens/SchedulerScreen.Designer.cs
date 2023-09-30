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
            padding = new Panel();
            mainContainer = new TabControl();
            nothingPage = new TabPage();
            label1 = new Label();
            schedulePage = new TabPage();
            mainContainer.SuspendLayout();
            nothingPage.SuspendLayout();
            schedulePage.SuspendLayout();
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
            storyListContainer.Location = new Point(3, 3);
            storyListContainer.Name = "storyListContainer";
            storyListContainer.RowCount = 1;
            storyListContainer.RowStyles.Add(new RowStyle());
            storyListContainer.Size = new Size(786, 332);
            storyListContainer.TabIndex = 1;
            // 
            // padding
            // 
            padding.Dock = DockStyle.Bottom;
            padding.Location = new Point(0, 366);
            padding.Name = "padding";
            padding.Size = new Size(800, 32);
            padding.TabIndex = 0;
            // 
            // mainContainer
            // 
            mainContainer.Controls.Add(nothingPage);
            mainContainer.Controls.Add(schedulePage);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Margin = new Padding(0);
            mainContainer.Name = "mainContainer";
            mainContainer.Padding = new Point(0, 0);
            mainContainer.SelectedIndex = 0;
            mainContainer.Size = new Size(800, 366);
            mainContainer.TabIndex = 0;
            // 
            // nothingPage
            // 
            nothingPage.BackColor = SystemColors.Control;
            nothingPage.Controls.Add(label1);
            nothingPage.Location = new Point(4, 24);
            nothingPage.Name = "nothingPage";
            nothingPage.Padding = new Padding(3);
            nothingPage.Size = new Size(792, 338);
            nothingPage.TabIndex = 1;
            nothingPage.Text = "tabPage2";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(786, 332);
            label1.TabIndex = 0;
            label1.Text = "Nothing to post...";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // schedulePage
            // 
            schedulePage.BackColor = SystemColors.Control;
            schedulePage.Controls.Add(storyListContainer);
            schedulePage.Location = new Point(4, 24);
            schedulePage.Name = "schedulePage";
            schedulePage.Padding = new Padding(3);
            schedulePage.Size = new Size(792, 338);
            schedulePage.TabIndex = 0;
            schedulePage.Text = "tabPage1";
            // 
            // SchedulerScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainContainer);
            Controls.Add(padding);
            Controls.Add(schedulePostButton);
            Name = "SchedulerScreen";
            Text = "SchedulerForm";
            mainContainer.ResumeLayout(false);
            nothingPage.ResumeLayout(false);
            schedulePage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button schedulePostButton;
        private TableLayoutPanel storyListContainer;
        private Panel padding;
        private TabControl mainContainer;
        private TabPage schedulePage;
        private TabPage nothingPage;
        private Label label1;
    }
}