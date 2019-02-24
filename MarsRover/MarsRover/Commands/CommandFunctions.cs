using MarsRover.Plateaus;
using MarsRover.Rovers;

namespace MarsRover.Commands
{
    public interface ICommands
    {
        void Execute();
    }

    class CommandFunctions
    {
        public class SetPlateauCommand : ICommands
        {
            private readonly IPlateau _plateau;
            private Location size;

            public SetPlateauCommand(IPlateau plateau, Location size)
            {
                _plateau = plateau;
                this.size = size;
            }

            public void Execute()
            {
                _plateau.SetSize(size);
            }
        }

        public class NewRoverCommand : ICommands
        {
            private Location position;
            private Cardinal cardinal;
            private readonly INasa _nasa;
            private readonly IPlateau _plateau;

            public NewRoverCommand(INasa nasa, IPlateau plateau, Location position, Cardinal cardinal)
            {
                _nasa = nasa;
                _plateau = plateau;
                this.position = position;
                this.cardinal = cardinal;
            }

            public void Execute()
            {
                _nasa.AddRover(new Rover(_plateau, position, cardinal));
            }
        }

        public class ControlRoverCommand : ICommands
        {
            private Rotation rotation;
            private readonly INasa _nasa;

            public ControlRoverCommand(INasa nasa, Rotation rotation)
            {
                _nasa = nasa;
                this.rotation = rotation;
            }

            public void Execute()
            {
                var rover = _nasa.GetRover();
                rover.Control(rotation);
            }
        }

    }
}
