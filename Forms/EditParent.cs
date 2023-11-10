using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class EditParent : Form
    {
        DataBase dataBase = new DataBase();
        public int countOfStudents;
        public string nameClass;
        public int selectedClass;
        public int rowId;

        public EditParent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public EditParent(string textLast, string textFirst, string textMiddle, string born, string textPhone, string textJob, string stId, int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBoxFirst.Text = textFirst;
            textBoxMiddle.Text = textMiddle;
            textBoxLast.Text = textLast;
            textBoxPhone.Text = textPhone;
            dateTimePickerBorn.Value = DateTime.Parse(born);
            textBoxJob.Text = textJob;
            textBoxIDStudent.Text = stId;
            rowId = id;
            buttonSave.Text = "Change";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();
            var first = textBoxFirst.Text;
            var middle = textBoxMiddle.Text;
            var last = textBoxLast.Text;
            var born = dateTimePickerBorn.Value.ToShortDateString();
            var phone = textBoxPhone.Text;
            var stId=Convert.ToInt32(textBoxIDStudent.Text);
            var job = textBoxJob.Text;
            if (buttonSave.Text != "Change")
            {
                if (first != "" && middle != "" && last != "" && phone != "")
                {
                    var addQuery = $"insert into Parent (StudentID, FirstName,MiddleName,LastName,BirthDate, Phone, Job) values({stId},'{first}','{middle}','{last}','{born}','{phone}','{job}')";
                    var Command = new SqlCommand(addQuery, dataBase.GetConnection());
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Проверьте введеные данные и/или заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var changeQuery = $"update Parent set FirstName = '{first}', MiddleName='{middle}', LastName='{last}', BirthDate = '{born}', Phone = '{phone}', Job='{job}', StudentID={stId} where ID={rowId}";
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

        private void EditParent_Load(object sender, EventArgs e)
        {
            textBoxFirst.MaxLength = 60;
            textBoxLast.MaxLength = 60;
            textBoxMiddle.MaxLength = 60;
            textBoxPhone.MaxLength = 12;
            textBoxJob.MaxLength = 100;
            textBoxIDStudent.MaxLength = 5;
        }
    }
}
