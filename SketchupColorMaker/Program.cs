using CommandLine;
using SketchupColorMaker.Services;
using System;

namespace SketchupColorMaker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(OnParsedArguments);


            Console.WriteLine("End");
            Console.ReadKey();
        }

        private static void OnParsedArguments(Options options)
        {
            Console.WriteLine("Generating items...");
            var materialsService = new MaterialsService(options.FileName);
            materialsService.Execute();
        }
    }
}
