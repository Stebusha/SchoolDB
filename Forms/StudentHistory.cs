using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{

    public partial class StudentHistory : Form
    {
        DataBase dataBase = new DataBase();

        public int selectedClass;

        public StudentHistory()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewHistory);
        }
        private void CreateColumns()
        {
            dataGridViewHistory.Columns.Add("ID", "ID");
            dataGridViewHistory.Columns.Add("LastName", "Фамилия");
            dataGridViewHistory.Columns.Add("FirstName", "Имя");
            dataGridViewHistory.Columns.Add("MiddleName", "Отчество");
            dataGridViewHistory.Columns.Add("BirthDate", "Дата рождения");
            dataGridViewHistory.Columns.Add("Phone", "Телефон");
            dataGridViewHistory.Columns.Add("SysStartTime", "Дата добавления");
            dataGridViewHistory.Columns.Add("SysEndTime", "Дата изменения");
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5), record.GetDateTime(6), record.GetDateTime(7));
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select ID,LastName,FirstName,MiddleName,BirthDate,Phone,SysStartTime,SysEndTime from StudentHistory where ClassId={selectedClass}";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }

            reader.Close();
        }


        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var str = toolStripTextBoxSearch.Text;
            string searchString = $"select ID,LastName,FirstName,MiddleName,BirthDate,Phone,SysStartTime,SysEndTime from StudentHistory where ClassId={selectedClass} and concat (ID, LastName, SysStartTime, SysEndTime) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void StudentHistory_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewHistory);
        }

        private void dataGridViewHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dataGridViewHistory.CurrentCell.RowIndex;
            string current = "";
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridViewHistory.Rows[selectedRow];
                current = row.Cells[row.Cells.Count - 1].Value.ToString();
            }

            string str1 = "drop table if exists ##Rollback";
            SqlCommand c1 = new SqlCommand(str1, dataBase.GetConnection());
            c1.ExecuteNonQuery();
            string str2 = $"select * into ##Rollback from [dbo].[StudentHistory] where SysEndTime = '{current}'";
            SqlCommand c2 = new SqlCommand(str2, dataBase.GetConnection());
            c2.ExecuteNonQuery();
            string str3 = "alter table[dbo].[Student] set(system_versioning = off); set identity_insert[dbo].[Student] on;";
            SqlCommand c3 = new SqlCommand(str3, dataBase.GetConnection());
            c3.ExecuteNonQuery();
            string str4 = "delete from[dbo].[Student] where ID = (select distinct ID from ##Rollback)";
            SqlCommand c4 = new SqlCommand(str4, dataBase.GetConnection());
            c4.ExecuteNonQuery();
            string str5 = "insert into [dbo].[Student] (ID,ClassID,FirstName,MiddleName,LastName,BirthDate,Phone,Login,Password) select ID,ClassID,FirstName,MiddleName,LastName,BirthDate,Phone,Login,Password from ##Rollback";
            SqlCommand c5 = new SqlCommand(str5, dataBase.GetConnection());
            c5.ExecuteNonQuery();
            string str6 = $"delete from[dbo].[StudentHistory] where SysEndTime = '{current}'";
            SqlCommand c6 = new SqlCommand(str6, dataBase.GetConnection());
            c6.ExecuteNonQuery();
            string str7 = "alter table [dbo].[Student] set(system_versioning = on(history_table=[dbo].[StudentHistory])); set identity_insert [dbo].[Student] off;";
            SqlCommand c7 = new SqlCommand(str7, dataBase.GetConnection());
            c7.ExecuteNonQuery();
            RefreshDataGridView(dataGridViewHistory);

        }
    }
}
