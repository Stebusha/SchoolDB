using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolDB.Forms
{
    public partial class Classes : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;

        public Classes()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateColumns()
        {
            dataGridViewClasses.Columns.Add("ID", "ID");
            dataGridViewClasses.Columns.Add("Name", "Название");
            dataGridViewClasses.Columns.Add("Number_of_students", "Количество учащихся");
            dataGridViewClasses.Columns.Add("Speciality", "Профиль");
            dataGridViewClasses.Columns.Add("Status", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3),RowState.ModifiedNew);
        }

        private void RefreshDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string query = $"select * from Class";

            SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }

            reader.Close();
        }

        private void Classes_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGridView(dataGridViewClasses);
            dataGridViewClasses.Columns[dataGridViewClasses.ColumnCount - 1].Visible = false;
        }

        private void toolStripSearch_Click(object sender, EventArgs e)
        {
            Search(dataGridViewClasses);
        }

        private void Search(DataGridView dgv)
        {
            dgv.Rows.Clear();
            var str = toolStripTextBoxSearch.Text;
            string searchString = $"select ID, Name,Number_of_students, Speciality from Class where concat (Name, Speciality) like '%" + str + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void toolStripUpdate_Click(object sender, EventArgs e)
        {
            RefreshDataGridView(dataGridViewClasses);
        }


        private void dataGridViewClasses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                Students s1 = new Students();
                s1.selectedClass=(int)dataGridViewClasses.Rows[selectedRow].Cells[0].Value;
                s1.Text = dataGridViewClasses.Rows[selectedRow].Cells[1].Value.ToString();
                this.Hide();
                s1.ShowDialog();
                this.Show();
            }

        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            EditClass addC = new EditClass();
            addC.Show();
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
            int index = dataGridViewClasses.CurrentCell.RowIndex;

            dataGridViewClasses.Rows[index].Visible = false;

            if (dataGridViewClasses.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridViewClasses.Rows[index].Cells[dataGridViewClasses.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
                return;
            }

            dataGridViewClasses.Rows[index].Cells[dataGridViewClasses.Rows[index].Cells.Count - 1].Value = RowState.Deleted;
        }
        private void Update()
        {
            dataBase.OpenConnection();
            for (int i = 0; i < dataGridViewClasses.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridViewClasses.Rows[i].Cells[dataGridViewClasses.Rows[i].Cells.Count - 1].Value;
                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridViewClasses.Rows[i].Cells[0].Value);
                    var deleteQuery = $"Delete from Class where ID={id}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());

                    command.ExecuteNonQuery();
                }
            }
            dataBase.CloseConnection();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            selectedRow = dataGridViewClasses.CurrentCell.RowIndex;
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridViewClasses.Rows[selectedRow];
                EditClass changeC = new EditClass(row.Cells[1].Value.ToString(),row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), (int)row.Cells[0].Value);
                changeC.Show();
            }
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridViewClasses);
        }

        private void toolStripButtonHistory_Click(object sender, EventArgs e)
        {
            History hC=new History();
            hC.ShowDialog();
        }
    }
}
