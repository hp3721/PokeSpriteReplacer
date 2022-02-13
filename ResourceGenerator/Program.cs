using System.Resources;
using System.Drawing;
using System.IO;
using System;

namespace ResourceGenerator
{
    class Program
    {
        static IResourceWriter writer = new ResourceWriter("PokeSprite.resources");

        static void Main(string[] args)
        {
            var filePath = args[0];
            ProcessDirectory(filePath);
            writer.Generate();
            writer.Close();
        }

        // https://stackoverflow.com/a/5181424
        public static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // https://stackoverflow.com/a/5181424
        public static void ProcessFile(string path)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            var img = new Bitmap(path);
#pragma warning restore CA1416 // Validate platform compatibility
            writer.AddResource(Path.GetFileNameWithoutExtension(path), img);
            Console.WriteLine("Processed file '{0}'.", path);
        }
    }
}