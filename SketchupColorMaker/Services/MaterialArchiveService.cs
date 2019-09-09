using System.IO;
using System.IO.Compression;

namespace SketchupColorMaker.Services
{
    public class MaterialArchiveService
    {
        private readonly string _temporaryFolderPath;
        private readonly string _folderName;

        public MaterialArchiveService(string temporaryFolderPath, string folderName)
        {
            _temporaryFolderPath = temporaryFolderPath;
            _folderName = folderName;
        }

        public void CreateArchive(string archiveName)
        {
            if (!Directory.Exists(_folderName))
                Directory.CreateDirectory(_folderName);

            ZipFile.CreateFromDirectory(_temporaryFolderPath, $"{_folderName}/{archiveName}.skm");
        }

    }
}
