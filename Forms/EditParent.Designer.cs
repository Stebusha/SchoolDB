namespace SchoolDB.Forms
{
    partial class EditParent
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
            this.textBoxJob = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dateTimePickerBorn = new System.Windows.Forms.DateTimePicker();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxMiddle = new System.Windows.Forms.TextBox();
            this.textBoxFirst = new System.Windows.Forms.TextBox();
            this.textBoxLast = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.Label();
            this.Born = new System.Windows.Forms.Label();
            this.Middle = new System.Windows.Forms.Label();
            this.First = new System.Windows.Forms.Label();
            this.Last = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIDStudent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxJob
            // 
            this.textBoxJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJob.Location = new System.Drawing.Point(234, 413);
            this.textBoxJob.Name = "textBoxJob";
            this.textBoxJob.Size = new System.Drawing.Size(200, 34);
            this.textBoxJob.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "Место работы:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(423, 483);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 33);
            this.buttonCancel.TabIndex = 37;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(296, 483);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(101, 33);
            this.buttonSave.TabIndex = 36;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dateTimePickerBorn
            // 
            this.dateTimePickerBorn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerBorn.Location = new System.Drawing.Point(234, 212);
            this.dateTimePickerBorn.Name = "dateTimePickerBorn";
            this.dateTimePickerBorn.Size = new System.Drawing.Size(263, 34);
            this.dateTimePickerBorn.TabIndex = 35;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPhone.Location = new System.Drawing.Point(234, 353);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(200, 34);
            this.textBoxPhone.TabIndex = 34;
            // 
            // textBoxMiddle
            // 
            this.textBoxMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMiddle.Location = new System.Drawing.Point(234, 146);
            this.textBoxMiddle.Name = "textBoxMiddle";
            this.textBoxMiddle.Size = new System.Drawing.Size(200, 34);
            this.textBoxMiddle.TabIndex = 33;
            // 
            // textBoxFirst
            // 
            this.textBoxFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFirst.Location = new System.Drawing.Point(234, 76);
            this.textBoxFirst.Name = "textBoxFirst";
            this.textBoxFirst.Size = new System.Drawing.Size(200, 34);
            this.textBoxFirst.TabIndex = 32;
            // 
            // textBoxLast
            // 
            this.textBoxLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLast.Location = new System.Drawing.Point(234, 20);
            this.textBoxLast.Name = "textBoxLast";
            this.textBoxLast.Size = new System.Drawing.Size(200, 34);
            this.textBoxLast.TabIndex = 31;
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Phone.Location = new System.Drawing.Point(85, 356);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(125, 29);
            this.Phone.TabIndex = 30;
            this.Phone.Text = "Телефон:";
            // 
            // Born
            // 
            this.Born.AutoSize = true;
            this.Born.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Born.Location = new System.Drawing.Point(29, 217);
            this.Born.Name = "Born";
            this.Born.Size = new System.Drawing.Size(199, 29);
            this.Born.TabIndex = 29;
            this.Born.Text = "Дата рождения:";
            // 
            // Middle
            // 
            this.Middle.AutoSize = true;
            this.Middle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Middle.Location = new System.Drawing.Point(82, 146);
            this.Middle.Name = "Middle";
            this.Middle.Size = new System.Drawing.Size(128, 29);
            this.Middle.TabIndex = 28;
            this.Middle.Text = "Отчество:";
            // 
            // First
            // 
            this.First.AutoSize = true;
            this.First.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.First.Location = new System.Drawing.Point(140, 76);
            this.First.Name = "First";
            this.First.Size = new System.Drawing.Size(70, 29);
            this.First.TabIndex = 27;
            this.First.Text = "Имя:";
            // 
            // Last
            // 
            this.Last.AutoSize = true;
            this.Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Last.Location = new System.Drawing.Point(80, 20);
            this.Last.Name = "Last";
            this.Last.Size = new System.Drawing.Size(130, 29);
            this.Last.TabIndex = 26;
            this.Last.Text = "Фамилия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(41, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 29);
            this.label2.TabIndex = 40;
            this.label2.Text = "ID учащегося:";
            // 
            // textBoxIDStudent
            // 
            this.textBoxIDStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxIDStudent.Location = new System.Drawing.Point(234, 277);
            this.textBoxIDStudent.Name = "textBoxIDStudent";
            this.textBoxIDStudent.Size = new System.Drawing.Size(200, 34);
            this.textBoxIDStudent.TabIndex = 41;
            // 
            // EditParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 528);
            this.Controls.Add(this.textBoxIDStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxJob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dateTimePickerBorn);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxMiddle);
            this.Controls.Add(this.textBoxFirst);
            this.Controls.Add(this.textBoxLast);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Born);
            this.Controls.Add(this.Middle);
            this.Controls.Add(this.First);
            this.Controls.Add(this.Last);
            this.Name = "EditParent";
            this.Text = "EditParent";
            this.Load += new System.EventHandler(this.EditParent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerBorn;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxMiddle;
        private System.Windows.Forms.TextBox textBoxFirst;
        private System.Windows.Forms.TextBox textBoxLast;
        private System.Windows.Forms.Label Phone;
        private System.Windows.Forms.Label Born;
        private System.Windows.Forms.Label Middle;
        private System.Windows.Forms.Label First;
        private System.Windows.Forms.Label Last;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIDStudent;
    }
}