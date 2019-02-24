using MarsRover.Plateaus;
using System;

namespace MarsRover.Rovers
{
    public class Rover : IRover
    {
        private readonly IPlateau _plateau;
        public Location Position { get; private set; }
        public Cardinal Heading { get; private set; }

        public Rover(IPlateau plateau, Location position, Cardinal heading)
        {
            _plateau = plateau;
            Position = position;
            Heading = heading;
        }

        public void Control(Rotation rotation)
        {
            switch (rotation)
            {
                case Rotation.Left:
                    TurnLeft();
                    break;
                case Rotation.Right:
                    TurnRight();
                    break;
                case Rotation.Move:
                    Move();
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Heading)
            {
                case Cardinal.North:
                    Heading = Cardinal.West;
                    break;
                case Cardinal.South:
                    Heading = Cardinal.East;
                    break;
                case Cardinal.East:
                    Heading = Cardinal.North;
                    break;
                case Cardinal.West:
                    Heading = Cardinal.South;
                    break;
            }

        }

        public void TurnRight()
        {
            switch (Heading)
            {
                case Cardinal.North:
                    Heading = Cardinal.East;
                    break;
                case Cardinal.South:
                    Heading = Cardinal.West;
                    break;
                case Cardinal.East:
                    Heading = Cardinal.South;
                    break;
                case Cardinal.West:
                    Heading = Cardinal.North;
                    break;
            }
        }

        public void Move()
        {
            Location newPosition;
            switch (Heading)
            {
                case Cardinal.North:
                    newPosition = new Location(Position.X, Position.Y + 1);
                    if (!_plateau.IsPositionValid(newPosition))
                    {
                        throw new ArgumentException("location", $"{newPosition} is not valid. Cannot move towards {Heading} from current position {Position}.");
                    }

                    Position = newPosition;
                    break;
                case Cardinal.South:
                    newPosition = new Location(Position.X, Position.Y - 1);
                    if (!_plateau.IsPositionValid(newPosition))
                    {
                        throw new ArgumentException("location", $"{newPosition} is not valid. Cannot move towards {Heading} from current position {Position}.");
                    }

                    Position = newPosition;
                    break;
                case Cardinal.East:
                    newPosition = new Location(Position.X + 1, Position.Y);
                    if (!_plateau.IsPositionValid(newPosition))
                    {
                        throw new ArgumentException("location", $"{newPosition} is not valid. Cannot move towards {Heading} from current position {Position}.");
                    }

                    Position = newPosition;
                    break;
                case Cardinal.West:
                    newPosition = new Location(Position.X - 1, Position.Y);
                    if (!_plateau.IsPositionValid(newPosition))
                    {
                        throw new ArgumentException("location", $"{newPosition} is not valid. Cannot move towards {Heading} from current position {Position}.");
                    }

                    Position = newPosition;
                    break;
            }
        }
    }
}
