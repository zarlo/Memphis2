using Cosmos.System;

namespace Memphis.Commands
{
    public class Reboot : Command
    {
        public override string Id
        {
            get
            {
                return "reboot";
            }
        }

        public override void Main(string[] args)
        {
            Power.Reboot();
        }
    }
}
