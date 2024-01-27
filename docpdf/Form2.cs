using iTextSharp.text.pdf;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace docpdf
{
    public partial class Form2 : Form
    {
        public Form2(string username)
        {
            this.username = username;
            InitializeComponent();
            FillDataGridView();
            FillDataStudy();
        }
        private string username;

        private void FillDataStudy()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM study_programm";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView2.DataSource = table;
                    }
                }
            }
        }

        public string connectionString = "Server=localhost;Port=5432;Database=db;Username=postgres;Password=0000;";
        private void FillDataGridView()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM student";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                string name = textBox1.Text;
                string surname = textBox2.Text;
                string patronymic = textBox3.Text;
                string data = textBox4.Text;
                string pasport = textBox5.Text;
                string mesto = textBox6.Text;
                string email = textBox7.Text;
                string phone = textBox8.Text;
                string post = textBox9.Text;
                string work = textBox10.Text;

                string insertSql = "INSERT INTO student (Фамилия, Имя, Дата_рождения, Серия_номер_паспорта, Место_проживания, Электронная_почта, Номер_телефона, Должность, Место_работы, Отчество) " +
                              "VALUES (@Name, @Surname, @Data, @Pasport, @Mesto, @Email, @Phone, @Post, @Work, @Patronymic)";

                using (NpgsqlCommand insertCmd = new NpgsqlCommand(insertSql, connection))
                {
                    DateTime dataValue;
                    if (DateTime.TryParse(textBox4.Text, out dataValue) && int.TryParse(textBox5.Text, out int pasportNumber)
                        && int.TryParse(textBox8.Text, out int phoneNumber))
                    {
                        insertCmd.Parameters.AddWithValue("@Name", name);
                        insertCmd.Parameters.AddWithValue("@Surname", surname);
                        insertCmd.Parameters.AddWithValue("@Patronymic", patronymic);
                        insertCmd.Parameters.AddWithValue("@Data", dataValue);
                        insertCmd.Parameters.AddWithValue("@Pasport", pasportNumber);
                        insertCmd.Parameters.AddWithValue("@Mesto", mesto);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Phone", phoneNumber);
                        insertCmd.Parameters.AddWithValue("@Post", post);
                        insertCmd.Parameters.AddWithValue("@Work", work);

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show("Данные успешно добавлены в базу данных.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string patronymic = textBox3.Text;
            string mesto = textBox6.Text;
            string email = textBox7.Text;
            string post = textBox9.Text;
            string work = textBox10.Text;
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE student SET Фамилия = @surname, Имя = @name, Дата_рождения = @date, Серия_номер_паспорта = @pasport, Место_проживания = @mesto," +
                        " Электронная_почта = @email, Номер_телефона = @phone, Должность = @post, Место_работы = @work, Отчество = @patronymic ";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, connection))
                    {
                        DateTime dataValue;
                        if (DateTime.TryParse(textBox4.Text, out dataValue) && int.TryParse(textBox5.Text, out int pasportNumber)
                      && int.TryParse(textBox8.Text, out int phoneNumber))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@surname", surname);
                            cmd.Parameters.AddWithValue("@date", dataValue);
                            cmd.Parameters.AddWithValue("@pasport", pasportNumber);
                            cmd.Parameters.AddWithValue("@mesto", mesto);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@phone", phoneNumber);
                            cmd.Parameters.AddWithValue("@post", post);
                            cmd.Parameters.AddWithValue("@work", work);
                            cmd.Parameters.AddWithValue("@patronymic", patronymic);


                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Данные успешно обновлены в таблице.");
                        }
                    }
                }

                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idToDelete = textBox11.Text;
            if (string.IsNullOrEmpty(idToDelete))
            {
                MessageBox.Show("Пожалуйста, введите ID для удаления записи.");
                return;
            }
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM student WHERE id_студента = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idToDelete));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Запись успешно удалена из таблицы.");
                    }
                }

                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label19.Text = label19.Text + username;
            this.Width = 1600;
            this.Height = 700;
           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = textBox12.Text;
            string skill = textBox14.Text;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string insertSql = @"INSERT INTO study_programm (Название, Срок_обучения, Квалификация, Стоимость_обучения) " +
                                         "VALUES (@Name, @Time, @Skill, @Money)";
                    using (NpgsqlCommand insertCmd = new NpgsqlCommand(insertSql, connection))
                    {
                        if (decimal.TryParse(textBox15.Text, out decimal moneyValue) && int.TryParse(textBox13.Text, out int times))
                        {
                            insertCmd.Parameters.AddWithValue("@Name", name);
                            insertCmd.Parameters.AddWithValue("@Time", times);
                            insertCmd.Parameters.AddWithValue("@Skill", skill);
                            insertCmd.Parameters.AddWithValue("@Money", moneyValue);
                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox12.Text;
            string skill = textBox14.Text;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string updatesql = @"update study_programm set Название = @name ,Срок_обучения =@time , Квалификация =@skill, Стоимость_обучения =@money";
                    using (NpgsqlCommand updateCmd = new NpgsqlCommand(updatesql, connection))
                    {
                        if (decimal.TryParse(textBox15.Text, out decimal moneyValue) && int.TryParse(textBox13.Text, out int times))
                        {
                            updateCmd.Parameters.AddWithValue("@name", name);
                            updateCmd.Parameters.AddWithValue("@time", times);
                            updateCmd.Parameters.AddWithValue("@skill", skill);
                            updateCmd.Parameters.AddWithValue("@money", moneyValue);
                            updateCmd.ExecuteNonQuery();
                            MessageBox.Show("Данные успешно добавлены в базу данных.");
                        }
                    }
                }
                FillDataStudy();
            }

            catch
            {
                MessageBox.Show("Ошибка при добавлении данных: ");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string idToDelete = textBox16.Text;
            if (string.IsNullOrEmpty(idToDelete))
            {
                MessageBox.Show("Пожалуйста, введите ID для удаления записи.");
                return;
            }
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM study_programm WHERE id_study = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idToDelete));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Запись успешно удалена из таблицы.");
                    }
                }

                FillDataStudy();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
        private void FillPdfForm(string templatePath, string newPdfPath)
        {

        }
    }
}



