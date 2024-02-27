using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace exx_14
{
    public partial class Form1 : Form
    {
        private int _size;
        private int _interval;
        private int[,] _ticks ;
        private Panel[,] _panels;
        private bool _isOn = false;

        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void UpdateValues()
        {
            _interval = Convert.ToInt32(interval.Text);
            _size = Convert.ToInt32(size.Text);

            timer.Interval = _interval;
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            label.Enabled = !label.Enabled;
            label.Visible = !label.Visible;
            label1.Enabled = !label1.Enabled;
            label1.Visible = !label1.Visible;
            label2.Enabled = !label2.Enabled;
            label2.Visible = !label2.Visible;
            size.Enabled = !size.Enabled;
            size.Visible = !size.Visible;
            interval.Enabled = !interval.Enabled;
            interval.Visible = !interval.Visible;
        }

        private void on_off_btn_Click(object sender, EventArgs e)
        {
            if (_isOn)
            {
                _isOn = false;
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        Controls.Remove(_panels[i, j]);
                    }
                }
                timer.Stop();
            }
            else
            {
                _isOn = true;
                UpdateValues();

                int pictureSide = 100 / (_size / 3);

                _ticks = new int[_size, _size];
                _panels = new Panel[_size, _size];
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        _ticks[i, j] = 0;
                        _panels[i, j] = new Panel()
                        {
                            BackColor = Color.White,
                            Size = new Size(pictureSide, pictureSide),
                            Location = new Point((5 + pictureSide) * i + 5, (5 + pictureSide) * j + 5)
                        };
                        Controls.Add(_panels[i, j]);
                    }
                }

                _panels[_size / 2, _size / 2].BackColor = Color.Red;
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_panels[i, j].BackColor != Color.White)
                        _ticks[i, j]++;

                    int r = rnd.Next(2);
                    if (_panels[i, j].BackColor == Color.Red)
                    {
                        if (r == 1)
                            TryInfect(i, j);
                    }

                    CheckTicks(i, j);
                }
            }
        }

        private void TryInfect(int x, int y)
        {
            int[,] p = new int[,] { { x + 1, y }, { x - 1, y }, { x, y - 1 }, { x, y + 1 } };

            for (int i = 0; i < p.GetLength(0); i++)
            {
                int r = rnd.Next(4);
                if (IsValide(p[r, 0], p[r, 1]) &&
                    _panels[p[r, 0], p[r, 1]].BackColor == Color.White)
                {
                    _panels[p[r, 0], p[r, 1]].BackColor = Color.Red;
                }
            }
        }

        private bool IsValide(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < _size && y < _size);
        }

        private void CheckTicks(int x, int y)
        {
            Color clr = _panels[x, y].BackColor;

            if (clr == Color.Red &&
                _ticks[x, y] >= 6)
            {
                _panels[x, y].BackColor = Color.Tan;
                _ticks[x, y] = 0;
            }
            else if (clr == Color.Tan &&
                     _ticks[x, y] >= 4)
            {
                _panels[x, y].BackColor = Color.White;
                _ticks[x, y] = 0;
            }
        }
    }
}
