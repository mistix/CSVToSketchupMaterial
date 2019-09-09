using System.IO;

namespace SketchupColorMaker.Services
{
    internal class FolderService
    {
        public string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);

            return tempDirectory;
        }

        public void ClearFolder(string folderName)
        {
            var directoryInfo = new DirectoryInfo(folderName);

            foreach (var item in directoryInfo.GetFiles())
                item.Delete();
        }
    }
}
