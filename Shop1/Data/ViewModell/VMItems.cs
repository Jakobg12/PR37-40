using Shop1.Data.Models;
using System.Collections.Generic;

namespace Shop1.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categorys> Categorys { get; set; }
        public int SelectCategory = 0;
    }
}
