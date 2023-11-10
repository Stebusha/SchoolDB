using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class EditStudent : Form
    {
        DataBase dataBase = new DataBase();
        public int countOfStudents;
        public string nameClass;
        public int selectedClass;
        public int rowId;
        public EditStudent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public EditStudent(string textLast, string textFirst, string textMiddle, string born,string textPhone, int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBoxFirst.Text = textFirst;
            textBoxMiddle.Text = textMiddle;
            textBoxLast.Text = textLast;    
            textBoxPhone.Text = textPhone;
            dateTimePickerBorn.Value= DateTime.Parse(born);
            buttonSave.Text = "Change";
            rowId=id;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();
            var first = textBoxFirst.Text;
            var middle = textBoxMiddle.Text;
            var last = textBoxLast.Text;
            var born = dateTimePickerBorn.Value.ToShortDateString();
            var phone = textBoxPhone.Text;
            if (buttonSave.Text != "Change")
            {
                if (first != "" && middle != "" && last != "" && phone != "")
                {
                    var addQuery = $"insert into Student (ClassId, FirstName,MiddleName,LastName,BirthDate, Phone, Login, Password) values({selectedClass},'{first}','{middle}','{last}','{born}','{phone}','{last}','{nameClass}')";
                    var Command = new SqlCommand(addQuery, dataBase.GetConnection());
                    Command.ExecuteNonQuery();
                    var changeCountOfStudents = $"update Class set Number_of_students = {countOfStudents+1} where ID={selectedClass}";
                    var commandChange = new SqlCommand(changeCountOfStudents, dataBase.GetConnection());
                    commandChange.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Проверьте введеные данные и/или заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var changeQuery = $"update Student set FirstName = '{first}', MiddleName='{middle}', LastName='{last}', BirthDate = '{born}', Phone = '{phone}' where ID={rowId}";
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

        private void EditStudent_Load(object sender, EventArgs e)
        {
            textBoxFirst.MaxLength = 60;
            textBoxLast.MaxLength = 60;
            textBoxMiddle.MaxLength= 60;
            textBoxPhone.MaxLength = 12;
        }
    }
}
