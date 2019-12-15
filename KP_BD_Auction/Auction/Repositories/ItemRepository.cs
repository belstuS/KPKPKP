using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Auction.Models;
using System.Data;

namespace Auction.Repositories
{
    public class ItemRepository
    {
        public bool Add(ItemModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("AddItem", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@Description", obj.Description);
                com.Parameters.AddWithValue("@Category_Id", obj.Category_Id);
                com.Parameters.AddWithValue("@StartedPrice", obj.StartedPrice);
                com.Parameters.AddWithValue("@PriceGrowth", obj.PriceGrowth);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public List<ItemModel> GetAll(string table = "GetItems", bool useJoin = false)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand(table, db);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt, useJoin);
            }
        }

        private List<ItemModel> FillTable(DataTable dt, bool useJoin = false)
        {
            List<ItemModel> ModelObjects = new List<ItemModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ModelObjects.Add(new ItemModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Description = Convert.ToString(dr["Description"]),
                    Category_Id = Convert.ToInt32(dr["Category_Id"]),
                    StartedPrice = Convert.ToInt32(dr["StartedPrice"]),
                    PriceGrowth = Convert.ToInt32(dr["PriceGrowth"]),
                    Category = useJoin ? Convert.ToString(dr["Category"]) : ""
                });
            }
            return ModelObjects;
        }

        public bool SetSold(int Id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("SetSold", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public ItemModel GetById(int id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("GetItemById", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt)[0];
            }
        }

        public bool Update(ItemModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("UpdateItem", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@Description", obj.Description);
                com.Parameters.AddWithValue("@Category_Id", obj.Category_Id);
                com.Parameters.AddWithValue("@StartedPrice", obj.StartedPrice);
                com.Parameters.AddWithValue("@PriceGrowth", obj.PriceGrowth);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public bool Delete(int Id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("DeleteItem", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }
    }
}