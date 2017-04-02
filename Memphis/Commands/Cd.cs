using System.IO;

namespace Memphis.Commands
{
    public class Cd : Command
    {
        public override string Id
        {
            get
            {
                return "cd";
            }
        }

        public override void Main(string[] args)
        {
            string dir = args.Join(" ");
            if (dir == "..")
            {
                currentShell.GetFilesystem().SetCurrentDirectory(Directory.GetParent(currentShell.GetFilesystem().GetCurrentDirectory()).FullName);
            }
            else
            {
                currentShell.GetFilesystem().SetCurrentDirectory(dir);
            }
        }
    }
}
