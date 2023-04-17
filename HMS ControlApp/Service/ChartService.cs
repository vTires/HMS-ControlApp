using HMS_ControlApp.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HMS_ControlApp.Service
{
    public class ChartService
    {
        

        public ChartService()
        {

        }

            public ISeries[] ChartData { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null,
                    GeometrySize = 1,
                    LineSmoothness = 0
                },
                new LineSeries<double>
                {
                    Values = new double[] { 10, 5, 2, 1, 1, 1, 7 },
                    Fill = null,
                    GeometrySize = 5,
                    LineSmoothness = 1
                }
            };
        }
    }

 


