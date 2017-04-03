using Memphis.Extensions;

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
                currentShell.GetFilesystem().SetCurrentDirectory(currentShell.GetFilesystem().GetCurrentDirectory().Up());
            }
            else
            {
                currentShell.GetFilesystem().SetCurrentDirectory(dir);
            }
        }
    }
}
