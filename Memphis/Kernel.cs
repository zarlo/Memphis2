using Memphis.Interface;
using Memphis.Filesystem;
using Memphis.Shell;

namespace Memphis
{
    public class Kernel : Cosmos.System.Kernel
    {
        IShell shell;

        protected override void BeforeRun()
        {
            shell = new DefaultShell();
            shell.SetFilesystem(new FAT());
            shell.GetFilesystem().SetCurrentDirectory("0:\\");
        }

        protected override void Run()
        {
            shell.DisplayShell();
        }
    }
}