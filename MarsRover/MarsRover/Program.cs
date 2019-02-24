using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Commands;
using MarsRover.Plateaus;
using MarsRover.Rovers;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddScoped<INasa, Nasa>()
                .AddScoped<ICommandParser, CommandParser>()
                .AddScoped<IPlateau, Plateau>()
                .BuildServiceProvider();

            ICommandParser commandParser = serviceProvider.GetService<ICommandParser>();
            INasa nasa = serviceProvider.GetService<INasa>();

            var commandsInput = new StringBuilder();
            commandsInput.AppendLine("5 5");
            commandsInput.AppendLine("1 2 N");
            commandsInput.AppendLine("LMLMLMLMM");
            commandsInput.AppendLine("3 3 E");
            commandsInput.Append("MMRMMRMRRM");

            List<ICommands> commandList = commandParser.Parse(commandsInput.ToString());
            nasa.Send(commandList);
            nasa.PrintRoversLastPosition();
        }
    }
}
