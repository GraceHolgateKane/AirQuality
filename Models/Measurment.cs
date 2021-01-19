using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityPage.Models
{

    public class Measurement
    {
        [DisplayName("Chemical:")]
        public string parameter { get; set; }
        [DisplayName("Value:")]
        public double value { get; set; }
        public DateTime lastUpdated { get; set; }
        public string unit { get; set; }
        public string sourceName { get; set; }
    }

    public class MeasurmentResult
    {
        [DisplayName("District")]
        public string location { get; set; }
        [DisplayName("City")]
        public string city { get; set; }
        [DisplayName("Country Code")]
        public string country { get; set; }
        public double? distance { get; set; }
        public List<Measurement> measurements { get; set; }
    }
}
