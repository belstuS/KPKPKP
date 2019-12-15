using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Auction.Models;
using System.Data;

namespace Auction.Repositories
{
    public class DealStateRepository
    {
        public bool Add(DealStateModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("AddDealState", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@State", obj.State);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public List<DealStateModel> GetAll()
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("GetDealStates", db);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt);
            }
        }

        private List<DealStateModel> FillTable(DataTable dt)
        {
            List<DealStateModel> ModelObjects = new List<DealStateModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ModelObjects.Add(new DealStateModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    State = Convert.ToString(dr["State"])
                });
            }
            return ModelObjects;
        }

        public DealStateModel GetById(int id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                DealStateModel ModelObject = new DealStateModel();

                SqlCommand com = new SqlCommand("GetDealStateById", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt)[0];
            }
        }

        public bool Update(DealStateModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("UpdateDealState", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@State", obj.State);

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

                SqlCommand com = new SqlCommand("DeleteDealState", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }
    }
}