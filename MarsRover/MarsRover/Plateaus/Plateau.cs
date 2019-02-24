using System;

namespace MarsRover.Plateaus
{
    class Plateau: IPlateau
    {
        private Location size;

        public void SetSize(Location size)
        {
            if (this.size != null)
                throw new Exception("Plateau is already initialized.");

            this.size = size;
        }

        public bool IsPositionValid(Location position)
        {
            return position.X >= 0 && position.X <= size.X && position.Y >= 0 && position.Y <= size.Y;
        }
    }
}
