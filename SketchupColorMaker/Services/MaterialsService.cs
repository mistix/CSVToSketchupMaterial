using SketchupColorMaker.Creators;
using System;

namespace SketchupColorMaker.Services
{
    public class MaterialsService
    {
        private const string FolderName = "Materials";
        private readonly ColorReaderService _colorReaderService;
        private readonly FolderService _folderService;

        public MaterialsService(string filename)
        {
            _colorReaderService = new ColorReaderService(filename);
            _folderService = new FolderService();
        }

        public void Execute()
        {
            var colors = _colorReaderService.GetAllColors();
            var colorCount = 1;

            _folderService.ClearFolder(FolderName);

            foreach (var color in colors)
            {
                Console.WriteLine($"Working on file {colorCount}");

                var temporaryFolder = _folderService.GetTemporaryDirectory();

                var documentCreator = new DocumentFileCreator(color);
                documentCreator.CreateFile(temporaryFolder);

                var documentPropertiesCreator = new DocumentPropertiesFileCreator(color);
                documentPropertiesCreator.CreateFile(temporaryFolder);

                var thumbnailCreator = new ThumbnailCreator(color);
                thumbnailCreator.CreateThumbnail(temporaryFolder);

                var referenceCreator = new ReferenceFileCreator();
                referenceCreator.CreateFile(temporaryFolder);

                var materialArchive = new MaterialArchiveService(temporaryFolder, FolderName);
                materialArchive.CreateArchive(color.Name);

                colorCount++;
            }
        }
    }
}
