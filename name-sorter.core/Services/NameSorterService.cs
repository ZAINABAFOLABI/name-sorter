using name_sorter.core.Models;
using name_sorter.core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.core.Services
{
    public class NameSorterService: INameSorterService
    {
        private readonly ITextReader _textReader;
        private readonly ITextWriter _textWriter;

        public NameSorterService(ITextReader textReader, ITextWriter textWriter)
        {
            _textReader = textReader;
            _textWriter = textWriter;
            
        }

        public async Task<ICollection<PersonName>> LoadNamesAsync()
        {
            var rawNames = await _textReader.ReadTextAsync();
            var personNames = new List<PersonName>(rawNames.Count);

            foreach (var rawName in rawNames)
            {
                var names = rawName.Trim().Split(" ");
                if (names.Length < 2)
                {
                    Console.WriteLine($"{rawName} is invalid. A name should have 1 last name and at least 1 given name.");
                    continue;
                }

                personNames.Add(new PersonName(names));
            }

            return personNames;
        }

        public async Task SortAndOutputNamesAsync(ICollection<PersonName> names)
        {
            var sortedNames = names.OrderBy(name => name.LastName);
            var outputTextBuilder = new StringBuilder();

            foreach (var name in sortedNames) 
            {
                Console.WriteLine(name.ToString());
                outputTextBuilder.AppendLine(name.ToString());
            }

            var outputText = names.Count > 0
                ? outputTextBuilder.ToString(0, outputTextBuilder.Length - Environment.NewLine.Length)
                : outputTextBuilder.ToString();

            await _textWriter.WriteTextAsync(outputText);

        }
    }
}
