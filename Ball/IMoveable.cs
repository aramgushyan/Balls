using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    public interface IMoveable
    {
        public void Move(DtoBall dtoBall,ref bool isStarted);

    }
}
