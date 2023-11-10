using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class SubjectHistory : Form
    {
        DataBase dataBase = new DataBase();
        public int selectedTeacher;
        public SubjectHistory()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewHistory);
        }

        private void SubjectHistory_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewHistory);
        }
        private void CreateColumns()
        {
            dataGridViewHistory.Columns.Add("ID", "ID");
            dataGridViewHistory.Columns.Add("Name", "Название");
            dataGridViewHistory.Columns.Add("Hours", "Количество часов");
            dataGridViewHistory.Columns.Add("ClassID", "Класс ID");
            dataGridViewHistory.Columns.Add("SysStartTime", "Дата добавления");
            dataGridViewHistory.Columns.Add("SysEndTime", "Дата изменения");
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetDateTime(4), record.GetDateTime(5));
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select ID,Name,Hours,ClassID, SysStartTime,SysEndTime from SubjectHistory where TeacherID={selectedTeacher}";

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
            string searchString = $"select ID,Name,Hours,ClassID, SysStartTime,SysEndTime from SubjectHistory where TeacherID={selectedTeacher} and concat (ID, Name, SysStartTime, SysEndTime) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
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
            string str2 = $"select * into ##Rollback from [dbo].[SubjectHistory] where SysEndTime = '{current}'";
            SqlCommand c2 = new SqlCommand(str2, dataBase.GetConnection());
            c2.ExecuteNonQuery();
            string str3 = " alter table[dbo].[Subject] set(system_versioning = off); set identity_insert[dbo].[Subject] on;";
            SqlCommand c3 = new SqlCommand(str3, dataBase.GetConnection());
            c3.ExecuteNonQuery();
            string str4 = "delete from[dbo].[Subject] where ID = (select distinct ID from ##Rollback)";
            SqlCommand c4 = new SqlCommand(str4, dataBase.GetConnection());
            c4.ExecuteNonQuery();
            string str5 = "insert into [dbo].[Subject] (ID,Name,Hours,ClassID,TeacherID) select ID,Name,Hours,ClassID,TeacherID from ##Rollback";
            SqlCommand c5 = new SqlCommand(str5, dataBase.GetConnection());
            c5.ExecuteNonQuery();
            string str6 = $"delete from[dbo].[SubjectHistory] where SysEndTime = '{current}'";
            SqlCommand c6 = new SqlCommand(str6, dataBase.GetConnection());
            c6.ExecuteNonQuery();
            string str7 = "alter table [dbo].[Subject] set(system_versioning = on(history_table=[dbo].[SubjectHistory])); set identity_insert [dbo].[Subject] off;";
            SqlCommand c7 = new SqlCommand(str7, dataBase.GetConnection());
            c7.ExecuteNonQuery();
            RefreshDataGridView(dataGridViewHistory);

        }
    }
}
