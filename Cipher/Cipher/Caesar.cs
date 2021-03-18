using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cipher
{
    public partial class Caesar : Form
    {
        public Caesar()
        {
            InitializeComponent();
        }
        string caesar_ukr(string text, int key)
        {
            char[,] ABC = { { 'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м',
                              'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ю', 'я', 'ь' },
                            { 'А', 'Б', 'В', 'Г', 'Ґ', 'Д', 'Е', 'Є', 'Ж', 'З', 'И', 'І', 'Ї', 'Й', 'К', 'Л', 'М',
                              'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ю', 'Я', 'Ь' }
                          };
            if (key > 0) while (key > 33) key -= 33;
            if (key < 0) while (key < -33) key += 33;
            int i = 0;
            string new_text = "";
            bool verifi = true;
            while (i < text.Length)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (ABC[0, j] == text[i])
                    {
                        int k = (j + key) % 33;
                        if (k < 0) k += 33;
                        if (k > 32) k -= 33;
                        new_text += ABC[0, k];
                        verifi = false;
                        break;
                    }
                    else if (ABC[1, j] == text[i])
                    {
                        int k = (j + key) % 33;
                        if (k < 0) k += 33;
                        if (k > 32) k -= 33;
                        new_text += ABC[1, k];
                        verifi = false;
                        break;
                    }
                }
                if (verifi == true) new_text += text[i];
                else verifi = true;
                i++;
            }
            return new_text;
        }


        string caesar_eng(string text, int key)
        {
            if (key > 0) while (key > 26) key -= 26;
            if (key < 0) while (key < -26) key += 26;
            char[,] ABC = { { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                              'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                            { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                              'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }
                          };
            int i = 0;
            string new_text = "";
            bool verifi = true;
            while (i < text.Length)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (ABC[0, j] == text[i])
                    {
                        int k = (j + key) % 26;
                        if (k < 0) k += 26;
                        if (k > 25) k -= 26;
                        new_text += ABC[0, k];
                        verifi = false;
                        break;
                    }
                    else if (ABC[1, j] == text[i])
                    {
                        int k = (j + key) % 26;
                        if (k < 0) k += 26;
                        if (k > 25) k -= 26;
                        new_text += ABC[1, k];
                        verifi = false;
                        break;
                    }
                }
                if (verifi == true) new_text += text[i];
                else verifi = true;
                i++;
            }
            return new_text;
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                string str = "";

                while (!streamReader.EndOfStream)
                {
                    str += streamReader.ReadLine();
                }

                textBox_main.Text = str;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_main.Text = "";
            textBox_decrypt.Text = "";
            textBox_encrypt.Text = "";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();
            if (sDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sDialog.FileName);
                sw.Write(textBox_main.Text);
                sw.Close();
            }
        }

        private void button_encrypt_Click(object sender, EventArgs e)
        {
            if (textBox_main.Text != "" && textBox_encrypt.Text != "")
            {
                int key = Convert.ToInt32(textBox_encrypt.Text);
                if (radioButton_ukr.Checked == true) textBox_main.Text = caesar_ukr(textBox_main.Text, key);
                else if (radioButton_eng.Checked == true) textBox_main.Text = caesar_eng(textBox_main.Text, key);
            }
        }

        private void button_decrypt_Click(object sender, EventArgs e)
        {
            if (textBox_main.Text != "" && textBox_decrypt.Text != "")
            {
                int key = -Convert.ToInt32(textBox_encrypt.Text);
                if (radioButton_ukr.Checked == true) textBox_main.Text = caesar_ukr(textBox_main.Text, key);
                else if (radioButton_eng.Checked == true) textBox_main.Text = caesar_eng(textBox_main.Text, key);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton_ukr.Checked = true;

            textBox_main.ScrollBars = ScrollBars.Vertical;
        }
    }
}
