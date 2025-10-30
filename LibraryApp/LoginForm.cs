using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class LoginForm : Form
    {
        public LoginForm() { InitializeComponent(); }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Users WHERE Login=@login AND Password=@pass";
                using (var cmd = new OleDbCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["Role"].ToString();
                            string fullname = reader["FullName"].ToString();

                            MainForm main = new MainForm(role, fullname);
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль", "Ошибка входа",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}