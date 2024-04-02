using NameSorter.Core.Services.Interfaces;

namespace NameSorter.Core.Services
{
    public class FileTextWriter : ITextWriter
    {
        private readonly string _filePath;
        public FileTextWriter(string filePath)
        {
            _filePath = filePath;
        }
       
        public async Task WriteTextAsync(string text)
        {
            await File.WriteAllTextAsync(_filePath, text, System.Text.Encoding.UTF8);
        }
    }
}
