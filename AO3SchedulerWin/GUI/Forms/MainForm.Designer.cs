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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            topBarPanel = new Panel();
            minimizeButton = new Button();
            formTitleLabel = new Label();
            maximizeButton = new Button();
            closeButton = new Button();
            topBarDetailPanel = new Panel();
            panel2 = new Panel();
            versionLabel = new Label();
            settingsButton = new Button();
            accountsButton = new Button();
            scheduleButton = new Button();
            homeButton = new Button();
            sideBarDetailPanel = new Panel();
            pictureBox1 = new PictureBox();
            sideBarPanel = new Panel();
            mainContentPanel = new Panel();
            notifyIcon = new NotifyIcon(components);
            topBarPanel.SuspendLayout();
            panel2.SuspendLayout();
            sideBarDetailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            topBarPanel.Location = new Point(243, 0);
            topBarPanel.Margin = new Padding(4, 5, 4, 5);
            topBarPanel.Name = "topBarPanel";
            topBarPanel.Size = new Size(1340, 158);
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
            minimizeButton.Location = new Point(1177, 20);
            minimizeButton.Margin = new Padding(4, 5, 4, 5);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(43, 50);
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
            formTitleLabel.Location = new Point(26, 30);
            formTitleLabel.Margin = new Padding(4, 0, 4, 0);
            formTitleLabel.Name = "formTitleLabel";
            formTitleLabel.Size = new Size(264, 86);
            formTitleLabel.TabIndex = 0;
            formTitleLabel.Text = "Foxter";
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
            maximizeButton.Location = new Point(1229, 20);
            maximizeButton.Margin = new Padding(4, 5, 4, 5);
            maximizeButton.Name = "maximizeButton";
            maximizeButton.Size = new Size(43, 50);
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
            closeButton.Location = new Point(1280, 20);
            closeButton.Margin = new Padding(4, 5, 4, 5);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(43, 50);
            closeButton.TabIndex = 6;
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // topBarDetailPanel
            // 
            topBarDetailPanel.BackColor = Color.FromArgb(200, 0, 0);
            topBarDetailPanel.Dock = DockStyle.Top;
            topBarDetailPanel.Location = new Point(243, 158);
            topBarDetailPanel.Margin = new Padding(4, 5, 4, 5);
            topBarDetailPanel.Name = "topBarDetailPanel";
            topBarDetailPanel.Size = new Size(1340, 17);
            topBarDetailPanel.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(versionLabel);
            panel2.Controls.Add(settingsButton);
            panel2.Controls.Add(accountsButton);
            panel2.Controls.Add(scheduleButton);
            panel2.Controls.Add(homeButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 157);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(243, 826);
            panel2.TabIndex = 4;
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Dock = DockStyle.Bottom;
            versionLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            versionLabel.ForeColor = SystemColors.WindowFrame;
            versionLabel.Location = new Point(0, 795);
            versionLabel.Margin = new Padding(4, 0, 4, 0);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(209, 31);
            versionLabel.TabIndex = 4;
            versionLabel.Text = "Version: alpha 1.0.0";
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.FromArgb(60, 60, 60);
            settingsButton.Dock = DockStyle.Top;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.ForeColor = SystemColors.ControlLightLight;
            settingsButton.Location = new Point(0, 375);
            settingsButton.Margin = new Padding(4, 5, 4, 5);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(243, 125);
            settingsButton.TabIndex = 2;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // accountsButton
            // 
            accountsButton.BackColor = Color.FromArgb(60, 60, 60);
            accountsButton.Dock = DockStyle.Top;
            accountsButton.FlatAppearance.BorderSize = 0;
            accountsButton.FlatStyle = FlatStyle.Flat;
            accountsButton.ForeColor = SystemColors.ControlLightLight;
            accountsButton.Location = new Point(0, 250);
            accountsButton.Margin = new Padding(4, 5, 4, 5);
            accountsButton.Name = "accountsButton";
            accountsButton.Size = new Size(243, 125);
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
            scheduleButton.Location = new Point(0, 125);
            scheduleButton.Margin = new Padding(4, 5, 4, 5);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(243, 125);
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
            homeButton.Margin = new Padding(4, 5, 4, 5);
            homeButton.Name = "homeButton";
            homeButton.Size = new Size(243, 125);
            homeButton.TabIndex = 0;
            homeButton.Text = "Home";
            homeButton.UseVisualStyleBackColor = false;
            homeButton.Click += homeButton_Click;
            // 
            // sideBarDetailPanel
            // 
            sideBarDetailPanel.BackColor = SystemColors.ActiveCaptionText;
            sideBarDetailPanel.BackgroundImageLayout = ImageLayout.Zoom;
            sideBarDetailPanel.Controls.Add(pictureBox1);
            sideBarDetailPanel.Dock = DockStyle.Top;
            sideBarDetailPanel.Location = new Point(0, 0);
            sideBarDetailPanel.Margin = new Padding(4, 5, 4, 5);
            sideBarDetailPanel.Name = "sideBarDetailPanel";
            sideBarDetailPanel.Padding = new Padding(7, 8, 7, 8);
            sideBarDetailPanel.Size = new Size(243, 157);
            sideBarDetailPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(7, 8);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // sideBarPanel
            // 
            sideBarPanel.BackColor = Color.FromArgb(35, 35, 35);
            sideBarPanel.Controls.Add(panel2);
            sideBarPanel.Controls.Add(sideBarDetailPanel);
            sideBarPanel.Dock = DockStyle.Left;
            sideBarPanel.Location = new Point(0, 0);
            sideBarPanel.Margin = new Padding(4, 5, 4, 5);
            sideBarPanel.Name = "sideBarPanel";
            sideBarPanel.Size = new Size(243, 983);
            sideBarPanel.TabIndex = 0;
            // 
            // mainContentPanel
            // 
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(243, 175);
            mainContentPanel.Margin = new Padding(4, 5, 4, 5);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Size = new Size(1340, 808);
            mainContentPanel.TabIndex = 3;
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipText = "The application is still running on the background";
            notifyIcon.BalloonTipTitle = "Application minimized";
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Foxter";
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1583, 983);
            ControlBox = false;
            Controls.Add(mainContentPanel);
            Controls.Add(topBarDetailPanel);
            Controls.Add(topBarPanel);
            Controls.Add(sideBarPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1520, 983);
            Name = "MainForm";
            Text = "AO3 Scheduler";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            topBarPanel.ResumeLayout(false);
            topBarPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            sideBarDetailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Label versionLabel;
        private NotifyIcon notifyIcon;
        private PictureBox pictureBox1;
    }
}