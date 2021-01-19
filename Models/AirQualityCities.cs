using System;
using System.ComponentModel;

namespace AirQualityPage.Models
{
    public class AirQualityCities
    {
        [DisplayName("Country Code")]
        public string country { get; set; }
        [DisplayName("City Name")]
        public string name { get; set; }
        public int count { get; set; }
        public int locations { get; set; }

        
    }
}
