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
            button3 = new Button();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            sideBarDetailPanel = new Panel();
            sideBarPanel = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            topBarPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            sideBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topBarPanel
            // 
            topBarPanel.BackColor = Color.FromArgb(153, 0, 0);
            topBarPanel.Controls.Add(button3);
            topBarPanel.Controls.Add(label1);
            topBarPanel.Controls.Add(button2);
            topBarPanel.Controls.Add(button1);
            topBarPanel.Dock = DockStyle.Top;
            topBarPanel.Location = new Point(173, 0);
            topBarPanel.Name = "topBarPanel";
            topBarPanel.Size = new Size(891, 95);
            topBarPanel.TabIndex = 1;
            topBarPanel.MouseDown += topBarPanel_MouseDown;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(153, 0, 0);
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(777, 12);
            button3.Name = "button3";
            button3.Size = new Size(30, 30);
            button3.TabIndex = 8;
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(18, 18);
            label1.Name = "label1";
            label1.Size = new Size(383, 59);
            label1.TabIndex = 0;
            label1.Text = "AO3 Scheduler";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(153, 0, 0);
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(813, 12);
            button2.Name = "button2";
            button2.Size = new Size(30, 30);
            button2.TabIndex = 7;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(153, 0, 0);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(849, 12);
            button1.Name = "button1";
            button1.Size = new Size(30, 30);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(200, 0, 0);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(173, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 10);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 94);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(173, 497);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 138);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(173, 220);
            panel2.TabIndex = 4;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(60, 60, 60);
            button8.Dock = DockStyle.Top;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(0, 165);
            button8.Name = "button8";
            button8.Size = new Size(173, 55);
            button8.TabIndex = 3;
            button8.Text = "Log Out";
            button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(60, 60, 60);
            button7.Dock = DockStyle.Top;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Location = new Point(0, 110);
            button7.Name = "button7";
            button7.Size = new Size(173, 55);
            button7.TabIndex = 2;
            button7.Text = "Settings";
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(60, 60, 60);
            button6.Dock = DockStyle.Top;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.ControlLightLight;
            button6.Location = new Point(0, 55);
            button6.Name = "button6";
            button6.Size = new Size(173, 55);
            button6.TabIndex = 1;
            button6.Text = "Schedule";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(60, 60, 60);
            button5.Dock = DockStyle.Top;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Location = new Point(0, 0);
            button5.Name = "button5";
            button5.Size = new Size(173, 55);
            button5.TabIndex = 0;
            button5.Text = "Home";
            button5.UseVisualStyleBackColor = false;
            // 
            // sideBarDetailPanel
            // 
            sideBarDetailPanel.BackColor = SystemColors.ActiveCaptionText;
            sideBarDetailPanel.BackgroundImage = (Image)resources.GetObject("sideBarDetailPanel.BackgroundImage");
            sideBarDetailPanel.BackgroundImageLayout = ImageLayout.Stretch;
            sideBarDetailPanel.Dock = DockStyle.Top;
            sideBarDetailPanel.Location = new Point(0, 0);
            sideBarDetailPanel.Name = "sideBarDetailPanel";
            sideBarDetailPanel.Size = new Size(173, 94);
            sideBarDetailPanel.TabIndex = 2;
            // 
            // sideBarPanel
            // 
            sideBarPanel.BackColor = Color.FromArgb(35, 35, 35);
            sideBarPanel.Controls.Add(tableLayoutPanel1);
            sideBarPanel.Controls.Add(sideBarDetailPanel);
            sideBarPanel.Dock = DockStyle.Left;
            sideBarPanel.Location = new Point(0, 0);
            sideBarPanel.Name = "sideBarPanel";
            sideBarPanel.Size = new Size(173, 591);
            sideBarPanel.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(191, 130);
            label2.Name = "label2";
            label2.Size = new Size(276, 50);
            label2.TabIndex = 3;
            label2.Text = "Welcome back,";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(153, 0, 0);
            label3.Location = new Point(453, 130);
            label3.Name = "label3";
            label3.Size = new Size(130, 50);
            label3.TabIndex = 4;
            label3.Text = "DrewIt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(191, 180);
            label4.Name = "label4";
            label4.Size = new Size(425, 37);
            label4.TabIndex = 5;
            label4.Text = "You have: 0 pending story uploads";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 591);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(topBarPanel);
            Controls.Add(sideBarPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            topBarPanel.ResumeLayout(false);
            topBarPanel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            sideBarPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel topBarPanel;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Panel sideBarDetailPanel;
        private Panel sideBarPanel;
        private Label label2;
        private Label label3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label4;
    }
}