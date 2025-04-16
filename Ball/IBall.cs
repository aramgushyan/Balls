using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    public interface IBall
    {
        public void BallMove(DtoBall dtoBall, ref bool isStarted);
        public Label Label { get;}

    }
}
