using name_sorter.core.Services;

namespace name_sorter.consoleapp
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            //Handle when no file is passed
            if(args.Length == 0)
            {
                Console.WriteLine("Please pass the file name as the first argument.");
                return;
            }

            var nameSorterService = new NameSorterService(new FileTextReader(args[0]), new FileTextWriter("sorted-names-list.txt"));

            var personNames = await nameSorterService.LoadNamesAsync();
            await nameSorterService.SortAndOutputNamesAsync(personNames);

            
        }
    }
}
