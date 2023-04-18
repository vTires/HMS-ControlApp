using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ControlApp.Models
{
    public class ChartServiceModel
    {
        
       
            public DateTime Time { get; set; }
            public double Value1 { get; set; }
            public double Value2 { get; set; }

            public ChartServiceModel(DateTime time, double value1, double value2)
            {
                Time = time;
                Value1 = value1;
                Value2 = value2;
            }
        
    }
}
