using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace exx_13
{
    public partial class Form1 : Form
    {
        public class Fox
        {
            public Button Btn;
            public int X;
            public int Y;

            public void SetCoord(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private Button _startBtn;
        private Fox[] _foxes;
        private Button[,] _fields;
        private int[,] _dirs;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _foxes = new Fox[2]{ new Fox(), new Fox() };
            _foxes[0].Btn = button9;
            _foxes[0].SetCoord(2, 2);
            _foxes[1].Btn = button11;
            _foxes[1].SetCoord(2, 4);

            _fields = new Button[7, 7]
            {  { null, null, button1, button2, button3, null, null },
               { null, null, button4, button5, button6, null, null },
               { button7, button8, button9, button10, button11, button12, button13 },
               { button14, button15, button16, button17, button18, button19, button20 },
               { button21, button22, button23, button24, button25, button26, button27 },
               { null, null, button28, button29, button30, null, null },
               { null, null, button31, button32, button33, null, null }};

        }

        private void ChikenMacnagets(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Text == "Л")
                return;

            if (btn.Text == "К")
            {
                _startBtn = btn;
                return;
            }

            if (_startBtn != null && btn.Text == "" &&
                IsClose(_startBtn, btn))
            {
                btn.Text = _startBtn.Text;
                _startBtn.Text = "";
                _startBtn = btn;
                
                MoveFox();
                CheckWin();
                CheckLoose();
            }
        }

        private static bool IsClose(Button start, Button dist)
        {
            var startTag = Convert.ToInt32(start.Tag.ToString());
            var distTag = Convert.ToInt32(dist.Tag.ToString());

            if (startTag + 1 == distTag ||
                startTag - 1 == distTag ||
                startTag - 10 == distTag)
            {
                return true;
            }
            return false;
        }

        private void CheckWin()
        {
            if (button1.Text == "К" &&
                button2.Text == "К" &&
                button3.Text == "К" &&
                button4.Text == "К" &&
                button5.Text == "К" &&
                button6.Text == "К" &&
                button9.Text == "К" &&
                button10.Text == "К" &&
                button11.Text == "К")
            {
                MessageBox.Show("Вы победили!", "Победа");
                Application.Exit();
            }
        }

        private void CheckLoose()
        {
            int count = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (_fields[i, j] != null &&
                        _fields[i, j].Text == "К")
                    {
                        count++;
                    }
                }
            }

            if (count < 9)
            {
                MessageBox.Show("Вы Проиграли!", "Поражение");
                Application.Exit();
            }
        }

        private void MoveFox()
        {
            Random rnd = new Random();
            Fox fox = _foxes[rnd.Next(2)];

            int count = 30;
            bool step = true;
            while (count-- > 0)
            {
                _dirs = new int[,]
                {
                    { fox.X - 1, fox.Y },
                    { fox.X + 1, fox.Y },
                    { fox.X, fox.Y - 1 },
                    { fox.X, fox.Y + 1 },
                    { fox.X - 2, fox.Y },
                    { fox.X + 2, fox.Y },
                    { fox.X, fox.Y - 2 },
                    { fox.X, fox.Y + 2 }
                };

                int rand = rnd.Next(4);

                if (IsValide(_dirs[rand + 4, 0], _dirs[rand + 4, 1]) &&
                    _fields[_dirs[rand, 0], _dirs[rand, 1]].Text == "К" &&
                    _fields[_dirs[rand + 4, 0], _dirs[rand + 4, 1]].Text == "")
                {
                    _fields[_dirs[rand, 0], _dirs[rand, 1]].Text = "";
                    Step(ref fox, _dirs[rand + 4, 0], _dirs[rand + 4, 1]);
                    step = false;
                }
            }

            count = 10;
            while (count-- > 0 && step)
            {
                int rand = rnd.Next(4);
                if (IsValide(_dirs[rand, 0], _dirs[rand, 1]) &&
                    _fields[_dirs[rand, 0], _dirs[rand, 1]].Text == "")
                {
                    Step(ref fox, _dirs[rand, 0], _dirs[rand, 1]);
                    step = false;
                }
            }
        }

        private bool IsValide(int x, int y)
        {
            return ((x >= 0 && x <= 6) && (y >= 0 && y <= 6) &&
                    (_fields[x, y] != null));
        }

        private void Step(ref Fox fox, int X, int Y)
        {
            (fox.Btn.Text, _fields[X, Y].Text) = (_fields[X, Y].Text, fox.Btn.Text);
            fox.Btn = _fields[X, Y];
            fox.SetCoord(X, Y);
            Refresh();
            Thread.Sleep(400);
        }
    }
}
