using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class Marks : Form
    {
        DataBase dataBase = new DataBase();

        public int selectedSubject;
        public int selectedRow;


        public Marks()
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
            dataGridViewMark.Columns.Add("StudentID", "ID учащегося");
            dataGridViewMark.Columns.Add("Date", "Дата");
            dataGridViewMark.Columns.Add("Grade", "Оценка");
            dataGridViewMark.Columns.Add("TypeOfMark", "Тип оценки");
            dataGridViewMark.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetDateTime(2), record.GetInt32(3),record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select Mark.ID, StudentID, Date,Grade, TypeofMark.Name from Mark,TypeOfMark where SubjectID={selectedSubject} and TypeOfMark.ID=TypeOfMarkID";

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
            string searchString = $"select Mark.ID,StudentID, Date,Grade, TypeofMark.Name from Mark,TypeOfMark where SubjectID={selectedSubject} and TypeOfMark.ID=TypeOfMarkID and concat (StudentID, Grade, TypeOfMark.Name) like '%" + str + "%'";

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

        private void DeleteRow()
        {
            if (dataGridViewMark.Rows.Count > 0)
            {
                int index = dataGridViewMark.CurrentCell.RowIndex;

                dataGridViewMark.Rows[index].Visible = false;

                if (dataGridViewMark.Rows[index].Cells[0].Value.ToString() == String.Empty)
                {
                    dataGridViewMark.Rows[index].Cells[dataGridViewMark.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
                    return;
                }
                dataGridViewMark.Rows[index].Cells[dataGridViewMark.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
            }
        }
        private void Update()
        {
            dataBase.OpenConnection();
            for (int i = 0; i < dataGridViewMark.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridViewMark.Rows[i].Cells[dataGridViewMark.Rows[i].Cells.Count - 1].Value;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridViewMark.Rows[i].Cells[0].Value);
                    var deleteQuery = $"Delete from Mark where ID={id}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());

                    command.ExecuteNonQuery();

                }
            }
            dataBase.CloseConnection();
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            EditMark addM = new EditMark();
            addM.selectedStudent= (int)dataGridViewMark.Rows[selectedRow].Cells[1].Value;
            addM.selectedSubject = selectedSubject;
            addM.Show();

        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                DeleteRow();
                Update();
            }
        }

        private void dataGridViewMark_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMark.Rows[selectedRow];
                EditMark changeM = new EditMark((int)row.Cells[3].Value, row.Cells[2].Value.ToString(),row.Cells[4].Value.ToString(), (int)row.Cells[1].Value, (int)row.Cells[0].Value);
                changeM.selectedStudent = (int)dataGridViewMark.Rows[selectedRow].Cells[1].Value;
                changeM.selectedSubject = selectedSubject;
                changeM.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MarkHistory mH = new MarkHistory();
            mH.selectedSubject = selectedSubject;
            mH.Show();
        }
    }
}
