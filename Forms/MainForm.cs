using SchoolDB.Forms;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolDB
{
    enum RowState
    {
        Existed,
        New, 
        Deleted, 
        Modified,
        ModifiedNew
    }

    public partial class MainForm : Form
    {
        DataBase dataBase = new DataBase();

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void классыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classes c1 = new Classes();
            this.Hide();
            c1.ShowDialog();
            this.Show();

        }

        private void учителяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teachers teachers = new Teachers();
            this.Hide();
            teachers.ShowDialog();
            this.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.SelectedPath;
                string db = dataBase.GetConnection().Database.ToString();
                string cmd = "BACKUP DATABASE [" + db + "] TO DISK = '" + path + "\\SchoolDBBackup.bak'";
                dataBase.OpenConnection();
                SqlCommand command = new SqlCommand(cmd, dataBase.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Сохранение прошло успешно!");
                dataBase.CloseConnection();
            }
        }

        private void восстановитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "Все файлы.bak";
            dlg.Title = "Восстановление базы данных";
            if(dlg.ShowDialog()== DialogResult.OK)
            {
                string fileName=dlg.FileName;
                string db = dataBase.GetConnection().Database.ToString();
                dataBase.OpenConnection();
                try
                {
                    string str1 = string.Format("ALTER DATABASE [" + db + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand command = new SqlCommand(str1, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                    string str2 = "USE MASTER RESTORE DATABASE [" + db + "] FROM DISK = '" + fileName + "' WITH REPLACE;";

                    SqlCommand cmd = new SqlCommand(str2, dataBase.GetConnection());
                    cmd.ExecuteNonQuery();

                    string str3 = string.Format("ALTER DATABASE [" + db + "] SET MULTI_USER");
                    SqlCommand cmd1 = new SqlCommand(str3, dataBase.GetConnection());
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Восстановление прошло успешно!");
                    dataBase.CloseConnection();
                }
                catch
                {

                }
            }
        }
    }
}
