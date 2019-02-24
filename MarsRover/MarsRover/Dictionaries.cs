using MarsRover.Commands;
using MarsRover.Rovers;
using System.Collections.Generic;

namespace MarsRover
{
    public class Dictionaries
    {
        public readonly IDictionary<string, CommandType> commandTypeMatchingDictionary;
        public readonly IDictionary<string, Cardinal> cardinalDictionary;
        public readonly IDictionary<string, Rotation> rotationDictionary;

        public Dictionaries()
        {
            commandTypeMatchingDictionary = new Dictionary<string, CommandType>
            {
                { @"^\d+ \d+$", CommandType.SetPlateau },
                { @"^\d+ \d+ [NSEW]$", CommandType.NewRover },
                { @"^[MLR]+$", CommandType.ControlRover }
            };

            cardinalDictionary = new Dictionary<string, Cardinal>
            {
                 {"N", Cardinal.North},
                 {"S", Cardinal.South},
                 {"E", Cardinal.East},
                 {"W", Cardinal.West}
            };

            rotationDictionary = new Dictionary<string, Rotation>
            {
                 {"M", Rotation.Move},
                 {"L", Rotation.Left},
                 {"R", Rotation.Right}
            };
        }
    }
}
