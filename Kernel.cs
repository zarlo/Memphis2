using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Memphis.System;
using Sys = Cosmos.System;

namespace Memphis
{
    public class Kernel : Sys.Kernel
    {
        private Sys.FileSystem.CosmosVFS _fs;

        protected override void BeforeRun()
        {
            Console.WriteLine("Memphis is initializing your experience.");
            _fs = new Sys.FileSystem.CosmosVFS();
            Console.WriteLine("Filesystem engine initialized.");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(_fs);
            Console.WriteLine("Filesystem manager initiated successfully.");

        }

        public static Memphis.System.Session CurrentSession;
        private string currentDir = "0:\\";
        protected override void Run()
        {
            Console.Write("> ");

            string cmd = Console.ReadLine();

            if (cmd.StartsWith("dir"))
            {
                foreach (var dir in Directory.GetDirectories(currentDir))
                {
                    Console.WriteLine("[DIR] " + dir);
                }
                foreach (var dir in Directory.GetFiles(currentDir))
                {
                    Console.WriteLine("[FILE] " + dir);
                }

            }
            else if (cmd.StartsWith("mkdir "))
            {
                Directory.CreateDirectory(currentDir + "\\" + cmd.Remove(0, 6));
            }
            else if(cmd.StartsWith("cd "))
            {
                currentDir += "\\" + cmd.Remove(0, 3);
            }
            else if(cmd.StartsWith("read "))
            {
                Console.WriteLine(File.ReadAllText(currentDir + "\\" + cmd.Remove(0, 5)));
            }
            else if(cmd.StartsWith("write "))
            {
                string path = currentDir + "\\" + cmd.Remove(0, 6);
                string contents = Console.ReadLine();
                File.WriteAllText(path, contents);
            }
        }
    }
}
