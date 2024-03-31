using name_sorter.core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace name_sorter.core.Services
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
