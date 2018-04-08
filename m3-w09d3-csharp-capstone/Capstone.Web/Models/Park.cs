using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DALs;
using System.Web.Mvc;
using System.Configuration;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public double EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public string TempType { get; set; }

        public List<Weather> GetWeather()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["NationalParkDB"].ConnectionString;

            WeatherSqlDAL dal = new WeatherSqlDAL(connectionString);

            List<Weather> newWeather = dal.GetWeather(ParkCode);

            return newWeather;
        }

        
    }
}