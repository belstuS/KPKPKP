using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Auction.Models;
using System.Data;

namespace Auction.Repositories
{
    public class ParticipantRepository
    {
        public bool Add(ParticipantModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("AddParticipant", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", obj.FirstName);
                com.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
                com.Parameters.AddWithValue("@LastName", obj.LastName);
                com.Parameters.AddWithValue("@Age", obj.Age);
                com.Parameters.AddWithValue("@Email", obj.Email);
                com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }

        public List<ParticipantModel> GetAll()
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("GetParticipants", db);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt);
            }
        }

        private List<ParticipantModel> FillTable(DataTable dt)
        {
            List<ParticipantModel> ModelObjects = new List<ParticipantModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ModelObjects.Add(new ParticipantModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    MiddleName = Convert.ToString(dr["MiddleName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    Age = Convert.ToInt32(dr["Age"]),
                    Email = Convert.ToString(dr["EMail"]),
                    PhoneNumber = Convert.ToString(dr["PhoneNumber"])
                });
            }
            return ModelObjects;
        }

        public ParticipantModel GetById(int id)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                ParticipantModel ModelObject = new ParticipantModel();

                SqlCommand com = new SqlCommand("GetParticipantById", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", id);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt)[0];
            }
        }

        public bool Update(ParticipantModel obj)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("UpdateParticipant", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@FirstName", obj.FirstName);
                com.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
                com.Parameters.AddWithValue("@LastName", obj.LastName);
                com.Parameters.AddWithValue("@Age", obj.Age);
                com.Parameters.AddWithValue("@Email", obj.Email);
                com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);

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

                SqlCommand com = new SqlCommand("DeleteParticipant", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);

                if (com.ExecuteNonQuery() == -1)
                    return false;
                return true;
            }
        }
    }
}