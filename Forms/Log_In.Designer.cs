namespace SchoolDB.Forms
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.buttonEnter = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Icon = new System.Windows.Forms.PictureBox();
            this.pictureEye = new System.Windows.Forms.PictureBox();
            this.pictureEyef = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEyef)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEnter
            // 
            this.buttonEnter.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEnter.Location = new System.Drawing.Point(159, 273);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(196, 58);
            this.buttonEnter.TabIndex = 0;
            this.buttonEnter.Text = "Войти";
            this.buttonEnter.UseVisualStyleBackColor = false;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPassword.Location = new System.Drawing.Point(207, 213);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(148, 34);
            this.textPassword.TabIndex = 1;
            // 
            // textLogin
            // 
            this.textLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogin.Location = new System.Drawing.Point(207, 154);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(148, 34);
            this.textLogin.TabIndex = 2;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(100, 154);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(101, 32);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Логин:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(80, 215);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(121, 32);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(86, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(424, 102);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(152, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 42);
            this.label1.TabIndex = 7;
            this.label1.Text = "Авторизация";
            // 
            // Icon
            // 
            this.Icon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Icon.BackgroundImage")));
            this.Icon.Location = new System.Drawing.Point(1, -1);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(101, 93);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Icon.TabIndex = 8;
            this.Icon.TabStop = false;
            // 
            // pictureEye
            // 
            this.pictureEye.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureEye.BackgroundImage")));
            this.pictureEye.Location = new System.Drawing.Point(371, 198);
            this.pictureEye.Name = "pictureEye";
            this.pictureEye.Size = new System.Drawing.Size(57, 49);
            this.pictureEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureEye.TabIndex = 9;
            this.pictureEye.TabStop = false;
            this.pictureEye.Click += new System.EventHandler(this.pictureEye_Click);
            // 
            // pictureEyef
            // 
            this.pictureEyef.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureEyef.BackgroundImage")));
            this.pictureEyef.Location = new System.Drawing.Point(371, 198);
            this.pictureEyef.Name = "pictureEyef";
            this.pictureEyef.Size = new System.Drawing.Size(56, 48);
            this.pictureEyef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureEyef.TabIndex = 10;
            this.pictureEyef.TabStop = false;
            this.pictureEyef.Click += new System.EventHandler(this.pictureEyef_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 394);
            this.Controls.Add(this.pictureEyef);
            this.Controls.Add(this.pictureEye);
            this.Controls.Add(this.Icon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.buttonEnter);
            this.Name = "LogIn";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Вход в систему";
            this.Load += new System.EventHandler(this.LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEyef)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Icon;
        private System.Windows.Forms.PictureBox pictureEye;
        private System.Windows.Forms.PictureBox pictureEyef;
    }
}