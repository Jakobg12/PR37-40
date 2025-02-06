using MySql.Data.MySqlClient;
using Shop1.Data.Common;
using Shop1.Data.Interfaces;
using Shop1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop1.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categorys> Categorys = new DBCategory().AllCategorys;
        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection MySqlConection = Connection.MySqlOpen();
                MySqlDataReader ItemsData = Connection.MySqlQuery("SELECT * FROM `pr37-40`.items ORDER BY 'Name';", MySqlConection);
                while (ItemsData.Read())
                {
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categorys.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                    });
                }
                MySqlConection.Close();
                return items;
            }
        }
        public int Add(Items Item)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"INSERT INTO `pr37-40`.`items`(`Name`,`Description`,`Img`,`Price`,`IdCategory`) VALUES ('{Item.Name}', '{Item.Description}', '{Item.Img}', '{Item.Price}', '{Item.Category.Id}');", MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;
            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT `Id` FROM `items` WHERE `Name` = '{Item.Name}' AND `Description` = '{Item.Description}' AND `Price` = {Item.Price} AND `IdCategory` = {Item.Category.Id};", MySqlConnection);
            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }
    }
}