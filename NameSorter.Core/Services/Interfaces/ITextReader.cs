using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameSorter.Core.Services.Interfaces
{
    public interface ITextReader
    {
        ///<summary>
        ///Reads texts from a source.
        ///</summary>
        ///<returns>A collection of texts lines.</returns>
        
        Task<ICollection<string>> ReadTextAsync();

    }
}
