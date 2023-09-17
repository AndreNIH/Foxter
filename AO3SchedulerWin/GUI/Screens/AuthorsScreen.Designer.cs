namespace AO3SchedulerWin.GUI.Screens
{
    partial class AuthorsScreen
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
            panel1 = new Panel();
            setActiveButton = new Button();
            button3 = new Button();
            removeAccountButton = new Button();
            addAccountButton = new Button();
            panel2 = new Panel();
            userLabel = new Label();
            usersListView = new ListView();
            columnHeader1 = new ColumnHeader();
            loggedAsLabel = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(setActiveButton);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(removeAccountButton);
            panel1.Controls.Add(addAccountButton);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(656, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(144, 450);
            panel1.TabIndex = 0;
            // 
            // setActiveButton
            // 
            setActiveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            setActiveButton.Location = new Point(13, 177);
            setActiveButton.Name = "setActiveButton";
            setActiveButton.Size = new Size(119, 49);
            setActiveButton.TabIndex = 3;
            setActiveButton.Text = "Set as active";
            setActiveButton.UseVisualStyleBackColor = true;
            setActiveButton.Click += setActiveButton_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(13, 122);
            button3.Name = "button3";
            button3.Size = new Size(119, 49);
            button3.TabIndex = 2;
            button3.Text = "Update account";
            button3.UseVisualStyleBackColor = true;
            // 
            // removeAccountButton
            // 
            removeAccountButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeAccountButton.Location = new Point(13, 67);
            removeAccountButton.Name = "removeAccountButton";
            removeAccountButton.Size = new Size(119, 49);
            removeAccountButton.TabIndex = 1;
            removeAccountButton.Text = "Remove account";
            removeAccountButton.UseVisualStyleBackColor = true;
            removeAccountButton.Click += removeAccountButton_Click;
            // 
            // addAccountButton
            // 
            addAccountButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addAccountButton.Location = new Point(13, 12);
            addAccountButton.Name = "addAccountButton";
            addAccountButton.Size = new Size(119, 49);
            addAccountButton.TabIndex = 0;
            addAccountButton.Text = "Add account";
            addAccountButton.UseVisualStyleBackColor = true;
            addAccountButton.Click += addAccountButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(userLabel);
            panel2.Controls.Add(usersListView);
            panel2.Controls.Add(loggedAsLabel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(656, 450);
            panel2.TabIndex = 1;
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            userLabel.Location = new Point(150, 10);
            userLabel.Margin = new Padding(2, 0, 2, 0);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(121, 30);
            userLabel.TabIndex = 2;
            userLabel.Text = "Placeholder";
            // 
            // usersListView
            // 
            usersListView.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            usersListView.Dock = DockStyle.Fill;
            usersListView.FullRowSelect = true;
            usersListView.Location = new Point(10, 46);
            usersListView.Name = "usersListView";
            usersListView.Size = new Size(636, 394);
            usersListView.TabIndex = 0;
            usersListView.UseCompatibleStateImageBehavior = false;
            usersListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "User";
            columnHeader1.Width = 800;
            // 
            // loggedAsLabel
            // 
            loggedAsLabel.AutoSize = true;
            loggedAsLabel.Dock = DockStyle.Top;
            loggedAsLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            loggedAsLabel.Location = new Point(10, 10);
            loggedAsLabel.Margin = new Padding(2, 0, 2, 0);
            loggedAsLabel.Name = "loggedAsLabel";
            loggedAsLabel.Padding = new Padding(0, 0, 0, 6);
            loggedAsLabel.Size = new Size(136, 36);
            loggedAsLabel.TabIndex = 1;
            loggedAsLabel.Text = "Logged in as:";
            // 
            // AuthorsScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AuthorsScreen";
            Text = "AuthorsScreen";
            Load += AuthorsScreen_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button setActiveButton;
        private Button button3;
        private Button removeAccountButton;
        private Button addAccountButton;
        private Panel panel2;
        private ListView usersListView;
        private ColumnHeader columnHeader1;
        private Label loggedAsLabel;
        private Label userLabel;
    }
}