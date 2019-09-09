using CommandLine;

namespace SketchupColorMaker
{
    internal class Options
    {
        [Option('f', "filename", Required = true, HelpText = "Name of file to export colors")]
        public string FileName { get; set; }
    }
}
