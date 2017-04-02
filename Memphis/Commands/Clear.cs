using System;

namespace Memphis.Commands
{
    public class Clear : Command
    {
        public override string Id
        {
            get
            {
                return "clear";
            }
        }

        public override void Main(string[] args)
        {
            Console.Clear();
        }
    }
}
