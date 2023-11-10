using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class SubjectsForTeacher : Form
    {
        DataBase dataBase = new DataBase();

        public int selectedTeacher;
        int selectedRow;

        public SubjectsForTeacher()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewSubjectsForTeacher);
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewSubjectsForTeacher);
        }


        private void dataGridViewSubjectsForTeacher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSubjectsForTeacher.Rows[selectedRow];
                Marks  marks = new Marks();
                marks.selectedSubject = (int)dataGridViewSubjectsForTeacher.Rows[selectedRow].Cells[0].Value;
                marks.Text = dataGridViewSubjectsForTeacher.Rows[selectedRow].Cells[1].Value.ToString();
                marks.Show();
            }

        }
        private void CreateColumns()
        {
            dataGridViewSubjectsForTeacher.Columns.Add("ID", "ID");
            dataGridViewSubjectsForTeacher.Columns.Add("Name", "Название");
            dataGridViewSubjectsForTeacher.Columns.Add("Hours", "Часы");
            dataGridViewSubjectsForTeacher.Columns.Add("ClassID", "Класс ID");
            dataGridViewSubjectsForTeacher.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select ID, Name,Hours, ClassID from Subject where TeacherID ='{selectedTeacher}'";

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
            string searchString = $"select ID, Name,Hours, ClassID from Subject where TeacherID = {selectedTeacher} and concat (Name, ClassID) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }


        private void SubjectsForTeacher_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewSubjectsForTeacher);
            dataGridViewSubjectsForTeacher.Columns[dataGridViewSubjectsForTeacher.ColumnCount - 1].Visible = false;

        }
    }
}
