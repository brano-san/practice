using System;
using System.Drawing;

namespace exx_16
{
    public class Dot
    {
        public int X, Y;
        public int SpeedX, SpeedY;

        public Dot(Random r, int height, int width)
        {
            X = r.Next(width);
            Y = r.Next(height);
        }

        public void SetSpeed(int speed, Random r)
        {
            int[] speeds = { (-speed), speed };
            SpeedX = speeds[r.Next(2)];
            SpeedY = speeds[r.Next(2)];
        }
    }
}