using name_sorter.core.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace name_sorter.core.Services
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
