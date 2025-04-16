using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    public class Ball : Label,IBall
    {
        IMoveable _moveable;
        public Ball(IMoveable moveable)
        {
            _moveable = moveable;
        }
        public void BallMove(DtoBall dtoBall, ref bool isStarted)
        {
            dtoBall.Ball =  this;
            _moveable.Move(dtoBall, ref isStarted);
        }
        public Label Label 
        {
            get 
            {
                return this;
            }
        }
        

    }
}
