using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Ball
{
    public partial class Form1 : Form
    {
        IMoveable _moveable;

        List<Ball> _balls = new List<Ball>();

        List<Thread> _threads = new List<Thread>();

        int i = 1;

        bool _isStarted = false;

        public Form1(IMoveable moveable)
        {
            InitializeComponent();
            _moveable = moveable;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (!_isStarted)
            {
                _isStarted = true;
                AddThread();
            }
            button3.Enabled = true;
            button1.Enabled = false;
        }

        private void AddThread()
        {
            foreach (Ball ball in _balls)
            {
                Thread thread = new Thread(() => ball.BallMove(new DtoBall()
                {
                    Panel = panel1,
                    Balls = _balls
                },ref _isStarted));
                thread.IsBackground = true;
                _threads.Add(thread);
                thread.Start();
            }
        }

        //private void MoveLabel(Label label)
        //{
        //    while (_isStarted)
        //    {
        //        int x = _rnd.Next(50, panel1.ClientSize.Width - 15);
        //        int y = _rnd.Next(50, panel1.ClientSize.Height - 15);
        //        Thread.Sleep(_rnd.Next(500, 900));

        //        label.Location = new Point(x, y);

        //        if (!panel1.ClientRectangle.Contains(label.Bounds))
        //        {
        //            _balls.Remove(label);
        //            label.Dispose();
        //        }
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            CreateLabel();
            if (_isStarted)
            {
                StopThreads();
                button1_Click(sender, e);
            }
        }

        private void CreateLabel()
        {
            Ball buffer = new Ball(_moveable);
            buffer.Text = $"Øàð {i}";
            buffer.AutoSize = true;
            buffer.Location = new Point(50, 50);
            i += 1;
            panel1.Controls.Add(buffer);
            buffer.BringToFront();
            _balls.Add(buffer);
        }

        private void StopThreads()
        {
            _isStarted = false;
            foreach (Thread t in _threads)
            {
                t.Join();
            }
            _threads.Clear();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = false;
            StopThreads();
        }
    }
}