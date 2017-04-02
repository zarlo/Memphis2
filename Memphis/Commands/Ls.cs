namespace Memphis.Commands
{
    public class Ls : Command
    {
        public override string Id
        {
            get
            {
                return "ls";
            }
        }

        public override void Main(string[] args)
        {
            currentShell.Interpret("dir");
        }
    }
}
