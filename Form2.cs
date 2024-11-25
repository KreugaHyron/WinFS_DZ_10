using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFS_DZ_10
{
    public partial class Form2 : Form
    {
        private TextBox textBox1;
        private NumericUpDown numericUpDownX;
        private NumericUpDown numericUpDownY;
        private Button btnConfirm;
        public string EnteredText { get; private set; }
        public Point TextLocation { get; private set; }
        public Form2()
        {
            InitializeComponent();
            InitializeCustomComponents_1();
        }
        private void InitializeCustomComponents_1()
        {
            this.Text = "Додавання тексту";
            this.Size = new Size(300, 200);

            Label labelText = new Label
            {
                Text = "Текст:",
                Location = new Point(10, 10)
            };

            textBox1 = new TextBox
            {
                Location = new Point(70, 10),
                Size = new Size(200, 20)
            };

            Label labelX = new Label
            {
                Text = "X:",
                Location = new Point(10, 50)
            };

            numericUpDownX = new NumericUpDown
            {
                Location = new Point(70, 50),
                Maximum = 1000,
                Minimum = 0
            };

            Label labelY = new Label
            {
                Text = "Y:",
                Location = new Point(10, 80)
            };

            numericUpDownY = new NumericUpDown
            {
                Location = new Point(70, 80),
                Maximum = 1000,
                Minimum = 0
            };

            btnConfirm = new Button
            {
                Text = "ОК",
                Location = new Point(100, 120),
                Size = new Size(80, 30)
            };
            btnConfirm.Click += BtnConfirm_Click;

            this.Controls.Add(labelText);
            this.Controls.Add(textBox1);
            this.Controls.Add(labelX);
            this.Controls.Add(numericUpDownX);
            this.Controls.Add(labelY);
            this.Controls.Add(numericUpDownY);
            this.Controls.Add(btnConfirm);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            EnteredText = textBox1.Text;
            TextLocation = new Point((int)numericUpDownX.Value, (int)numericUpDownY.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
