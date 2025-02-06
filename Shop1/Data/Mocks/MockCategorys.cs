using Shop1.Data.Interfaces;
using System.Collections.Generic;

namespace Shop1.Data.Mocks
{
    public class MockCategorys : ICategorys
    {
        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                return new List<Categorys>()
                {
                    new Categorys()
                    {
                        Id = 1,
                        Name = "Перифирия",
                        Description = "Предметы для взаимодействия с ПК"
                    },
                    new Categorys()
                    {
                        Id = 2,
                        Name = "Компоненты ПК",
                        Description = "Компоненты из которых состоит ПК"
                    }
                };
            }
        }
    }
}
