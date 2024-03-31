using name_sorter.core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace name_sorter.core.Services.Interfaces
{
    public interface INameSorterService
    {
        ///<summary>
        ///Loads names from a reader.
        ///</summary>
        ///<returns>A collection of person names.</returns>
        Task<ICollection<PersonName>> LoadNamesAsync();

        ///<summary>
        ///Sort persons' names and output them to a writer.
        ///<param name="names">An unordered list of person names.</param>
        ///</summary>
        ///<returns></returns>
        
        Task SortAndOutputNamesAsync(ICollection<PersonName> names);

    }
}
