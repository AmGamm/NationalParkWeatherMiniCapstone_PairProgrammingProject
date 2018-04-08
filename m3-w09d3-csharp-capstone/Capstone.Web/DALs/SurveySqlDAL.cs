using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Capstone.Web.DALs
{
    public class SurveySqlDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NationalParkDB"].ConnectionString;
        private const string SQL_GetAllSurveys = @"  SELECT park.parkName, COUNT(park.parkName) as parkRank, park.parkCode, COUNT(park.parkCode) FROM park JOIN survey_result ON park.parkCode = survey_result.parkCode GROUP BY park.parkName, park.parkCode  ORDER BY parkRank DESC;";
        private const string SQL_SaveSurvey = @"INSERT INTO survey_result VALUES(@parkCode, @emailAddress, @state, @activityLevel)";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public bool SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        public List<Survey> GetAllSurveys()
        {
            List<Survey> result = new List<Survey>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllSurveys, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey sur = new Survey();
                        sur.ParkCode = Convert.ToString(reader["parkCode"]);
                        sur.ParkName = Convert.ToString(reader["parkName"]);
                        sur.ParkRank = Convert.ToInt32(reader["parkRank"]);

                        result.Add(sur);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }

            return result;
        }
    }
}