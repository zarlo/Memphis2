using System;

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

        // TODO: Implement shell text buffer and make echo write to it.

        public override void Main(string[] args)
        {
            Console.WriteLine(args.Join(" "));
        }
    }
}
