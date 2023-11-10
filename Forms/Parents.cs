using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{

    public partial class Parents : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;
        public int selectedClass;

        public Parents()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewParents);
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            EditParent addP = new EditParent();
            addP.Show();

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

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewParents);
        }

        private void dataGridViewStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewParents.Rows[selectedRow];
                EditParent changeP = new EditParent(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(),(int)row.Cells[0].Value);
                changeP.Show();
            }

        }

        private void DeleteRow()
        {
            int index = dataGridViewParents.CurrentCell.RowIndex;

            dataGridViewParents.Rows[index].Visible = false;

            if (dataGridViewParents.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridViewParents.Rows[index].Cells[dataGridViewParents.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
                return;
            }

            dataGridViewParents.Rows[index].Cells[dataGridViewParents.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
        }
        private void Update()
        {
            dataBase.OpenConnection();
            for (int i = 0; i < dataGridViewParents.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridViewParents.Rows[i].Cells[dataGridViewParents.Rows[i].Cells.Count - 1].Value;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridViewParents.Rows[i].Cells[0].Value);
                    var deleteQuery = $"Delete from Parent where ID={id}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());

                    command.ExecuteNonQuery();

                }
            }
            dataBase.CloseConnection();
        }
        private void CreateColumns()
        {
            dataGridViewParents.Columns.Add("ID", "ID");
            dataGridViewParents.Columns.Add("LastName", "Фамилия");
            dataGridViewParents.Columns.Add("FistName", "Имя");
            dataGridViewParents.Columns.Add("MiddleName", "Отчество");
            dataGridViewParents.Columns.Add("BirthDate", "Дата рождения");
            dataGridViewParents.Columns.Add("Phone", "Телефон");
            dataGridViewParents.Columns.Add("Job", "Место работы");
            dataGridViewParents.Columns.Add("StudentID", "Учащийся");
            dataGridViewParents.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5), record.GetString(6),record.GetInt32(7), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select ID, LastName,FirstName, MiddleName,BirthDate,Phone, Job,StudentID from Parent where StudentID = Any (select ID from Student where ClassID='{selectedClass}')";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }

            reader.Close();
        }

        private void Parents_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewParents);
            dataGridViewParents.Columns[dataGridViewParents.ColumnCount - 1].Visible = false;
        }
        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var str = toolStripTextBoxSearch.Text;
            string searchString = $"select ID, LastName,FirstName, MiddleName,BirthDate,Phone,Job from Parent where concat (LastName, FirstName) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void dataGridViewParents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewParents.Rows[selectedRow];
                EditParent changeP = new EditParent(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), (int)row.Cells[0].Value);
                changeP.Show();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ParentHistory pH=new ParentHistory();
            pH.selectedClass = selectedClass;
            pH.Show();
        }
    }
}
