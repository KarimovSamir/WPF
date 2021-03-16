using System;
using System.Collections.Generic;
using System.Text;
using Weather_App.Model;

namespace Weather_App.Messages
{
    class ForecastInfoMessage
    {
        public Forecast Forecast { get; set; }
    }
}
