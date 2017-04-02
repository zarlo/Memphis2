namespace Memphis.Interface
{
    public interface IShell
    {
        // TODO: Extend the shell interface to have user support.
        void DisplayShell();
        IFilesystem GetFilesystem();
        void SetFilesystem(IFilesystem fs);
        void Interpret(string command);
        char[] GetOutput();
    }
}
