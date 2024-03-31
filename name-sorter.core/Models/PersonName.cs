using System.Collections.Generic;
using System.Linq;

namespace name_sorter.core.Models
{
    public class PersonName
    {
        public string LastName { get; }
        public IReadOnlyList<string> OtherNames { get; }
        public PersonName(ICollection<string> names)
        {
            LastName = names.Last();
            OtherNames = names.SkipLast(1).ToList();
        }
        public override string ToString()
        {
            return $"{string.Join(" ", OtherNames)} {LastName}";
        }
    }
}
