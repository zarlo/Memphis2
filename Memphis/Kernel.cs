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
        }

        protected override void Run()
        {
            features["Default Shell"].Work();
        }
    }
}