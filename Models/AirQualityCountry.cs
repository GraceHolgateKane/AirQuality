using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityPage.Models
{
    public class AirQualityCountry
    {
        [DisplayName("Country Code")]
        public string code { get; set; }
        public int count { get; set; }
        public int locations { get; set; }
        [DisplayName("Number Of Cities in Country")]
        public int cities { get; set; }
        [DisplayName("Country")]
        public string name { get; set; }
    }
}