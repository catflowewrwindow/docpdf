using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;



namespace docpdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public string connectionString = "Server=localhost;Port=5432;Database=db;Username=postgres;Password=0000;";
        private NpgsqlCommand cmd;
        private NpgsqlConnection conn;
        private string sql = null;
        private int loginAttempts = 0;

        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from u_login(:_username, :_password)";
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_username", LogintextBox.Text);
                cmd.Parameters.AddWithValue("_password", PastextBox.Text);
                int result = (int)cmd.ExecuteScalar();
                conn.Close();

                if (result == 1)
                {
                    loginAttempts = 0;
                    this.Hide();
                   new Form2(LogintextBox.Text).Show();
                }
                else
                {
                    MessageBox.Show("Неправильно введены данные");
                    loginAttempts++;
                    if (loginAttempts >= 3)
                    {
                        MessageBox.Show("Вы ввели неверный пароль 3 раза. Предлагаем сбросить пароль.");
                        ResetPassword();
                        loginAttempts = 0;
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message, "");
                conn.Close();
            }
        }
        private void ResetPassword()
        {
            try
            {
                conn.Open();
                string newPassword = "newpassword";
                string username = LogintextBox.Text;

                string updateSql = "UPDATE tbl_user SET password = @Password WHERE username = @Username";
                using (NpgsqlCommand updateCmd = new NpgsqlCommand(updateSql, conn))
                {
                    updateCmd.Parameters.AddWithValue("@Password", newPassword);
                    updateCmd.Parameters.AddWithValue("@Username", username);
                    updateCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Пароль сброшен. Новый пароль: " + newPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сброса пароля: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LogintextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PastextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connectionString);
        }
    }
}
