using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class MainForm : Form
    {
        private string _role;
        private string _fullName;

        private OleDbDataAdapter adapterBooks, adapterReaders, adapterCheckouts;
        private DataTable tableBooks, tableReaders, tableCheckouts;

        public MainForm(string role, string fullName)
        {
            InitializeComponent();
            _role = role;
            _fullName = fullName;
            lblUser.Text = $"{fullName} ({role})";
            LoadData();
            ApplyRoleStyle();
        }

        // ======= Интерфейс в зависимости от роли =======
        private void ApplyRoleStyle()
        {
            if (_role == "Librarian")
            {
                // мягкая зелёная палитра
                this.BackColor = Color.Honeydew;
                tabReaders.Parent = null; // убрать вкладку "Читатели"
                btnManageUsers.Visible = false;

                lblUser.ForeColor = Color.DarkGreen;
                lblUser.Font = new Font(lblUser.Font, FontStyle.Bold);
                this.Text = "Библиотека — Доступ: библиотекарь";
            }
            else if (_role == "Director")
            {
                // синий строгий стиль
                this.BackColor = Color.AliceBlue;
                lblUser.ForeColor = Color.MidnightBlue;
                lblUser.Font = new Font(lblUser.Font, FontStyle.Bold);
                this.Text = "Библиотека — Доступ: директор";

                // добавить возможность управлять пользователями
                btnManageUsers.Visible = true;
            }
        }

        // ======= Загрузка данных =======
        private void LoadData()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                adapterBooks = new OleDbDataAdapter("SELECT * FROM Books", conn);
                tableBooks = new DataTable();
                adapterBooks.Fill(tableBooks);
                dgvBooks.DataSource = tableBooks;

                adapterReaders = new OleDbDataAdapter("SELECT * FROM Readers", conn);
                tableReaders = new DataTable();
                adapterReaders.Fill(tableReaders);
                dgvReaders.DataSource = tableReaders;

                adapterCheckouts = new OleDbDataAdapter("SELECT * FROM Checkouts", conn);
                tableCheckouts = new DataTable();
                adapterCheckouts.Fill(tableCheckouts);
                dgvCheckouts.DataSource = tableCheckouts;
            }
        }

        // ======= Сохранение =======
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();

                new OleDbCommandBuilder(adapterBooks);
                adapterBooks.Update(tableBooks);

                if (_role == "Director")
                {
                    new OleDbCommandBuilder(adapterReaders);
                    adapterReaders.Update(tableReaders);
                }

                new OleDbCommandBuilder(adapterCheckouts);
                adapterCheckouts.Update(tableCheckouts);

                MessageBox.Show("Изменения сохранены", "Сохранено");
            }
        }

        // ======= Доп. управление для Директора =======
        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            if (_role != "Director") return;

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Users", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                Form form = new Form()
                {
                    Text = "Управление пользователями",
                    Size = new Size(600, 400),
                    StartPosition = FormStartPosition.CenterParent
                };

                DataGridView dgv = new DataGridView()
                {
                    Dock = DockStyle.Fill,
                    DataSource = dt
                };

                Button btnSaveUsers = new Button()
                {
                    Text = "Сохранить пользователей",
                    Dock = DockStyle.Bottom
                };

                btnSaveUsers.Click += (s, ev) =>
                {
                    new OleDbCommandBuilder(adapter);
                    adapter.Update(dt);
                    MessageBox.Show("Пользователи сохранены!", "OK");
                };

                form.Controls.Add(dgv);
                form.Controls.Add(btnSaveUsers);
                form.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}