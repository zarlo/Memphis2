using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Sys = Cosmos.System;
using System.IO;

namespace Memphis
{
    public class Kernel : Sys.Kernel
    {
        CosmosVFS _fs = null;

        protected override void BeforeRun()
        {
            _fs = new CosmosVFS();
            VFSManager.RegisterVFS(_fs);

            SetCurrentDirectory("0:\\"); // This doesn't seem to ACTUALLY set the current directory...
        }

        private static string _currentDir = "0:\\";

        public static string GetCurrentDirectory()
        {
            return _currentDir;
        }

        public static bool ValidateDirectory(string dir)
        {
            if (Directory.Exists(dir))
                return true;
            return false;
        }

        public static void SetCurrentDirectory(string path)
        {
            if (ValidateDirectory(_currentDir + path))
            {
                _currentDir += path;
                return;
            }
            if (ValidateDirectory(_currentDir + "\\" + path))
            {
                _currentDir += "\\" + path;
                return;
            }

            if (ValidateDirectory(path))
            {
                _currentDir = path;
                return;
            }


        }

        protected override void Run()
        {
            try
            {
                Console.Write($"user@memphis:{GetCurrentDirectory()}$ "); //Outputs "user@memphis:$ ".
                string cmd = Console.ReadLine();
                CommandDispatcher.Interpret(cmd);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Kernel error:");
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
