using SketchupColorMaker.Model;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SketchupColorMaker.Creators
{
    public class DocumentPropertiesFileCreator
    {
        private readonly ColorModel _colorModel;

        public DocumentPropertiesFileCreator(ColorModel colorModel)
        {
            _colorModel = colorModel;
        }

        public void CreateFile(string folderPath)
        {
            var fullFilePath = $"{folderPath}/documentProperties.xml";

            using(var reader = new StreamReader("BaseFiles\\documentProperties.xml"))
            using (var writer = new StreamWriter(fullFilePath))
            {
                var body = reader.ReadToEnd();
                var replacedValues = body.Replace("{#Name}", _colorModel.Name);

                writer.Write(replacedValues);
            }
        }
    }
}
