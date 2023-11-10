using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class MarksForStudent : Form
    {
        DataBase dataBase = new DataBase();

        public int selectedStudent;
        public int selectedClass;
        public int selectedRow;

        public MarksForStudent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewMark);

        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewMark);

        }

        private void CreateColumns()
        {
            dataGridViewMark.Columns.Add("ID", "ID");
            dataGridViewMark.Columns.Add("Date", "Дата");
            dataGridViewMark.Columns.Add("Grade", "Оценка");
            dataGridViewMark.Columns.Add("TypeOfMark", "Тип оценки");
            dataGridViewMark.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetDateTime(1),record.GetInt32(2),record.GetString(3), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select Mark.ID, Date,Grade, TypeofMark.Name from Mark,TypeOfMark where StudentID ={selectedStudent} and SubjectID={selectedRow} and TypeOfMark.ID=TypeOfMarkID";

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
            string searchString = $"select Mark.ID, Date,Grade, TypeofMark.Name from Mark,TypeOfMark where StudentID ={selectedStudent} and SubjectID={selectedRow} and TypeOfMark.ID=TypeOfMarkID and concat (Grade, TypeOfMark.Name) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void MarksForStudent_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewMark);
            dataGridViewMark.Columns[dataGridViewMark.ColumnCount - 1].Visible = false;

        }
    }
}
