using MarsRover.Commands;
using MarsRover.Plateaus;
using MarsRover.Rovers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    class Nasa : INasa
    {
        private readonly IPlateau _plateau;
        private readonly List<Rover> rovers;

        public Nasa(IPlateau plateau)
        {
            rovers = new List<Rover>();
            _plateau = plateau;
        }

        public void Send(List<ICommands> commandList)
        {
            foreach (var command in commandList)
                command.Execute();
        }

        public void AddRover(Rover rover)
        {
            if (!_plateau.IsPositionValid(rover.Position))
                throw new Exception($"{rover.Position} is not valid.");

            rovers.Add(rover);
        }

        public Rover GetRover()
        {
            return rovers.Last();
        }

        public void PrintRoversLastPosition()
        {
            Dictionaries dictionary = new Dictionaries();
            foreach (var rover in rovers)
            {
                var xPosition = rover.Position.X;
                var yPosition = rover.Position.Y;
                var cardinal = dictionary.cardinalDictionary.FirstOrDefault(x => x.Value == rover.Heading).Key.ToString();
                var report = new StringBuilder();
                report.AppendFormat("{0} {1} {2}", xPosition, yPosition, cardinal);
                Console.WriteLine(report);
            }
            Console.ReadLine();
        }
    }
}
