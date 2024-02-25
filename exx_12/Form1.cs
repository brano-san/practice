using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exx_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.ColumnCount; i++)
            {
                for (int j = 0; j < panel1.RowCount; j++)
                {
                    Font font = new Font("Times New Roman", 60);
                    TextBox tb = new TextBox()
                    {
                        Multiline = true,
                        Size = new Size(91, 91),
                        Font = font
                    };
                    panel1.Controls.Add(tb);
                }
            }
        }

        private void CheckDiagonal(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }
    }
}
