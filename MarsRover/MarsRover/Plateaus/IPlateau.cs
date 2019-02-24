using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Plateaus
{
    public interface IPlateau
    {
        void SetSize(Location size);

        bool IsPositionValid(Location position);
    }
}
