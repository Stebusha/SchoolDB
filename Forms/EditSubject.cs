using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class EditSubject : Form
    {
        DataBase dataBase = new DataBase();
        int rowId;
        public int selectedTeacher;

        public EditSubject()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public EditSubject(string textName, string hours, string ClId, int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBoxName.Text = textName;
            textBoxHours.Text = hours.ToString();
            textBoxClassID.Text = ClId;
            buttonSave.Text = "Change";
            rowId = id;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();
            var name = textBoxName.Text;
            var hours = Convert.ToInt32(textBoxHours.Text);
            var clId = Convert.ToInt32(textBoxClassID.Text);
            if (buttonSave.Text != "Change")
            {
                if (name != "" && hours > 0 && clId >=0)
                {
                    var addQuery = $"insert into Subject (Name,Hours,ClassID,TeacherID) values('{name}',{hours},{clId},{selectedTeacher})";
                    var Command = new SqlCommand(addQuery, dataBase.GetConnection());
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Проверьте введеные данные и/или заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var changeQuery = $"update Subject set Name = '{name}', Hours={hours}, ClassID={clId} where ID={rowId}";
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

        private void EditSubject_Load(object sender, EventArgs e)
        {
            textBoxClassID.MaxLength = 5;
            textBoxHours.MaxLength = 3;
            textBoxName.MaxLength = 60;
        }
    }
}
