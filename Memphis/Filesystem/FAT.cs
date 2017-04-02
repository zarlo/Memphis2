using System.IO;

using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Memphis.Interface;

namespace Memphis.Filesystem
{
    class FAT : IFilesystem
    {
        public static bool isLoaded = false;

        public FAT()
        {
            if (!isLoaded)
            {
                isLoaded = true;
                _fs = new CosmosVFS();
                VFSManager.RegisterVFS(_fs);
            }
        }

        public string GetCurrentDirectory()
        {
            return _currentDir;
        }

        private static CosmosVFS _fs;
        private string _currentDir = "0:\\";

        public bool ValidateDirectory(string dir)
        {
            if (Directory.Exists(dir))
                return true;
            return false;
        }

        public void SetCurrentDirectory(string path)
        {
            if (ValidateDirectory(_currentDir + path))
            {
                _currentDir += path;
                return;
            }
            if (ValidateDirectory(_currentDir + "\\" + path))
            {
                _currentDir += "\\" + path;
                return;
            }

            if (ValidateDirectory(path))
            {
                _currentDir = path;
                return;
            }
        }
    }
}
