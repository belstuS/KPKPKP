using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Auction.Models;
using System.Data;
using System.Globalization;

namespace Auction.Repositories
{
    public class AuctionRepository
    {   
        public bool Add(AuctionModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("AddAuction", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Date", obj.Date);
                com.Parameters.AddWithValue("@StartTime", obj.StartTime);
                com.Parameters.AddWithValue("@EndTime", obj.EndTime);
                com.Parameters.AddWithValue("@Income", obj.Income);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }
       
        public List<AuctionModel> GetAll(string table = "GetAuctions")
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand(table, db);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable(); 
                da.Fill(dt);
               
                return FillTable(dt);
            }
        }

        private List<AuctionModel> FillTable(DataTable dt)
        {
            List<AuctionModel> ModelObjects = new List<AuctionModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ModelObjects.Add(new AuctionModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Date = Convert.ToDateTime(dr["Date"]),
                    StartTime = DateTime.ParseExact(Convert.ToString((dr["StartTime"])), "HH:mm:ss", CultureInfo.InvariantCulture),
                    EndTime = DateTime.ParseExact(Convert.ToString((dr["EndTime"])), "HH:mm:ss", CultureInfo.InvariantCulture),
                    Income = Convert.ToInt32(dr["Income"])
                });
            }
            return ModelObjects;
        }

        public AuctionModel GetById(int id)
        {
            using(SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                AuctionModel ModelObject = new AuctionModel();

                SqlCommand com = new SqlCommand("GetAuctionById", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt)[0];
            }
        }
        
        public bool Update(AuctionModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("UpdateAuction", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@Date", obj.Date);
                com.Parameters.AddWithValue("@StartTime", obj.StartTime);
                com.Parameters.AddWithValue("@EndTime", obj.EndTime);
                com.Parameters.AddWithValue("@Income", obj.Income);

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

                SqlCommand com = new SqlCommand("DeleteAuction", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public bool End(int Id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("EndAuction", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }
    }
}