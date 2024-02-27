using System;
using System.Drawing;
using System.Windows.Forms;

namespace exx_16
{
    public partial class Form1 : Form
    {
        private bool _isPaint;

        private int _length;
        
        private int _count;
        private Dot[] _dots;

        private readonly Random _rnd = new Random();

        private readonly int _speed = 1;
        private readonly int _diameter = 30;

        private readonly Pen _linePen = new Pen(Color.Aqua);
        private readonly Pen _circlePen = new Pen(Color.IndianRed);

        private readonly Brush _circlebrush = new SolidBrush(Color.IndianRed);

        public Form1()
        {
            InitializeComponent();
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            settings.Visible = !settings.Visible;
        }

        private void on_off_btn_Click(object sender, EventArgs e)
        {
            if (_isPaint)
                timer.Stop();
            else
                timer.Start();
            
            _isPaint = !_isPaint;
            _length = Convert.ToInt32(length.Text);

            _count = Convert.ToInt32(count.Text);
            _dots = new Dot[_count];

            for (int i = 0; i < _count; i++)
            {
                _dots[i] = new Dot(_rnd, this.Height - 80, this.Width - 70);
                _dots[i].SetSpeed(_speed, _rnd);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!_isPaint)
                return;

            Bitmap image = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(image);

            g.FillRectangle(Brushes.White, 0, 0, Width, Height);
            
            DrawLines(g);
            foreach (var dot in _dots)
            {
                g.FillEllipse(_circlebrush, dot.X, dot.Y, _diameter, _diameter);
                g.DrawEllipse(_circlePen, dot.X, dot.Y, _diameter, _diameter);
            }
            CreateGraphics().DrawImageUnscaled(image, 0, 0);

            image.Dispose();
            g.Dispose();

            MoveDots();
        }

        private void CheckCollisins(Dot dot)
        {
            if (dot.X <= 0)
                dot.SpeedX = _speed;
            if (dot.X >= Width - 60)
                dot.SpeedX = -_speed;
            if (dot.Y <= 0)
                dot.SpeedY = _speed;
            if (dot.Y >= Height - 72)
                dot.SpeedY = -_speed;
        }

        private void MoveDots()
        {
            var interval = timer.Interval;
            foreach (var dot in _dots)
            {
                CheckCollisins(dot);
                dot.X += dot.SpeedX * interval / 10;
                dot.Y += dot.SpeedY * interval / 10;
            }
        }

        private void DrawLines(Graphics g)
        {
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = i + 1; j < _count; j++)
                {
                    if (GetLength(_dots[i].X, _dots[i].Y, _dots[j].X, _dots[j].Y) <= _length)
                    {
                        g.DrawLine(_linePen,
                            _dots[i].X + (_diameter / 2),
                            _dots[i].Y + (_diameter / 2),
                            _dots[j].X + (_diameter / 2),
                            _dots[j].Y + (_diameter / 2));
                    }
                }
            }
        }

        private static int GetLength(int x, int y, int x1, int y1)
        {
            return (int)Math.Sqrt(Math.Pow(x1 - x, 2) + Math.Pow(y1 - y, 2));
        }
    }
}
