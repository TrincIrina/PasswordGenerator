using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PasswordGenerator
{
    public partial class MyForm : Form
    {
        public string[] upCase = { "QWERTYUIOPASDFGHJKLZXCVBNM" };
        public string[] lowCase = { "qwertyuiopasdfghjklzxcvbnm" };
        public string[] numberCase = { "1234567890" };
        public MyForm()
        {
            InitializeComponent();
            lengthComboBox.Text = lengthComboBox.Items[2].ToString();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Выход",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(lengthComboBox.SelectedItem);
            StringBuilder sb = new StringBuilder();
            if (upCaseCheckBox.Checked)
            {
                for (int i = 0; i < upCase.Length; i++)
                {
                    sb.Append(upCase[i]);
                }
            }
            if (lowCaseCheckBox.Checked)
            {
                for (int i = 0; i < lowCase.Length; i++)
                {
                    sb.Append(lowCase[i]);
                }
            }
            if (numberCheckBox.Checked)
            {
                for (int i = 0; i < numberCase.Length; i++)
                {
                    sb.Append(numberCase[i]);
                }
            }
            if (!upCaseCheckBox.Checked && !lowCaseCheckBox.Checked && !numberCheckBox.Checked)
            {
                DialogResult result = MessageBox.Show(
                    "Необходимо выбрать какие символы будут использованны в пароле",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            string str = "";
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                str += sb[r.Next(0, sb.Length)];
            }
            textBox.Text = str;
        }
    }
}
