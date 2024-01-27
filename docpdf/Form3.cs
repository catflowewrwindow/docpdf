using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace docpdf
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private ImageInlineObject qrCodeInlineObject;
        private void button1_Click(object sender, EventArgs e)
        {

            string sberbank = "https://online.sberbank.ru/";
            richTextBox1.Clear();
            richTextBox1.AppendText("\nДополнительный текст");
            richTextBox1.Text += "Воронежский филлиал РЭУ им. Г.В.Плеханова\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "ИНН 7705043493 КПП 36664430001             032146430000000121100\n";
            richTextBox1.Text += "--------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "ИНН получателя платежа                   номер счёта получателя платежа\n";
            richTextBox1.Text += "БИК 012007084 (ОТДЕЛЕНИЕ ВОРОНЕЖ БАНКА РОССИИ/УФК по Воронежской области\n " +
                "г.Воронеж\n)";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "наименование бланка получателя платежа\n";
            richTextBox1.Text += "Договор:\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "Назначение: Оплата за курсы\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "ФИО обучающегося:" + textBox1.Text + "\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "ФИО плательщика:" + textBox2.Text + "\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "Адрес плательщика:" + textBox3.Text + "\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "КБК: 000000000000000000130\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "ОКТМО: 20701000\n";
            richTextBox1.Text += "----------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "Сумма:" + textBox4.Text + "\n";
            richTextBox1.Text += "---------------------------------------------------------------------------------------------------------------------------------\n";
            richTextBox1.Text += "С условиями приёма указаний в платёжном документе суммы, в т.ч. с суммой ваымаимой платы за услуги\n" +
                "банка озакомлен и согласен                  Подпись плательщика_____________";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(sberbank, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // Преобразование QR-кода в изображение
            Bitmap qrCodeImage = qrCode.GetGraphic(2); // 20 - размер пикселя

            // Создаем объект InlineObject для вставки в RichTextBox
            qrCodeInlineObject = new ImageInlineObject(qrCodeImage);

            // Копируем изображение в буфер обмена
            Clipboard.SetImage(qrCodeImage);

            // Вставляем изображение из буфера обмена в RichTextBox
            richTextBox1.Paste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Устанавливаем шрифт и кисть для рисования текста
            Font font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
            Brush brush = Brushes.Black;

            // Рисуем текст из RichTextBox
            e.Graphics.DrawString(richTextBox1.Text, font, brush, new Point(10, 10));

            // Отобразим QR-код
            if (qrCodeInlineObject != null)
            {
                e.Graphics.DrawImage(qrCodeInlineObject.Image, new Point(10, 10 + (int)e.Graphics.MeasureString(richTextBox1.Text, font).Height));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
