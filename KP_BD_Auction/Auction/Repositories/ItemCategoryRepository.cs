using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Auction.Models;
using System.Data;

namespace Auction.Repositories
{
    public class ItemCategoryRepository
    {
        public bool Add(ItemCategoryModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("AddItemCategory", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Category", obj.Category);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public List<ItemCategoryModel> GetAll()
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("GetItemCategories", db);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt);
            }
        }

        private List<ItemCategoryModel> FillTable(DataTable dt)
        {
            List<ItemCategoryModel> ModelObjects = new List<ItemCategoryModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ModelObjects.Add(new ItemCategoryModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Category = Convert.ToString(dr["Category"])
                });
            }
            return ModelObjects;
        }

        public ItemCategoryModel GetById(int id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                ItemCategoryModel ModelObject = new ItemCategoryModel();

                SqlCommand com = new SqlCommand("GetItemCategoryById", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt)[0];
            }
        }

        public bool Update(ItemCategoryModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("UpdateItemCategory", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@Category", obj.Category);

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

                SqlCommand com = new SqlCommand("DeleteItemCategory", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }
    }
}