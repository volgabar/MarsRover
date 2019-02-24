using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Rovers
{
    public interface IRover
    {
        void Control(Rotation rotation);

        void TurnLeft();

        void TurnRight();

        void Move();
    }
}
