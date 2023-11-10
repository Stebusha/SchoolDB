using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolDB.Forms
{
    public partial class LogIn : Form
    {
        DataBase dataBase = new DataBase();
        public LogIn()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textLogin.Text;
            var passwordUser = textPassword.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable tableStudent = new DataTable();
            DataTable tableTeacher = new DataTable();

            string queryStringAdmin = $"select * from register where LoginUser = '{loginUser}' and PasswordUser = '{passwordUser}'";

            string queryStringTeacher = $"select * from Teacher where Login = '{loginUser}' and Password = '{passwordUser}'";

            string queryStringStudent = $"select * from Student where Login = '{loginUser}' and Password = '{passwordUser}'";

            SqlCommand command = new SqlCommand(queryStringAdmin,dataBase.GetConnection());
            SqlCommand commandTeacher = new SqlCommand(queryStringTeacher, dataBase.GetConnection());
            SqlCommand commandStudent = new SqlCommand(queryStringStudent, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            adapter.SelectCommand = commandTeacher;
            adapter.Fill(tableTeacher);
            adapter.SelectCommand = commandStudent;
            adapter.Fill(tableStudent);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вход прошел успешно!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm f1 = new MainForm();
                this.Hide();
                f1.ShowDialog();
                this.Show();
            }
            else if (tableTeacher.Rows.Count==1)
            {
                MessageBox.Show("Вход прошел успешно!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubjectsForTeacher subjects = new SubjectsForTeacher();
                subjects.selectedTeacher =Convert.ToInt32(tableTeacher.Rows[0][0].ToString());
                this.Hide();
                subjects.ShowDialog();
                this.Show();

            }
            else if (tableStudent.Rows.Count == 1)
            {
                MessageBox.Show("Вход прошел успешно!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubjectsForStudent subjects = new SubjectsForStudent();
                subjects.selectedStudent =Convert.ToInt32(tableStudent.Rows[0][0].ToString());
                subjects.selectedClass = Convert.ToInt32(tableStudent.Rows[0][1].ToString());
                this.Hide();
                subjects.ShowDialog();
                this.Show();

            }
            else
                MessageBox.Show("Неправильный логин и/или пароль!", "Ошибка аккаунта!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void pictureEye_Click(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = true;
            pictureEye.Visible = false;
            pictureEyef.Visible = true;
        }

        private void pictureEyef_Click(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = false;
            pictureEye.Visible = true;
            pictureEyef.Visible = false;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = true;
            pictureEye.Visible = false;
            textLogin.MaxLength = 20;
            textPassword.MaxLength = 20;
            textLogin.Text = "";
            textPassword.Text = "";

        }
    }
}
