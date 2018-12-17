using System.IO;
using System.IO.Compression;

namespace Lemmy.Tools.SolutionComposer
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("lemmy.zip");
            using (var archive = ZipFile.Open("lemmy.zip", ZipArchiveMode.Create))
            {
                var files = Directory.GetFiles(args[0], "*.cs", SearchOption.AllDirectories);
                var counter = 0;
                foreach (var file in files)
                {
                    var targetFileName = $"{counter++}";
                    if (string.Equals(Path.GetFileNameWithoutExtension(file), "MyStrategy"))
                    {
                        targetFileName = "MyStrategy";
                    }
                    archive.CreateEntryFromFile(file, $"{targetFileName}.cs");
                }
            }
        }
    }
}
