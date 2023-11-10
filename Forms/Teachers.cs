using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    enum RowState
    {
        Existed,
        New,
        Deleted,
        Modified,
        ModifiedNew
    }
    public partial class Teachers : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;

        public Teachers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewTeachers); 
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            EditTeacher addT = new EditTeacher();
            addT.Show();

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
            Search(dataGridViewTeachers);
        }

        private void DeleteRow()
        {
            int index = dataGridViewTeachers.CurrentCell.RowIndex;

            dataGridViewTeachers.Rows[index].Visible = false;

            if (dataGridViewTeachers.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridViewTeachers.Rows[index].Cells[dataGridViewTeachers.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
                return;
            }

            dataGridViewTeachers.Rows[index].Cells[dataGridViewTeachers.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
        }
        private void Update()
        {
            dataBase.OpenConnection();
            for (int i = 0; i < dataGridViewTeachers.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridViewTeachers.Rows[i].Cells[dataGridViewTeachers.Rows[i].Cells.Count - 1].Value;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridViewTeachers.Rows[i].Cells[0].Value);
                    var deleteQuery = $"Delete from Teacher where ID={id}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());

                    command.ExecuteNonQuery();

                }
            }
            dataBase.CloseConnection();
        }
        private void CreateColumns()
        {
            dataGridViewTeachers.Columns.Add("ID", "ID");
            dataGridViewTeachers.Columns.Add("LastName", "Фамилия");
            dataGridViewTeachers.Columns.Add("FistName", "Имя");
            dataGridViewTeachers.Columns.Add("MiddleName", "Отчество");
            dataGridViewTeachers.Columns.Add("BirthDate", "Дата рождения");
            dataGridViewTeachers.Columns.Add("Phone", "Телефон");
            dataGridViewTeachers.Columns.Add("Qualification", "Квалификация");
            dataGridViewTeachers.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5),record.GetString(6), RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select ID, LastName,FirstName, MiddleName,BirthDate,Phone, Qualification from Teacher";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }

            reader.Close();
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewTeachers);
            dataGridViewTeachers.Columns[dataGridViewTeachers.ColumnCount - 1].Visible = false;
        }
        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var str = toolStripTextBoxSearch.Text;
            string searchString = $"select ID, LastName,FirstName, MiddleName,BirthDate,Phone,Qualification from Teacher where concat (LastName, Qualification) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void dataGridViewTeachers_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                Subjects subjects = new Subjects();
                subjects.selectedTeacher = (int)dataGridViewTeachers.Rows[selectedRow].Cells[0].Value;
                subjects.Text = dataGridViewTeachers.Rows[selectedRow].Cells[1].Value.ToString();
                this.Hide();
                subjects.ShowDialog();
                this.Show();

            }
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            selectedRow = dataGridViewTeachers.CurrentCell.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridViewTeachers.Rows[selectedRow];
                EditTeacher changeT = new EditTeacher(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), (int)row.Cells[0].Value);
                changeT.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TeacherHistory tH = new TeacherHistory();
            tH.Show();

        }
    }
}
