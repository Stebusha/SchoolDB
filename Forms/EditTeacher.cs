using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class EditTeacher : Form
    {
        DataBase dataBase = new DataBase();
        public int countOfStudents;
        public string nameClass;
        public int selectedClass;
        public int rowId;

        public EditTeacher()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public EditTeacher(string textLast, string textFirst, string textMiddle, string born, string textPhone,string textQualification, int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBoxFirst.Text = textFirst;
            textBoxMiddle.Text = textMiddle;
            textBoxLast.Text = textLast;
            textBoxPhone.Text = textPhone;
            dateTimePickerBorn.Value = DateTime.Parse(born);
            textBoxQualification.Text = textQualification;
            buttonSave.Text = "Change";
            rowId = id;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();
            var first = textBoxFirst.Text;
            var middle = textBoxMiddle.Text;
            var last = textBoxLast.Text;
            var born = dateTimePickerBorn.Value.ToShortDateString();
            var phone = textBoxPhone.Text;
            var qualification = textBoxQualification.Text;
            if (buttonSave.Text != "Change")
            {
                if (first != "" && middle != "" && last != "" && phone != "")
                {
                    var addQuery = $"insert into Teacher (FirstName,MiddleName,LastName,BirthDate, Phone,Qualification, Login, Password) values('{first}','{middle}','{last}','{born}','{phone}','{qualification}','{last}','Учитель{last}')";
                    var Command = new SqlCommand(addQuery, dataBase.GetConnection());
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Проверьте введеные данные и/или заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var changeQuery = $"update Teacher set FirstName = '{first}', MiddleName='{middle}', LastName='{last}', BirthDate = '{born}', Phone = '{phone}' , Qualification = '{qualification}' where ID={rowId}";
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

        private void EditTeacher_Load(object sender, EventArgs e)
        {
            textBoxPhone.MaxLength = 20;
            textBoxFirst.MaxLength = 60;
            textBoxLast.MaxLength = 60;
            textBoxMiddle.MaxLength = 60;
            textBoxQualification.MaxLength = 60;
        }
    }
}
