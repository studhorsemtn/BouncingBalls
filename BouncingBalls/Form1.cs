using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBalls
{
    public partial class BouncingBalls : Form
    {


        bool startBalls = false;
        Random rnd = new Random();
        Graphics graphics;
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 600;
        int dx1 = 5;
        int dy1 = 4;
        int dx2 = 5;
        int dy2 = 4;
        int ballsize = 40;

        // code added by Lyon.


        public BouncingBalls()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(paintBall);
            this.DoubleBuffered = true;
        }

        public void paintBall(object sender, PaintEventArgs e)
        {
            if (startBalls)
            {
                graphics = e.Graphics;
                Color randomColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                SolidBrush ball1 = new SolidBrush(Color.Red);
                SolidBrush ball2 = new SolidBrush(Color.Purple);
                graphics.FillEllipse(ball1, x1, y1, ballsize,ballsize);
                graphics.FillEllipse(ball2, x2, y2, 40, 40);
            }
            
        }

        private void BallMove()
        {
            int new_x1 = x1 + dx1;
            int new_y1 = y1 + dy1;
            int new_x2 = x2 + dx2;
            int new_y2 = y2 + dy2;

            if (new_x1 <= 0  || new_x1 > this.ClientSize.Width -40) 
            {
                dx1 = -dx1;
                
            }

            if (new_y1 <= 0 || new_y1 > this.ClientSize.Height -40)
            {
                dy1 = -dy1;
            }

            if (new_x2 < 0 || new_x2 > this.ClientSize.Width -40)
            {
                dx2 = -dx2;
            }

            if (new_y2 < 0 || new_y2 > this.ClientSize.Height -40)
            {
                dy2 = -dy2;
            }

            x1 += dx1;
            y1 += dy1;
            x2 += dx2;
            y2 += dy2;
            Invalidate();

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            BallMove();
        }

        private void BouncingBalls_Click(object sender, EventArgs e)
        {
            if (startBalls == false)
            {
                startBalls = true;
            }
            else
            {
                startBalls = false;
            }
        }
    }
}
