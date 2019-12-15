using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Auction.Models;
using System.Data;
using System.Linq;

namespace Auction.Repositories
{
    public class UserRepository
    {
        public List<UserModel> GetAll()
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("GetUsers", db);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                return FillTable(dt);
            }
        }

        public UserModel GetUserByLogin(string login)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("GetUserByLogin", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Login", login);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return FillTable(dt).FirstOrDefault();
            }
        }

        private List<UserModel> FillTable(DataTable dt)
        {
            List<UserModel> ModelObjects = new List<UserModel>();
            foreach (DataRow dr in dt.Rows)
            {
                ModelObjects.Add(new UserModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Username = Convert.ToString(dr["Login"]),
                    Password = Convert.ToString(dr["Password"]),
                    Role = Convert.ToString(dr["Role"])
                });
            }
            return ModelObjects;
        }

        public bool IsPasswordValid(UserModel ModelObjects)
        {
            using (SqlConnection db = SQLConnector.Connect())
            {
                db.Open();

                SqlCommand com = new SqlCommand("IsPasswordValid", db);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Password", ModelObjects.Password );
                com.Parameters.AddWithValue("@UserName", ModelObjects.Username);

                var isPasswordValid = Convert.ToBoolean(com.ExecuteScalar());

                return isPasswordValid;
            }
        }

    }
}