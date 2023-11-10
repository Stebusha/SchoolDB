using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class SubjectsForStudent : Form
    {
        DataBase dataBase = new DataBase();

        public int selectedStudent;
        public int selectedClass;
        int selectedRow;

        public SubjectsForStudent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewSubjectsForStudent);
        }

        private void dataGridViewSubjectsForStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSubjectsForStudent.Rows[selectedRow];
                MarksForStudent marks = new MarksForStudent();
                marks.selectedStudent = selectedStudent;
                marks.selectedRow = (int)dataGridViewSubjectsForStudent.Rows[selectedRow].Cells[0].Value;
                marks.Text = dataGridViewSubjectsForStudent.Rows[selectedRow].Cells[1].Value.ToString();
                marks.Show();
            }

        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewSubjectsForStudent);
        }

        private void SubjectsForStudent_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewSubjectsForStudent);
            dataGridViewSubjectsForStudent.Columns[dataGridViewSubjectsForStudent.ColumnCount - 1].Visible = false;

        }

        private void CreateColumns()
        {
            dataGridViewSubjectsForStudent.Columns.Add("ID", "ID");
            dataGridViewSubjectsForStudent.Columns.Add("Name", "Название");
            dataGridViewSubjectsForStudent.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select ID, Name,Hours from Subject where ClassID ='{selectedClass}'";

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
            string searchString = $"select ID, Name,Hours from Subject where ClassID = {selectedClass} and concat (Name, ID) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }


    }
}
