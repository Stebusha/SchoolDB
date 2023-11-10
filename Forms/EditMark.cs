using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class EditMark : Form
    {
        DataBase dataBase = new DataBase();
        public int selectedStudent;
        public int selectedSubject;
        int rowId;
        public EditMark()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        public EditMark(int grade,string date, string type, int id, int rid)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBoxGrade.Text = grade.ToString();
            textBoxIdStudent.Text = id.ToString();
            selectedStudent = id;
            textBoxType.Text = type.ToString();
            dateTimePickerDate.Value = DateTime.Parse(date);
            buttonSave.Text = "Change";
            rowId = rid;
        }

        private int GetTypeID(string str)
        {
            switch (str)
            {
                case "I четверть":
                    return 1;
                case "II четверть":
                    return 2;
                case "III четверть":
                    return 3;

                case "IV четверть":
                    return 4;

                case "Текущая":
                    return 6;

                case "Итоговая":
                    return 5;
            }
            return -1;
        }
       private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();
            var grade = Convert.ToInt32(textBoxGrade.Text);
            var typeName = textBoxType.Text;
            int typeID = GetTypeID(typeName);
  
            var date = dateTimePickerDate.Value.ToShortDateString();
            if (buttonSave.Text != "Change")
            {
                if (grade>=2&&grade<6 && date!= "" && typeID>0 && typeID<7)
                {
                    var addQuery = $"insert into Mark (StudentID,SubjectID,Grade,Date, TypeOfMarkID) values({selectedStudent},{selectedSubject},{grade},'{date}',{typeID})";
                    var Command = new SqlCommand(addQuery, dataBase.GetConnection());
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Проверьте введеные данные и/или заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var changeQuery = $"update Mark set StudentID = {selectedStudent}, SubjectID={selectedSubject}, Grade={grade}, Date = '{date}',TypeOfMarkID = {typeID} where ID={rowId}";
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

        private void EditMark_Load(object sender, EventArgs e)
        {
            textBoxGrade.MaxLength = 1;
            textBoxIdStudent.MaxLength = 5;
            textBoxType.MaxLength = 15;
        }
    }
}
