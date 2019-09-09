using CsvHelper;
using SketchupColorMaker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SketchupColorMaker.Services
{
    public class ColorReaderService
    {
        private readonly string _fileName;

        public ColorReaderService(string fileName)
        {
            _fileName = fileName;
        }


        public IEnumerable<ColorModel> GetAllColors()
        {
            using (var reader = new StreamReader(_fileName))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = ",";
                return csv.GetRecords<ColorModel>().ToList();
            }
        }
    }
}
