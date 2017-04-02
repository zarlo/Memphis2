using Memphis.Interface;
using System.Collections.Generic;

namespace Memphis.Commands
{
    public class CommandManager : IFeature
    {
        internal FeatureInfo feature;

        public List<Command> commands;

        public CommandManager()
        {
            feature.FeatureDescription = "Manages all the commands.";
            feature.FeatureName = "Command Manager";
            feature.FeatureVersion = "0.0.1";
            commands = new List<Command>();
        }

        public void Load()
        {
            commands.Add(new Cd());
            commands.Add(new Dir());
            commands.Add(new Echo());
            commands.Add(new Reboot());
            commands.Add(new Clear());
        }

        public void RegisterCommand(Command command)
        {
            commands.Add(command);
        }

        public void ExecuteCommand(string command, string[] args, IShell currentShell)
        {
            foreach (Command c in commands)
            {
                if (c.Id.ToLower() == command.ToLower())
                {
                    c.SetShell(currentShell);
                    c.Main(args);
                    break;
                }
            }
        }

        public void Work()
        {

        }

        public FeatureInfo GetInfo()
        {
            return feature;
        }
    }
}