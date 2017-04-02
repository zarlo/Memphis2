﻿using System;

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