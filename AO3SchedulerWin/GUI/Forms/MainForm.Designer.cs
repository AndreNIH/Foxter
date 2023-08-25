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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            accountsButton = new Button();
            settingsButton = new Button();
            scheduleButton = new Button();
            homeButton = new Button();
            sideBarDetailPanel = new Panel();
            sideBarPanel = new Panel();
            mainContentPanel = new Panel();
            topBarPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            formTitleLabel.Size = new Size(576, 86);
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 157);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 367F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(243, 826);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(settingsButton);
            panel2.Controls.Add(accountsButton);
            panel2.Controls.Add(scheduleButton);
            panel2.Controls.Add(homeButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 229);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(243, 367);
            panel2.TabIndex = 4;
            // 
            // accountsButton
            // 
            accountsButton.BackColor = Color.FromArgb(60, 60, 60);
            accountsButton.Dock = DockStyle.Top;
            accountsButton.FlatAppearance.BorderSize = 0;
            accountsButton.FlatStyle = FlatStyle.Flat;
            accountsButton.ForeColor = SystemColors.ControlLightLight;
            accountsButton.Location = new Point(0, 184);
            accountsButton.Margin = new Padding(4, 5, 4, 5);
            accountsButton.Name = "accountsButton";
            accountsButton.Size = new Size(243, 92);
            accountsButton.TabIndex = 3;
            accountsButton.Text = "Accounts";
            accountsButton.UseVisualStyleBackColor = false;
            accountsButton.Click += accountsButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.FromArgb(60, 60, 60);
            settingsButton.Dock = DockStyle.Top;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.ForeColor = SystemColors.ControlLightLight;
            settingsButton.Location = new Point(0, 276);
            settingsButton.Margin = new Padding(4, 5, 4, 5);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(243, 92);
            settingsButton.TabIndex = 2;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButton_Click;
            // 
            // scheduleButton
            // 
            scheduleButton.BackColor = Color.FromArgb(60, 60, 60);
            scheduleButton.Dock = DockStyle.Top;
            scheduleButton.FlatAppearance.BorderSize = 0;
            scheduleButton.FlatStyle = FlatStyle.Flat;
            scheduleButton.ForeColor = SystemColors.ControlLightLight;
            scheduleButton.Location = new Point(0, 92);
            scheduleButton.Margin = new Padding(4, 5, 4, 5);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(243, 92);
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
            homeButton.Size = new Size(243, 92);
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
            sideBarDetailPanel.Margin = new Padding(4, 5, 4, 5);
            sideBarDetailPanel.Name = "sideBarDetailPanel";
            sideBarDetailPanel.Size = new Size(243, 157);
            sideBarDetailPanel.TabIndex = 2;
            // 
            // sideBarPanel
            // 
            sideBarPanel.BackColor = Color.FromArgb(35, 35, 35);
            sideBarPanel.Controls.Add(tableLayoutPanel1);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1583, 983);
            Controls.Add(mainContentPanel);
            Controls.Add(topBarDetailPanel);
            Controls.Add(topBarPanel);
            Controls.Add(sideBarPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1520, 983);
            Name = "MainForm";
            Text = "Form1";
            topBarPanel.ResumeLayout(false);
            topBarPanel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            sideBarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel topBarPanel;
        private Label formTitleLabel;
        private Panel topBarDetailPanel;
        private TableLayoutPanel tableLayoutPanel1;
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