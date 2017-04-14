using System;

using Memphis.Extensions;
using Memphis.Interface;
using Memphis.Commands;
using Memphis.Filesystem;

namespace Memphis.Shell
{
    public class DefaultShell : IShell, IFeature
    {
        IFilesystem filesystem;
        FeatureInfo feature;

        internal string output;

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
            string[] lexed = commandString.Lex(); 
            ((CommandManager)Kernel.features["Command Manager"]).ExecuteCommand(lexed[0], lexed.RemoveFirst(), this);
            lexed = null;
        }

        public void DisplayShell()
        {
                Interpret($"echo user@memphis:{filesystem.GetCurrentDirectory()}$ /b");
                string cmd = Console.ReadLine();
                Interpret(cmd);
        }

        public FeatureInfo GetInfo()
        {
            return feature;
        }

        public void Work()
        {
            DisplayShell();
        }

        public char[] GetOutput()
        {
            char[] outp = output.ToCharArray();
            output = "";
            return outp;
        }

        public void Load()
        {
            output = "";
            SetFilesystem((FAT)Kernel.features["FAT"]);
            GetFilesystem().SetCurrentDirectory("0:\\");
        }
    }
}
