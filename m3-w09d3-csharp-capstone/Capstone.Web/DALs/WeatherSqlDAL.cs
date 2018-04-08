using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Capstone.Web.DALs
{
    public class WeatherSqlDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NationalParkDB"].ConnectionString;
        private const string SQL_GetWeather = @"SELECT * FROM weather WHERE parkCode = @parkCode;";

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeather(string parkCode)
        {
            List<Weather> result = new List<Weather>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetWeather, conn);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather day = new Weather();

                        day.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        day.Low = Convert.ToInt32(reader["low"]);
                        day.High = Convert.ToInt32(reader["high"]);
                        day.Forecast = Convert.ToString(reader["forecast"]);

                        result.Add(day);
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