using NameSorter.Core.Services.Interfaces;

namespace NameSorter.Core.Services
{
    public class FileTextReader : ITextReader
    {
        private readonly string _filePath;
        public FileTextReader(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<ICollection<string>> ReadTextAsync()
        {
            //Handle invalid file
            if (!File.Exists(_filePath) || !Path.HasExtension(".txt"))
            {
                Console.WriteLine("Invalid file as first argument.");
                return Array.Empty<string>();

            }
            return await File.ReadAllLinesAsync(_filePath);
        }
    }
}
