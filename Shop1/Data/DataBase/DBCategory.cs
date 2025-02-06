using MySql.Data.MySqlClient;
using Shop1.Data.Common;
using Shop1.Data.Interfaces;
using Shop1.Data.Models;
using System.Collections.Generic;

namespace Shop1.Data.DataBase
{
    public class DBCategory : ICategorys
    {
        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                List<Categorys> categorys = new List<Categorys>();
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                MySqlDataReader CategorysData = Connection.MySqlQuery("SELECT * FROM pr37-40.Categorys ORDER BY 'Name';", MySqlConnection);
                while (CategorysData.Read())
                {
                    categorys.Add(new Categorys()
                    {
                        Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                        Name = CategorysData.IsDBNull(1) ? null : CategorysData.GetString(1),
                        Description = CategorysData.IsDBNull(2) ? null : CategorysData.GetString(2)
                    });
                }
                return categorys;
            }
        }
    }
}
