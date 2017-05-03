using System.Drawing;

namespace BouncingBalls
{
    public class Ball
    {
        public Ball(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Height { get; set; }     
        public int Width { get; set; }
        public Point Velocity { get; set; }
        public Color Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


    }
}
