using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class Subjects : Form
    {
        DataBase dataBase = new DataBase();

        public int selectedTeacher;
        int selectedRow;

        public Subjects()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewSubjects);
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewSubjects);
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            EditSubject addS=new EditSubject();
            addS.selectedTeacher=selectedTeacher;
            addS.Show();
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result==DialogResult.OK)
            {
                DeleteRow();
                Update();

            }
        }

        private void dataGridViewParents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSubjects.Rows[selectedRow];
                EditSubject changeS = new EditSubject(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), (int)row.Cells[0].Value);
                changeS.Show();
            }

        }

        private void DeleteRow()
        {
            if(dataGridViewSubjects.Rows.Count > 0)
            {
                int index = dataGridViewSubjects.CurrentCell.RowIndex;

                dataGridViewSubjects.Rows[index].Visible = false;

                if (dataGridViewSubjects.Rows[index].Cells[0].Value.ToString() == String.Empty)
                {
                    dataGridViewSubjects.Rows[index].Cells[dataGridViewSubjects.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
                    return;
                }
                dataGridViewSubjects.Rows[index].Cells[dataGridViewSubjects.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
            }
        }
        private void Update()
        {
            dataBase.OpenConnection();
            for (int i = 0; i < dataGridViewSubjects.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridViewSubjects.Rows[i].Cells[dataGridViewSubjects.Rows[i].Cells.Count - 1].Value;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridViewSubjects.Rows[i].Cells[0].Value);
                    var deleteQuery = $"Delete from Subject where ID={id}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());

                    command.ExecuteNonQuery();

                }
            }
            dataBase.CloseConnection();
        }
        private void CreateColumns()
        {
            dataGridViewSubjects.Columns.Add("ID", "ID");
            dataGridViewSubjects.Columns.Add("Name", "Название");
            dataGridViewSubjects.Columns.Add("Hours", "Часы");
            dataGridViewSubjects.Columns.Add("ClassID", "Класс ID");
            dataGridViewSubjects.Columns.Add("Status", String.Empty);
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

        private void Subjects_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewSubjects);
            dataGridViewSubjects.Columns[dataGridViewSubjects.ColumnCount - 1].Visible = false;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SubjectHistory sH=new SubjectHistory();
            sH.selectedTeacher = selectedTeacher;
            sH.Show();
        }
    }
}
