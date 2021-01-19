using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityPage.Models
{
    public class ResponseHolder<T>
    {
        public List<T> results { get; set; }

    }
}
