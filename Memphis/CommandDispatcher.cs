using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System;
using static System.Console;

namespace Memphis
{
    public static class CommandDispatcher
    {
        public static void Interpret(string commandString)
        {
            string lower = commandString.ToLower();
            if (lower.StartsWith("reboot"))
            {
                Power.Reboot();
            }
            else if(lower.StartsWith("echo "))
            {
                WriteLine(commandString.Remove(0, 5));
            }
            else if(lower.StartsWith("dir") || lower.StartsWith("ls"))
            {
                foreach(var dir in Directory.GetDirectories(Kernel.GetCurrentDirectory()))
                {
                    Interpret("echo [DIR] " + dir);
                }
                foreach (var file in Directory.GetFiles(Kernel.GetCurrentDirectory()))
                {
                    Interpret("echo " + file);
                }

            }
            else if(lower.StartsWith("cd "))
            {
                string dir = commandString.Remove(0, 3);
                if(dir == "..")
                {
                    Kernel.SetCurrentDirectory(Directory.GetParent(Kernel.GetCurrentDirectory()).FullName);                    
                }
                else
                {
                    Kernel.SetCurrentDirectory(dir);
                }
            }
        }
    }
}
