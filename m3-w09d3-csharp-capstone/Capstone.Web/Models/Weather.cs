using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }

        public string RecAttire()
        {
            string attire = "";
            switch (Forecast)
            {
                case "rain":
                    attire = "Wear waterproof shoes.";
                    break;
                case "thunderstorms":
                    attire = "Seek shelter and avoid hiking on exposed ridges.";
                    break;
                case "sunny":
                    attire = "Pack sunblock.";
                    break;
                case "snow":
                    attire = "Pack snowshoes.";
                    break;
            }
            if (High - Low > 20)
            {
                if (High > 75)
                {
                    if (attire != "")
                    {
                        attire += ", wear breathable layers, and bring an extra gallon of water.";
                    }
                    else
                    {
                        attire = "Wear breathable layers and bring an extra gallon of water!";
                    }
                }
                else if (Low < 20)
                {
                    if (attire != "")
                    {
                        attire += ", beware the dangers of exposure to frigid temperatures, and wear breathable layers!";
                    }
                    else
                    {
                        attire = "Beware the dangers of exposure to frigid temperatures, and wear breathable layers!";
                    }
                }
            }
            else
            {
                if (High > 75)
                {
                    if (attire != "")
                    {
                        attire += "and bring an extra gallon of water.";
                    }
                    else
                    {
                        attire = "Bring an extra gallon of water!";
                    }
                }
                else if (Low < 20)
                {
                    if (attire != "")
                    {
                        attire += "and beware the dangers of exposure to frigid temperatures!";
                    }
                    else
                    {
                        attire = "Beware the dangers of exposure to frigid temperatures!";
                    }
                }
            }
            return attire;
        }
        public string weatherImage()
        {
            string image = "";
            switch (Forecast)
            {
                case "rain":
                    image = "rain.png";
                    break;
                case "thunderstorms":
                    image = "thunderstorms.png";
                    break;
                case "sunny":
                    image = "sunny.png";
                    break;
                case "snow":
                    image = "snow.png";
                    break;
                case "partly cloudy":
                    image = "partlyCloudy.png";
                    break;
                case "cloudy":
                    image = "cloudy.png";
                    break;
            }
            return image;
        }
        public static List<SelectListItem> TempSet
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem { Text = "Fahrenheit (°F)", Value = "°F" },
                    new SelectListItem { Text = "Celsius (°C)", Value = "°C" }
                };
            }
        }
    }
}