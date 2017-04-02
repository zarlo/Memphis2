using System;
using System.IO;
using static System.Console;

using Cosmos.System;
using Memphis.Interface;

namespace Memphis.Shell
{
    public class DefaultShell : IShell
    {
        IFilesystem filesystem;

        public void SetFilesystem(IFilesystem fs)
        {
            filesystem = fs;
        }

        public IFilesystem GetFilesystem()
        {
            return filesystem;
        }

        public void Interpret(string commandString)
        {
            string lower = commandString.ToLower();
            if (lower.StartsWith("reboot"))
            {
                Power.Reboot();
            }
            else if (lower.StartsWith("echo "))
            {
                WriteLine(commandString.Remove(0, 5));
            }
            else if (lower.StartsWith("dir") || lower.StartsWith("ls"))
            {
                foreach (var dir in Directory.GetDirectories(filesystem.GetCurrentDirectory()))
                {
                    Interpret("echo [DIR] " + dir);
                }
                foreach (var file in Directory.GetFiles(filesystem.GetCurrentDirectory()))
                {
                    Interpret("echo " + file);
                }

            }
            else if (lower.StartsWith("cd "))
            {
                string dir = commandString.Remove(0, 3);
                if (dir == "..")
                {
                    filesystem.SetCurrentDirectory(Directory.GetParent(filesystem.GetCurrentDirectory()).FullName);
                }
                else
                {
                    filesystem.SetCurrentDirectory(dir);
                }
            }
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
    }
}