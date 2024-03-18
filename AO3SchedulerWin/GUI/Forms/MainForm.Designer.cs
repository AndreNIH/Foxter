namespace AO3SchedulerWin
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            topBarPanel = new Panel();
            minimizeButton = new Button();
            formTitleLabel = new Label();
            maximizeButton = new Button();
            closeButton = new Button();
            topBarDetailPanel = new Panel();
            panel2 = new Panel();
            settingsButton = new Button();
            accountsButton = new Button();
            scheduleButton = new Button();
            homeButton = new Button();
            sideBarDetailPanel = new Panel();
            sideBarPanel = new Panel();
            mainContentPanel = new Panel();
            topBarPanel.SuspendLayout();
            panel2.SuspendLayout();
            sideBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topBarPanel
            // 
            topBarPanel.BackColor = Color.FromArgb(153, 0, 0);
            topBarPanel.Controls.Add(minimizeButton);
            topBarPanel.Controls.Add(formTitleLabel);
            topBarPanel.Controls.Add(maximizeButton);
            topBarPanel.Controls.Add(closeButton);
            topBarPanel.Dock = DockStyle.Top;
            topBarPanel.Location = new Point(170, 0);
            topBarPanel.Name = "topBarPanel";
            topBarPanel.Size = new Size(938, 95);
            topBarPanel.TabIndex = 1;
            topBarPanel.MouseDown += topBarPanel_MouseDown;
            // 
            // minimizeButton
            // 
            minimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minimizeButton.BackColor = Color.FromArgb(153, 0, 0);
            minimizeButton.BackgroundImage = (Image)resources.GetObject("minimizeButton.BackgroundImage");
            minimizeButton.BackgroundImageLayout = ImageLayout.Stretch;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.Location = new Point(824, 12);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(30, 30);
            minimizeButton.TabIndex = 8;
            minimizeButton.UseVisualStyleBackColor = false;
            minimizeButton.Click += minimizeButton_Click;
            // 
            // formTitleLabel
            // 
            formTitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            formTitleLabel.AutoSize = true;
            formTitleLabel.Font = new Font("Verdana", 36F, FontStyle.Regular, GraphicsUnit.Point);
            formTitleLabel.ForeColor = Color.White;
            formTitleLabel.Location = new Point(18, 18);
            formTitleLabel.Name = "formTitleLabel";
            formTitleLabel.Size = new Size(383, 59);
            formTitleLabel.TabIndex = 0;
            formTitleLabel.Text = "AO3 Scheduler";
            formTitleLabel.MouseDown += formTitleLabel_MouseDown;
            // 
            // maximizeButton
            // 
            maximizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maximizeButton.BackColor = Color.FromArgb(153, 0, 0);
            maximizeButton.BackgroundImage = (Image)resources.GetObject("maximizeButton.BackgroundImage");
            maximizeButton.BackgroundImageLayout = ImageLayout.Stretch;
            maximizeButton.FlatAppearance.BorderSize = 0;
            maximizeButton.FlatStyle = FlatStyle.Flat;
            maximizeButton.Location = new Point(860, 12);
            maximizeButton.Name = "maximizeButton";
            maximizeButton.Size = new Size(30, 30);
            maximizeButton.TabIndex = 7;
            maximizeButton.UseVisualStyleBackColor = false;
            maximizeButton.Click += maximizeButton_Click;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.BackColor = Color.FromArgb(153, 0, 0);
            closeButton.BackgroundImage = (Image)resources.GetObject("closeButton.BackgroundImage");
            closeButton.BackgroundImageLayout = ImageLayout.Stretch;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Location = new Point(896, 12);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(30, 30);
            closeButton.TabIndex = 6;
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // topBarDetailPanel
            // 
            topBarDetailPanel.BackColor = Color.FromArgb(200, 0, 0);
            topBarDetailPanel.Dock = DockStyle.Top;
            topBarDetailPanel.Location = new Point(170, 95);
            topBarDetailPanel.Name = "topBarDetailPanel";
            topBarDetailPanel.Size = new Size(938, 10);
            topBarDetailPanel.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(settingsButton);
            panel2.Controls.Add(accountsButton);
            panel2.Controls.Add(scheduleButton);
            panel2.Controls.Add(homeButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 94);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(170, 496);
            panel2.TabIndex = 4;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.FromArgb(60, 60, 60);
            settingsButton.Dock = DockStyle.Top;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.ForeColor = SystemColors.ControlLightLight;
            settingsButton.Location = new Point(0, 225);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(170, 75);
            settingsButton.TabIndex = 2;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Visible = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // accountsButton
            // 
            accountsButton.BackColor = Color.FromArgb(60, 60, 60);
            accountsButton.Dock = DockStyle.Top;
            accountsButton.FlatAppearance.BorderSize = 0;
            accountsButton.FlatStyle = FlatStyle.Flat;
            accountsButton.ForeColor = SystemColors.ControlLightLight;
            accountsButton.Location = new Point(0, 150);
            accountsButton.Name = "accountsButton";
            accountsButton.Size = new Size(170, 75);
            accountsButton.TabIndex = 3;
            accountsButton.Text = "Accounts";
            accountsButton.UseVisualStyleBackColor = false;
            accountsButton.Click += accountsButton_Click;
            // 
            // scheduleButton
            // 
            scheduleButton.BackColor = Color.FromArgb(60, 60, 60);
            scheduleButton.Dock = DockStyle.Top;
            scheduleButton.FlatAppearance.BorderSize = 0;
            scheduleButton.FlatStyle = FlatStyle.Flat;
            scheduleButton.ForeColor = SystemColors.ControlLightLight;
            scheduleButton.Location = new Point(0, 75);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(170, 75);
            scheduleButton.TabIndex = 1;
            scheduleButton.Text = "Schedule";
            scheduleButton.UseVisualStyleBackColor = false;
            scheduleButton.Click += scheduleButton_Click;
            // 
            // homeButton
            // 
            homeButton.BackColor = Color.FromArgb(60, 60, 60);
            homeButton.Dock = DockStyle.Top;
            homeButton.FlatAppearance.BorderSize = 0;
            homeButton.FlatStyle = FlatStyle.Flat;
            homeButton.ForeColor = SystemColors.ControlLightLight;
            homeButton.Location = new Point(0, 0);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(170, 75);
            homeButton.TabIndex = 0;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = false;
            homeButton.Click += homeButton_Click;
            // 
            // sideBarDetailPanel
            // 
            sideBarDetailPanel.BackColor = SystemColors.ActiveCaptionText;
            sideBarDetailPanel.BackgroundImage = (Image)resources.GetObject("sideBarDetailPanel.BackgroundImage");
            sideBarDetailPanel.BackgroundImageLayout = ImageLayout.Stretch;
            sideBarDetailPanel.Dock = DockStyle.Top;
            sideBarDetailPanel.Location = new Point(0, 0);
            sideBarDetailPanel.Name = "sideBarDetailPanel";
            sideBarDetailPanel.Size = new Size(170, 94);
            sideBarDetailPanel.TabIndex = 2;
            // 
            // sideBarPanel
            // 
            sideBarPanel.BackColor = Color.FromArgb(35, 35, 35);
            sideBarPanel.Controls.Add(panel2);
            sideBarPanel.Controls.Add(sideBarDetailPanel);
            sideBarPanel.Dock = DockStyle.Left;
            sideBarPanel.Location = new Point(0, 0);
            sideBarPanel.Name = "sideBarPanel";
            sideBarPanel.Size = new Size(170, 590);
            sideBarPanel.TabIndex = 0;
            // 
            // mainContentPanel
            // 
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(170, 105);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(938, 485);
            mainContentPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 590);
            Controls.Add(mainContentPanel);
            Controls.Add(topBarDetailPanel);
            Controls.Add(topBarPanel);
            Controls.Add(sideBarPanel);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1064, 590);
            Name = "MainForm";
            Text = "AO3 Scheduler";
            WindowState = FormWindowState.Maximized;
            topBarPanel.ResumeLayout(false);
            topBarPanel.PerformLayout();
            panel2.ResumeLayout(false);
            sideBarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel topBarPanel;
        private Label formTitleLabel;
        private Panel topBarDetailPanel;
        private Panel panel2;
        private Button accountsButton;
        private Button settingsButton;
        private Button scheduleButton;
        private Button homeButton;
        private Panel sideBarDetailPanel;
        private Panel sideBarPanel;
        private Button minimizeButton;
        private Button maximizeButton;
        private Button closeButton;
        private Panel mainContentPanel;
    }
}