﻿using MySql.Data.MySqlClient;
using Shop1.Data.Common;
using Shop1.Data.Interfaces;
using Shop1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop1.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Models.Categorys> Categorys = new DBCategory().AllCategorys;

        public IEnumerable<Models.Items> AllItems
        {
            get
            {
                List<Models.Items> items = new List<Models.Items>();
                MySqlConnection MySqlConnection = Common.Connection.MySqlOpen();
                MySqlDataReader ItemsReader = Common.Connection.MySqlQuery("Select * from `pr37-40`.items Order By 'Name';", MySqlConnection);
                while (ItemsReader.Read())
                {
                    items.Add(new Models.Items()
                    {
                        Id = ItemsReader.IsDBNull(0) ? -1 : ItemsReader.GetInt32(0),
                        Name = ItemsReader.IsDBNull(1) ? null : ItemsReader.GetString(1),
                        Description = ItemsReader.IsDBNull(2) ? null : ItemsReader.GetString(2),
                        Img = ItemsReader.IsDBNull(3) ? null : ItemsReader.GetString(3),
                        Price = ItemsReader.IsDBNull(4) ? -1 : ItemsReader.GetInt32(4),
                        Category = ItemsReader.IsDBNull(5) ? null : Categorys.First(x => x.Id == ItemsReader.GetInt32(5))
                    });
                }
                MySqlConnection.Close();
                return items;
            }
        }

        public IEnumerable<Items> FindItems(string searchString)
        {
            List<Items> foundItems = new List<Items>();
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            string query = "SELECT * FROM `pr37-40`.items WHERE Name LIKE @search OR Description LIKE @search;";
            MySqlCommand command = new MySqlCommand(query, MySqlConnection);
            command.Parameters.AddWithValue("@search", "%" + searchString + "%");
            MySqlDataReader ItemsData = command.ExecuteReader();
            while (ItemsData.Read())
            {
                foundItems.Add(new Items()
                {
                    Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                    Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                    Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                    Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                    Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                    Category = ItemsData.IsDBNull(5) ? null : Categorys.FirstOrDefault(x => x.Id == ItemsData.GetInt32(5))
                });
            }
            MySqlConnection.Close();
            return foundItems;
        }

        public int Add(Items item)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"Insert into `pr37-40`.`items` (`Name`, `Description`, `Img`, `Price`, `IdCategory`) Values ('{item.Name}', '{item.Description}', '{item.Img}', {item.Price}, {item.Category.Id});", MySqlConnection);
            MySqlConnection.Close();
            int IdItem = -1;
            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery($"Select `Id` from `items` where `Name` = '{item.Name}' and `Description` = '{item.Description}' and `Price` = {item.Price} and `IdCategory` = {item.Category.Id};", MySqlConnection);
            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }

        public void Delete(int id)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery(
                $"DELETE FROM `pr37-40`.items WHERE Id = {id}", mySqlConnection);
            mySqlConnection.Close();
        }

        public void Update(Items Item, int categId)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            MySqlDataReader CategoryId = Connection.MySqlQuery(
                $"SELECT * FROM `pr37-40`.items WHERE Id = {Item.Id}", mySqlConnection);
            int newCategoryId = 0;
            if (CategoryId.HasRows)
            {
                CategoryId.Read();
                newCategoryId = CategoryId.GetInt32(5);
            }
            mySqlConnection.Close();
            mySqlConnection.Open();
            Connection.MySqlQuery($"UPDATE `pr37-40`.items SET Name = '{Item.Name}', Description = '{Item.Description}', Img = '{Item.Img}', Price = '{Item.Price}', IdCategory = '{categId}' WHERE Id = {Item.Id}", mySqlConnection);
            mySqlConnection.Close();
        }
    }
}