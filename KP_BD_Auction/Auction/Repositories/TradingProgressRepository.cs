using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Auction.Models;
using System.Data;
using System.Globalization;

namespace Auction.Repositories
{
    public class TradingProgressRepository
    {
        public bool Add(TradingProgressModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("AddTradingProgress", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Deal_Id", obj.Deal_Id);
                com.Parameters.AddWithValue("@Byer_Id", obj.Buyer_Id);
                com.Parameters.AddWithValue("@StepTime", obj.StepTime);
                com.Parameters.AddWithValue("@StepRate", obj.StepRate);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public List<TradingProgressModel> GetAll(string table = "GetTradingProgresses", bool useJoin = false)
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

        private List<TradingProgressModel> FillTable(DataTable dt, bool useJoin = false)
        {
            List<TradingProgressModel> ModelObjects = new List<TradingProgressModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ModelObjects.Add(new TradingProgressModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Deal_Id = Convert.ToInt32(dr["Deal_Id"]),
                    Buyer_Id = Convert.ToInt32(dr["Byer_Id"]),
                    StepTime = DateTime.ParseExact(Convert.ToString((dr["StepTime"])), "HH:mm:ss", CultureInfo.InvariantCulture),
                    StepRate = Convert.ToInt32(dr["StepRate"]),
                    Deal = useJoin ? DateTime.ParseExact(Convert.ToString((dr["Time"])), "HH:mm:ss", CultureInfo.InvariantCulture) : DateTime.Now,
                    Buyer = useJoin ? Convert.ToString(dr["BuyerName"]) : ""
                });
            }
            return ModelObjects;
        }

        public TradingProgressModel GetById(int id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                TradingProgressModel ModelObject = new TradingProgressModel();

                SqlCommand com = new SqlCommand("GetTradingProgressById", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt)[0];
            }
        }

        public bool Update(TradingProgressModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("UpdateTradingProgress", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@Deal_Id", obj.Deal_Id);
                com.Parameters.AddWithValue("@Byer_Id", obj.Buyer_Id);
                com.Parameters.AddWithValue("@StepTime", obj.StepTime);
                com.Parameters.AddWithValue("@StepRate", obj.StepRate);

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

                SqlCommand com = new SqlCommand("DeleteTradingProgress", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }
    }
}