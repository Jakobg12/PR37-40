using Shop1.Data.Models;
using System.Collections.Generic;

namespace Shop1.Data.Interfaces
{
    public interface ICategorys
    {
        public IEnumerable<Categorys> AllCategorys { get; }
    }
}
    