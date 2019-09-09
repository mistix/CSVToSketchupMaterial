using System.IO;

namespace SketchupColorMaker.Creators
{
    public class ReferenceFileCreator
    {
        public void CreateFile(string folderPath)
        {
            var fullFilePath = $"{folderPath}/references.xml";

            using (var reader = new StreamReader("BaseFiles\\references.xml"))
            using (var writer = new StreamWriter(fullFilePath))
            {
                var body = reader.ReadToEnd();

                writer.Write(body);
            }
        }
    }
}
