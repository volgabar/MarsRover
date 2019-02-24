using MarsRover.Plateaus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static MarsRover.Commands.CommandFunctions;

namespace MarsRover.Commands
{
    public interface ICommandParser
    {
        List<ICommands> Parse(string commandInput);
    }

    public class CommandParser : ICommandParser
    {
        private Dictionaries dictionary = new Dictionaries();
        private readonly IPlateau _plateau;
        private readonly INasa _nasa;
        private List<ICommands> commandList = new List<ICommands>();

        public CommandParser(IPlateau plateau, INasa nasa)
        {
            _plateau = plateau;
            _nasa = nasa;
        }

        public List<ICommands> Parse(string commandInput)
        {
            try
            {
                string[] commands = Regex.Split(commandInput, "\r\n|\r|\n");
                foreach (string command in commands)
                {
                    CommandType commandType = dictionary.commandTypeMatchingDictionary.Where(type => Regex.Match(command, type.Key, RegexOptions.Singleline).Success).Select(type => type.Value).First();
                    string[] commandArray = command.Replace(" ", "").ToCharArray().Select(c => c.ToString()).ToArray();
                    switch (commandType)
                    {
                        case CommandType.SetPlateau:
                            commandList.Add(new SetPlateauCommand(_plateau, new Location(int.Parse(commandArray[0]), int.Parse(commandArray[1]))));
                            break;
                        case CommandType.NewRover:
                            commandList.Add(new NewRoverCommand(_nasa, _plateau, new Location(int.Parse(commandArray[0]), int.Parse(commandArray[1])), dictionary.cardinalDictionary[commandArray[2]]));
                            break;
                        case CommandType.ControlRover:
                            foreach (string rotationCommand in commandArray)
                            {
                                commandList.Add(new ControlRoverCommand(_nasa, dictionary.rotationDictionary[rotationCommand]));
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception($"Command is not valid.");
            }
            return commandList;
        }
    }
}
