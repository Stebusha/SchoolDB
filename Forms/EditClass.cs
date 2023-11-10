using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class EditClass : Form
    {
        DataBase dataBase = new DataBase();
        int rowId;

        public EditClass()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public EditClass(string textName, string number, string speciality, int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBoxName.Text = textName;
            textBoxCount.Text = number.ToString();
            textBoxSpeciality.Text = speciality;
            buttonSave.Text = "Change";
            rowId = id;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();
            var name = textBoxName.Text;
            var  number= Convert.ToInt32(textBoxCount.Text);
            var speciality = textBoxSpeciality.Text;
            if (buttonSave.Text != "Change")
            {
                if (name != "" && number >0 && speciality != "" )
                {
                    var addQuery = $"insert into Class (Name,Number_of_students,Speciality) values('{name}',{number},'{speciality}')";
                    var Command = new SqlCommand(addQuery, dataBase.GetConnection());
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Проверьте введеные данные и/или заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var changeQuery = $"update Class set Name = '{name}', Number_of_students='{number}', Speciality='{speciality}' where ID={rowId}";
                var Command = new SqlCommand(changeQuery, dataBase.GetConnection());
                Command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataBase.CloseConnection();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void EditClass_Load(object sender, EventArgs e)
        {
            textBoxCount.MaxLength = 10;
            textBoxName.MaxLength = 10;
            textBoxSpeciality.MaxLength = 60;
        }
    }
}
