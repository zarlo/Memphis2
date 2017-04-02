using Memphis.Shell;
using Memphis.Commands;
using Memphis.Filesystem;

namespace Memphis
{
    public class Kernel : Cosmos.System.Kernel
    {
        public static Features features = new Features();

        protected override void BeforeRun()
        {
            features.AddFeature(new CommandManager());
            features.AddFeature(new FAT());
            features.AddFeature(new DefaultShell());
            features.AddFeature(new ShellWriter());
        }

        protected override void Run()
        {
            features["Default Shell"].Work();
        }
        public enum Calls
        {
            UpdateShellWriter = 0,
        }

        public static void Call(byte call)
        {
            switch(call)
            {
                case 0:
                    features["Shell Writer"].Work();
                    break;
            }
        }

    }
}