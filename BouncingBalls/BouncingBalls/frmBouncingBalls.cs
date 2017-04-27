using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BouncingBalls
{
    public partial class frmBouncingBalls : Form
    {
        Graphics graphics;
        Timer timer;
        List<Ball> _balls;
        int _numberOfBalls = 3;
        long? _lastTime;
        double _delta;
        Stopwatch _stopWatch;

        public frmBouncingBalls()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Text = "Bouncing Balls";
            SetClientSizeCore(600, 400);
            DoubleBuffered = true;
            StartPosition = FormStartPosition.CenterScreen;

            _stopWatch = new Stopwatch();

            timer = new Timer();
            timer.Interval = 1000 / 30;
            timer.Tick += Timer_Tick;

            this.Click += FrmBouncingBalls_Click;
            this.Shown += FrmBouncingBalls_Shown;
        }

        private void FrmBouncingBalls_Shown(object sender, System.EventArgs e)
        {
            using (frmSettings settings = new frmSettings())
            {
                if (settings.ShowDialog() != DialogResult.OK)
                    return;

                _numberOfBalls = settings.NumberOfBalls;
            }

            InitializeGame();
        }
        private void FrmBouncingBalls_Click(object sender, System.EventArgs e)
        {
            timer.Enabled = !timer.Enabled;

            if (timer.Enabled)
            {
                _stopWatch.Start();
            }
            else
            {
                _stopWatch.Stop();
            }
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            CalculateDelta();
            UpdateBallPositions();
            Draw();
        }

        private void InitializeGame()
        {
            graphics = this.CreateGraphics();
            graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            _balls = new List<Ball>();

            for (int i = 0; i < _numberOfBalls; i++)
            {
                int randomSize = GameTools.GetRandomNumber(1, 50);

                Ball b = new Ball(randomSize, randomSize);
                b.X = GameTools.GetRandomNumber(0, (int)(graphics.VisibleClipBounds.Width - b.Width));
                b.Y = GameTools.GetRandomNumber(0, (int)(graphics.VisibleClipBounds.Height - b.Height));
                b.Velocity = new Point(GameTools.GetRandomNumber(-10, 10), GameTools.GetRandomNumber(-10, 10));
                b.Color = GameTools.GetRandomColor();

                _balls.Add(b);
            }

            _stopWatch.Start();
            timer.Enabled = true;
        }
        private void CalculateDelta()
        {
            if (_lastTime == null)
                _lastTime = _stopWatch.ElapsedMilliseconds;

            long currentTime = _stopWatch.ElapsedMilliseconds;
            double tempDelta = (currentTime - (long)_lastTime) / 100.0;
            _delta = tempDelta < 1 ? tempDelta : 1;

            _lastTime = currentTime;
        }
        private void Draw()
        {
            graphics.Clear(Color.Black);

            foreach (Ball b in _balls)
            {
                SolidBrush brush = new SolidBrush(b.Color);
                graphics.FillRectangle(brush, new Rectangle(b.X, b.Y, b.Width, b.Height));
            }
            graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
        }
        private void UpdateBallPositions()
        {
            foreach (Ball b in _balls)
            {
                b.X += (int)(b.Velocity.X * _delta);
                b.Y += (int)(b.Velocity.Y * _delta);

                int velocityX = b.Velocity.X;
                int velocityY = b.Velocity.Y;

                if (b.X <= 0 || b.X > graphics.VisibleClipBounds.Width - b.Width)
                {
                    velocityX = -velocityX;
                    b.Color = GameTools.GetRandomColor();
                }

                if (b.Y <= 0 || b.Y > graphics.VisibleClipBounds.Height - b.Height)
                {
                    velocityY = -velocityY;
                    b.Color = GameTools.GetRandomColor();
                }

                b.Velocity = new Point(velocityX, velocityY);
            }
        }
    }
}