using Memphis.Shell;

namespace Memphis.Commands
{
    public class Echo : Command
    {
        public override string Id
        {
            get
            {
                return "echo";
            }
        }

        public override void Main(string[] args)
        {
            string output = args.Join(" ");
            if (output.EndsWith("/b"))
            {
                output = output.Substring(0,output.Length - 2);
            } else
            {
                output += "\n";
            }
            ((DefaultShell)currentShell).output += output;
            Kernel.Call((byte)Kernel.Calls.UpdateShellWriter);
        }
    }
}
