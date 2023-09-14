namespace AO3SchedulerWin.GUI.Forms
{
    partial class Ao3LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ao3LoginForm));
            userTextBox = new TextBox();
            passwordTextbox = new TextBox();
            loginButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // userTextBox
            // 
            userTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            userTextBox.Location = new Point(17, 345);
            userTextBox.Margin = new Padding(4, 5, 4, 5);
            userTextBox.Name = "userTextBox";
            userTextBox.PlaceholderText = "Email / Username";
            userTextBox.Size = new Size(494, 31);
            userTextBox.TabIndex = 0;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordTextbox.Location = new Point(17, 393);
            passwordTextbox.Margin = new Padding(4, 5, 4, 5);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.PlaceholderText = "Password";
            passwordTextbox.Size = new Size(494, 31);
            passwordTextbox.TabIndex = 1;
            passwordTextbox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginButton.BackColor = Color.FromArgb(153, 0, 0);
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(17, 677);
            loginButton.Margin = new Padding(4, 5, 4, 5);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(496, 88);
            loginButton.TabIndex = 2;
            loginButton.Text = "Log In";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(17, 190);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(496, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Ao3LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 785);
            Controls.Add(pictureBox1);
            Controls.Add(loginButton);
            Controls.Add(passwordTextbox);
            Controls.Add(userTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Ao3LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userTextBox;
        private TextBox passwordTextbox;
        private Button loginButton;
        private PictureBox pictureBox1;
    }
}