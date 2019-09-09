using SketchupColorMaker.Model;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SketchupColorMaker.Creators
{
    public class DocumentFileCreator
    {
        private readonly ColorModel _colorModel;

        public DocumentFileCreator(ColorModel colorModel)
        {
            _colorModel = colorModel;
        }

        public void CreateFile(string folderPath)
        {
            var fullFilePath = $"{folderPath}/document.xml";

            using(var reader = new StreamReader("BaseFiles\\document.xml"))
            using (var writer = new StreamWriter(fullFilePath))
            {
                var body = reader.ReadToEnd();
                var stringBuilder = new StringBuilder(body);
                stringBuilder.Replace("{#Name}", _colorModel.Name);
                stringBuilder.Replace("{#Red}", _colorModel.R.ToString());
                stringBuilder.Replace("{#Green}", _colorModel.G.ToString());
                stringBuilder.Replace("{#Blue}", _colorModel.B.ToString());

                writer.Write(stringBuilder.ToString());
            }
        }
    }
}
