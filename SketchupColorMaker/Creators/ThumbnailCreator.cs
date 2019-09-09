using SketchupColorMaker.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace SketchupColorMaker.Creators
{
    public class ThumbnailCreator
    {
        private readonly ColorModel _colorModel;

        public ThumbnailCreator(ColorModel colorModel)
        {
            _colorModel = colorModel;
        }

        public void CreateThumbnail(string folderPath)
        {
            var fullPath = $"{folderPath}/doc_thumbnail.png";
            var bitmap = new Bitmap(256, 256);
            var graphic = Graphics.FromImage(bitmap);

            var color = Color.FromArgb(_colorModel.R, _colorModel.G, _colorModel.B);

            graphic.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, 256, 256));

            using (var writeFile = File.Create(fullPath))
                bitmap.Save(writeFile, ImageFormat.Png);
        }
    }
}
