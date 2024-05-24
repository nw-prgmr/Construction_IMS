using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConstructionMaterialManagementSystem.Models
{

    public struct MaterialStock
    {
        public string MaterialName { get; set; }
        public int Stock { get; set; }
    }


    public class Dashboard : MainClass
    {
        //Fields & Properties
        private DateTime startDate;
        private DateTime endDate;
        public int NumSuppliers { get; private set; }
        public int NumMaterials { get; private set; }
        public List<KeyValuePair<string, int>> TopMaterialsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }

        //Constructor
        public Dashboard()
        {
            GetNumberItems();
            GetMaterialAnalysis();
        }

        //Private methods
        private void GetNumberItems()
        {
            using (MySqlConnection connection = con)
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    //Get Total Number of Suppliers
                    command.CommandText = "SELECT COUNT(sID) FROM tbl_supplier";
                    NumSuppliers = Convert.ToInt32(command.ExecuteNonQuery());

                    //Get Total Number of Materials
                    command.CommandText = "SELECT count(pId) FROM tbl_products";
                    NumMaterials = (int)command.ExecuteNonQuery();
                }
            }
        }
        private void GetMaterialAnalysis()
        {
            TopMaterialsList = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();
            using (var connection = con)
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    MySqlDataReader reader;
                    command.Connection = connection;
                    //Get Top 5 materials
                    command.CommandText = @"select pName, pStock
                                        from tbl_products
                                        order by pStock desc limit 5";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopMaterialsList.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();

                    //Get Understock
                    command.CommandText = @"select pName, pStock
                                        from tbl_products
                                        where pStock <= 6";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UnderstockList.Add(
                            new KeyValuePair<string, int>(reader[0].ToString(), (int)reader[1]));
                    }
                    reader.Close();
                }
            }
        }
    }
}

