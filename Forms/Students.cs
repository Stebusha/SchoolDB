using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class Students : Form
    {
        DataBase dataBase = new DataBase();

        public int selectedClass;
        int selectedRow;
        public Students()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewStudents);
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            EditStudent addS = new EditStudent();
            addS.countOfStudents = dataGridViewStudents.Rows.Count;
            addS.nameClass = Text;
            addS.selectedClass = selectedClass;
            //if (dataGridViewStudents.Rows.Count == 0)
            //    addS.rowId = 0;
            //else
            //    addS.rowId = (int)dataGridViewStudents.Rows[selectedClass].Cells[0].Value;
            addS.Show();
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

        private void DeleteRow()
        {
            int index = dataGridViewStudents.CurrentCell.RowIndex;

            dataGridViewStudents.Rows[index].Visible = false;

            if (dataGridViewStudents.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridViewStudents.Rows[index].Cells[dataGridViewStudents.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
                return;
            }

            dataGridViewStudents.Rows[index].Cells[dataGridViewStudents.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
        }
        private void Update()
        {
            dataBase.OpenConnection();
            for(int i = 0; i < dataGridViewStudents.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridViewStudents.Rows[i].Cells[dataGridViewStudents.Rows[i].Cells.Count-1].Value;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridViewStudents.Rows[i].Cells[0].Value);
                    var deleteQuery = $"Delete from Mark where StudentID={id}\nDelete from Parent where StudentID={id}\nDelete from Student where ID={id}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());

                    command.ExecuteNonQuery();
                    var changeCountOfStudents = $"update Class set Number_of_students = {dataGridViewStudents.Rows.Count-1} where ID={selectedClass}";
                    var commandChange = new SqlCommand(changeCountOfStudents, dataBase.GetConnection());
                    commandChange.ExecuteNonQuery();

                }
            }
            dataBase.CloseConnection();
        }
        private void CreateColumns()
        {
            dataGridViewStudents.Columns.Add("ID", "ID");
            dataGridViewStudents.Columns.Add("LastName", "Фамилия");
            dataGridViewStudents.Columns.Add("FirstName", "Имя");
            dataGridViewStudents.Columns.Add("MiddleName", "Отчество");
            dataGridViewStudents.Columns.Add("BirthDate", "Дата рождения");
            dataGridViewStudents.Columns.Add("Phone", "Телефон");
            dataGridViewStudents.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select ID, LastName,FirstName, MiddleName,BirthDate,Phone from Student where ClassID = {selectedClass}";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }

            reader.Close();
        }
        private void Students_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewStudents);
            dataGridViewStudents.Columns[dataGridViewStudents.ColumnCount - 1].Visible = false;
        }

        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var str = toolStripTextBoxSearch.Text;
            string searchString = $"select ID, LastName,FirstName, MiddleName,BirthDate,Phone from Student where ClassID={selectedClass} and concat (LastName, FirstName) like '%"+ str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewStudents);
        }
        private void dataGridViewStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewStudents.Rows[selectedRow];
                EditStudent changeS = new EditStudent(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), (int)row.Cells[0].Value);
                changeS.Show();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Parents parents = new Parents();
            parents.selectedClass = selectedClass;
            this.Hide();
            parents.ShowDialog();
            this.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            StudentHistory sH=new StudentHistory();
            sH.selectedClass = selectedClass;
            sH.Show();
        }
    }
}
