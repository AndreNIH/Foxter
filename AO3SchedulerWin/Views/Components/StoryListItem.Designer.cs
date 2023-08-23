namespace AO3SchedulerWin.Forms
{
    partial class StoryListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoryListItem));
            detailPanel = new Panel();
            pictureBox1 = new PictureBox();
            outerContainerLayout = new TableLayoutPanel();
            innerElementsContainer = new TableLayoutPanel();
            dateContainer = new TableLayoutPanel();
            publishingDateLabelLHS = new Label();
            publishingDateLabelRHS = new Label();
            chapterContainer = new TableLayoutPanel();
            chapterTitleLabelLHS = new Label();
            chapterTitleLabelRHS = new Label();
            titleContainer = new TableLayoutPanel();
            storyTitleLabelLHS = new Label();
            storyTitleLabelRHS = new Label();
            editButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label5 = new Label();
            label6 = new Label();
            detailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            outerContainerLayout.SuspendLayout();
            innerElementsContainer.SuspendLayout();
            dateContainer.SuspendLayout();
            chapterContainer.SuspendLayout();
            titleContainer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // detailPanel
            // 
            detailPanel.BackColor = Color.FromArgb(153, 0, 0);
            detailPanel.Controls.Add(pictureBox1);
            detailPanel.Dock = DockStyle.Left;
            detailPanel.Location = new Point(0, 0);
            detailPanel.Name = "detailPanel";
            detailPanel.Size = new Size(150, 150);
            detailPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // outerContainerLayout
            // 
            outerContainerLayout.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            outerContainerLayout.ColumnCount = 2;
            outerContainerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            outerContainerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            outerContainerLayout.Controls.Add(innerElementsContainer, 0, 0);
            outerContainerLayout.Controls.Add(editButton, 1, 0);
            outerContainerLayout.Location = new Point(150, 0);
            outerContainerLayout.Name = "outerContainerLayout";
            outerContainerLayout.RowCount = 1;
            outerContainerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            outerContainerLayout.Size = new Size(659, 150);
            outerContainerLayout.TabIndex = 1;
            // 
            // innerElementsContainer
            // 
            innerElementsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            innerElementsContainer.ColumnCount = 1;
            innerElementsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            innerElementsContainer.Controls.Add(dateContainer, 0, 2);
            innerElementsContainer.Controls.Add(chapterContainer, 0, 1);
            innerElementsContainer.Controls.Add(titleContainer, 0, 0);
            innerElementsContainer.Dock = DockStyle.Fill;
            innerElementsContainer.Location = new Point(3, 3);
            innerElementsContainer.Name = "innerElementsContainer";
            innerElementsContainer.RowCount = 4;
            innerElementsContainer.RowStyles.Add(new RowStyle());
            innerElementsContainer.RowStyles.Add(new RowStyle());
            innerElementsContainer.RowStyles.Add(new RowStyle());
            innerElementsContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            innerElementsContainer.Size = new Size(503, 144);
            innerElementsContainer.TabIndex = 0;
            // 
            // dateContainer
            // 
            dateContainer.AutoSize = true;
            dateContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dateContainer.ColumnCount = 2;
            dateContainer.ColumnStyles.Add(new ColumnStyle());
            dateContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            dateContainer.Controls.Add(publishingDateLabelLHS, 0, 0);
            dateContainer.Controls.Add(publishingDateLabelRHS, 1, 0);
            dateContainer.Dock = DockStyle.Fill;
            dateContainer.Location = new Point(3, 100);
            dateContainer.Name = "dateContainer";
            dateContainer.RowCount = 1;
            dateContainer.RowStyles.Add(new RowStyle());
            dateContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            dateContainer.Size = new Size(497, 25);
            dateContainer.TabIndex = 2;
            // 
            // publishingDateLabelLHS
            // 
            publishingDateLabelLHS.AutoSize = true;
            publishingDateLabelLHS.Dock = DockStyle.Top;
            publishingDateLabelLHS.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            publishingDateLabelLHS.Location = new Point(0, 0);
            publishingDateLabelLHS.Margin = new Padding(0);
            publishingDateLabelLHS.Name = "publishingDateLabelLHS";
            publishingDateLabelLHS.Size = new Size(140, 25);
            publishingDateLabelLHS.TabIndex = 0;
            publishingDateLabelLHS.Text = "Publishing on:";
            publishingDateLabelLHS.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // publishingDateLabelRHS
            // 
            publishingDateLabelRHS.AutoSize = true;
            publishingDateLabelRHS.Dock = DockStyle.Fill;
            publishingDateLabelRHS.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            publishingDateLabelRHS.Location = new Point(143, 0);
            publishingDateLabelRHS.Name = "publishingDateLabelRHS";
            publishingDateLabelRHS.Size = new Size(351, 25);
            publishingDateLabelRHS.TabIndex = 1;
            publishingDateLabelRHS.Text = "March 14, 2024. 15:00 PST";
            publishingDateLabelRHS.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chapterContainer
            // 
            chapterContainer.AutoSize = true;
            chapterContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            chapterContainer.ColumnCount = 2;
            chapterContainer.ColumnStyles.Add(new ColumnStyle());
            chapterContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            chapterContainer.Controls.Add(chapterTitleLabelLHS, 0, 0);
            chapterContainer.Controls.Add(chapterTitleLabelRHS, 1, 0);
            chapterContainer.Dock = DockStyle.Fill;
            chapterContainer.Location = new Point(3, 69);
            chapterContainer.Name = "chapterContainer";
            chapterContainer.RowCount = 1;
            chapterContainer.RowStyles.Add(new RowStyle());
            chapterContainer.Size = new Size(497, 25);
            chapterContainer.TabIndex = 1;
            // 
            // chapterTitleLabelLHS
            // 
            chapterTitleLabelLHS.AutoSize = true;
            chapterTitleLabelLHS.Dock = DockStyle.Fill;
            chapterTitleLabelLHS.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            chapterTitleLabelLHS.Location = new Point(0, 0);
            chapterTitleLabelLHS.Margin = new Padding(0);
            chapterTitleLabelLHS.Name = "chapterTitleLabelLHS";
            chapterTitleLabelLHS.Size = new Size(130, 25);
            chapterTitleLabelLHS.TabIndex = 0;
            chapterTitleLabelLHS.Text = "Chapter Title:";
            chapterTitleLabelLHS.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chapterTitleLabelRHS
            // 
            chapterTitleLabelRHS.AutoSize = true;
            chapterTitleLabelRHS.Dock = DockStyle.Fill;
            chapterTitleLabelRHS.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            chapterTitleLabelRHS.Location = new Point(133, 0);
            chapterTitleLabelRHS.Name = "chapterTitleLabelRHS";
            chapterTitleLabelRHS.Size = new Size(361, 25);
            chapterTitleLabelRHS.TabIndex = 1;
            chapterTitleLabelRHS.Text = "This is a chapter";
            chapterTitleLabelRHS.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // titleContainer
            // 
            titleContainer.AutoSize = true;
            titleContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            titleContainer.ColumnCount = 2;
            titleContainer.ColumnStyles.Add(new ColumnStyle());
            titleContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            titleContainer.Controls.Add(storyTitleLabelLHS, 0, 0);
            titleContainer.Controls.Add(storyTitleLabelRHS, 1, 0);
            titleContainer.Dock = DockStyle.Fill;
            titleContainer.Location = new Point(3, 3);
            titleContainer.Name = "titleContainer";
            titleContainer.RowCount = 1;
            titleContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            titleContainer.Size = new Size(497, 60);
            titleContainer.TabIndex = 0;
            // 
            // storyTitleLabelLHS
            // 
            storyTitleLabelLHS.AutoSize = true;
            storyTitleLabelLHS.Dock = DockStyle.Fill;
            storyTitleLabelLHS.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            storyTitleLabelLHS.Location = new Point(0, 0);
            storyTitleLabelLHS.Margin = new Padding(0);
            storyTitleLabelLHS.Name = "storyTitleLabelLHS";
            storyTitleLabelLHS.Size = new Size(98, 60);
            storyTitleLabelLHS.TabIndex = 0;
            storyTitleLabelLHS.Text = "Story:";
            storyTitleLabelLHS.TextAlign = ContentAlignment.MiddleRight;
            // 
            // storyTitleLabelRHS
            // 
            storyTitleLabelRHS.AutoSize = true;
            storyTitleLabelRHS.Dock = DockStyle.Fill;
            storyTitleLabelRHS.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            storyTitleLabelRHS.Location = new Point(101, 0);
            storyTitleLabelRHS.Name = "storyTitleLabelRHS";
            storyTitleLabelRHS.Size = new Size(393, 60);
            storyTitleLabelRHS.TabIndex = 1;
            storyTitleLabelRHS.Text = "This is a story with a really long title so long in fact it overflows";
            storyTitleLabelRHS.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // editButton
            // 
            editButton.Anchor = AnchorStyles.None;
            editButton.BackgroundImage = (Image)resources.GetObject("editButton.BackgroundImage");
            editButton.BackgroundImageLayout = ImageLayout.Stretch;
            editButton.FlatAppearance.BorderSize = 0;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.Location = new Point(548, 39);
            editButton.Name = "editButton";
            editButton.Size = new Size(72, 72);
            editButton.TabIndex = 1;
            editButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label5, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(130, 25);
            label5.TabIndex = 0;
            label5.Text = "Chapter Title:";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(133, 0);
            label6.Name = "label6";
            label6.Size = new Size(452, 100);
            label6.TabIndex = 1;
            label6.Text = "Chapter 3";
            // 
            // StoryListItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(outerContainerLayout);
            Controls.Add(detailPanel);
            Name = "StoryListItem";
            Size = new Size(809, 150);
            detailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            outerContainerLayout.ResumeLayout(false);
            innerElementsContainer.ResumeLayout(false);
            innerElementsContainer.PerformLayout();
            dateContainer.ResumeLayout(false);
            dateContainer.PerformLayout();
            chapterContainer.ResumeLayout(false);
            chapterContainer.PerformLayout();
            titleContainer.ResumeLayout(false);
            titleContainer.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel detailPanel;
        private TableLayoutPanel outerContainerLayout;
        private TableLayoutPanel innerElementsContainer;
        private TableLayoutPanel titleContainer;
        private Label storyTitleLabelLHS;
        private Label storyTitleLabelRHS;
        private TableLayoutPanel dateContainer;
        private Label publishingDateLabelLHS;
        private Label publishingDateLabelRHS;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label5;
        private Label label6;
        private TableLayoutPanel chapterContainer;
        private Label chapterTitleLabelLHS;
        private Label chapterTitleLabelRHS;
        private Button editButton;
        private PictureBox pictureBox1;
    }
}
