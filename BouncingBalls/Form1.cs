using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;



namespace BouncingBalls
{
    public partial class BouncingBalls : Form
    {
        Graphics graphics;
        List<Ball> balls;
        System.Diagnostics.Stopwatch stopWatch;
        long? lastTime;
        double _delta;

        

        public BouncingBalls()
        {
            InitializeComponent();
            
            this.DoubleBuffered = true;

            setupGame(GameTools.GetRandomNumber(5, 20));
        }

        private void setupGame(int numberOfBalls)
        {
            timer1.Enabled = false;

            balls = new List<Ball>();
            graphics = this.CreateGraphics();
            stopWatch = new System.Diagnostics.Stopwatch();

            for (int i = 0; i < numberOfBalls; i++)
            {
                int size = GameTools.GetRandomNumber(20, 50);
                int xVelocity = GameTools.GetRandomNumber(1, 10);
                int yVelocity = GameTools.GetRandomNumber(1, 10);
                Color color = GameTools.GetRandomColor();
                int x = GameTools.GetRandomNumber(0, (int)(graphics.VisibleClipBounds.Width - size));
                int y = GameTools.GetRandomNumber(0, (int)(graphics.VisibleClipBounds.Height - size));

                Ball ball = new Ball(size, size);
                ball.Color = color;
                ball.X = x;
                ball.Y = y;
                ball.Velocity = new Point(xVelocity, yVelocity);

                balls.Add(ball);


            }

            Collision(GameTools.GetRandomNumber(5, 20));

            stopWatch.Start();
            timer1.Enabled = true;
        }
        /// <summary>
        /// Calculate the time since the frame was last drawn. then multiply this value x the amount a ball will move. 
        /// This is all so the ball will move based on time instead of how fast the app runs.
        /// </summary>
        private void calculateDelta()
        {
            if (lastTime == null)
                lastTime = stopWatch.ElapsedMilliseconds;

            long currentTime = stopWatch.ElapsedMilliseconds;
            double delta = (double)((currentTime - lastTime) / 100.0);

            // make sure the delta isn't an unusually high number.
            _delta = delta < 1 ? delta : 1;
        }
        private void Draw()
        {
            graphics.Clear(Color.Black);

            foreach (Ball ball in balls)
                graphics.FillEllipse(new SolidBrush(ball.Color), ball.X, ball.Y, ball.Width, ball.Height);

            graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
        }
        private void BallMove()
        {
            foreach (Ball ball in balls)
            {
                int velocityX = ball.Velocity.X;
                int velocityY = ball.Velocity.Y;
                int new_x1 = ball.X + velocityX;
                int new_y1 = ball.Y + velocityY;
                

                if (new_x1 <= 0 || new_x1 > this.ClientSize.Width - ball.Width)
                {
                    velocityX = -velocityX;
                    ball.Color = GameTools.GetRandomColor();
                    velocityX += 2;
                }

                if (new_y1 <= 0 || new_y1 > this.ClientSize.Height - ball.Height)
                {
                    velocityY = -velocityY;
                    ball.Color = GameTools.GetRandomColor();
                }

                ball.Velocity = new Point(velocityX, velocityY);

                ball.X += ball.Velocity.X;
                ball.Y += ball.Velocity.Y;
            }
        }

        public void Collision(int numberOfBalls)
        {
            int[] circles = new int[numberOfBalls];


            for (int i = 0; i < numberOfBalls; i++)
            {
                var circle = circles[i];

                for (int j = 0; j < circles.Length; j++)
                {
                    var other = circles[i];                          
                }

            }
        }

       


        private void timer1_Tick(object sender, EventArgs e)
        {
            calculateDelta();
            BallMove();
            Draw();
            
        }
        private void BouncingBalls_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
