using MarsRover.Commands;
using MarsRover.Rovers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public interface INasa
    {
        void AddRover(Rover rover);
        Rover GetRover();
        void Send(List<ICommands> commandList);
        void PrintRoversLastPosition();
    }
}
