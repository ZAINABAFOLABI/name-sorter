using System.Collections.Generic;
using System.Threading.Tasks;

namespace name_sorter.core.Services.Interfaces
{
   public interface ITextWriter
    {
        ///<summary>
        ///Writes texts to a source.
        ///</summary>
        ///<param name="text">The text to write.</param>
        ///<returns></returns>
        
        Task WriteTextAsync(string text);

    }
}
