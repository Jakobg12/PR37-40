using Shop1.Data.Models;
using System.Collections.Generic;

namespace Shop1.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
    }
}

