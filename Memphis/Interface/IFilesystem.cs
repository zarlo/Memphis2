namespace Memphis.Interface
{
    // Add all the filesystem methods, ex: WriteLine, CreateFile, etc..
    public interface IFilesystem
    {
        bool ValidateDirectory(string dir);
        void SetCurrentDirectory(string dir);
        string GetCurrentDirectory();
    }
}
