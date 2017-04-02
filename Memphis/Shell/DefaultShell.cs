using System;

using Memphis.Interface;
using Memphis.Commands;
using Memphis.Filesystem;

using static System.Console;

namespace Memphis.Shell
{
    public class DefaultShell : IShell, IFeature
    {
        IFilesystem filesystem;
        FeatureInfo feature;

        public void SetFilesystem(IFilesystem fs)
        {
            filesystem = fs;
        }

        public DefaultShell()
        {
            feature.FeatureName = "Default Shell";
            feature.FeatureDescription = "The default shell for Memphis.";
            feature.FeatureVersion = "0.0.1";
        }

        public IFilesystem GetFilesystem()
        {
            return filesystem;
        }

        public void Interpret(string commandString)
        {
            string[] lexed = commandString.Split(' '); // Bad way to split the arguments, but eh..

            // TODO: Implement a proper lexer to split the arguments.

            string command = lexed[0];
            string[] args = new string[lexed.Length > 1 ? lexed.Length - 1 : 0];

            for (int i = 1; i < lexed.Length; i++)
                args[i - 1] = lexed[i];

            ((CommandManager)Kernel.features["Command Manager"]).ExecuteCommand(command, args, this);
        }

        public void DisplayShell()
        {
            try
            {
                Write($"user@memphis:{filesystem.GetCurrentDirectory()}$ ");
                string cmd = ReadLine();
                Interpret(cmd);
            }
            catch (Exception ex)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Kernel error:");
                WriteLine(ex.ToString());
                ForegroundColor = ConsoleColor.White;
            }
        }

        public FeatureInfo GetInfo()
        {
            return feature;
        }

        public void Work()
        {
            DisplayShell();
        }

        public void Load()
        {
            SetFilesystem((FAT)Kernel.features["FAT"]);
            GetFilesystem().SetCurrentDirectory("0:\\");
        }
    }
}