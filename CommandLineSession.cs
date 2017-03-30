using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memphis.System;

namespace Memphis
{
    public class CommandLineSession : Session
    {
        public override void Begin(Argument[] args)
        {
            Console.Clear();
            Console.WriteLine("Memphis - v1.0");
            Console.WriteLine("Copyright (c) 2017 Michael VanOverbeek. Licensed under MIT.");
        }

        public override ExitCode End()
        {
            Cosmos.System.Power.Reboot();
            return ExitCode.Normal;
        }

        private string currentDir = @"0:\";

        public override void Loop()
        {
            Console.Write("> ");

            string cmd = Console.ReadLine();

            if (cmd.StartsWith("dir"))
            {
                foreach (var dir in Directory.GetDirectories(currentDir))
                {
                    Console.WriteLine("[DIR] " +dir);
                }
                foreach (var dir in Directory.GetFiles(currentDir))
                {
                    Console.WriteLine("[FILE] " + dir);
                }

            }
        }
    }
}
