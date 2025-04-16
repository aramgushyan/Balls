using System.Collections.Generic;

namespace Ball
{
    public class MoveBall:IMoveable
    {
        Random _rnd = new Random();
        public void Move(DtoBall dtoBall, ref bool isStarted)
        {
            Panel panel1 = dtoBall.Panel;
            List <IBall> balls = dtoBall.Balls;
            IBall ball = dtoBall.Ball;

            while (isStarted)
            {
                int x = _rnd.Next(50, panel1.ClientSize.Width - 15);
                int y = _rnd.Next(50, panel1.ClientSize.Height - 15);
                Thread.Sleep(_rnd.Next(500, 900));

               ball.Label.Location = new Point(x, y);

                if (!panel1.ClientRectangle.Contains(ball.Label.Bounds))
                {
                    balls.Remove(ball);
                    ball.Label.Dispose();
                }
            }
        }
    }
}
