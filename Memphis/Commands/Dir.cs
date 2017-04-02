using System.IO;

namespace Memphis.Commands
{
    public class Dir : Command
    {
        public override string Id
        {
            get
            {
                return "dir";
            }
        }

        public override void Main(string[] args)
        {
            foreach (var dir in Directory.GetDirectories(currentShell.GetFilesystem().GetCurrentDirectory()))
            {
                currentShell.Interpret("echo [DIR] " + dir);
            }
            foreach (var file in Directory.GetFiles(currentShell.GetFilesystem().GetCurrentDirectory()))
            {
                currentShell.Interpret("echo " + file);
            }
        }
    }
}
