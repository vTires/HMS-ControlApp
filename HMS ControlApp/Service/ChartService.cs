using HMS_ControlApp.Models;
using HMS_ControlApp.ViewModels;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HMS_ControlApp.Service
{

    public class ChartService : INotifyPropertyChanged
    {
        public ObservableCollection<DateTimePoint> _observableTemperatureValues;
        public ObservableCollection<DateTimePoint> _observableRotationValues;

        public ChartService()
        {
            UpdateService.PropertyChanged += UpdateService_PropertyChanged;

            _observableTemperatureValues = new ObservableCollection<DateTimePoint>
            {
            //new ObservablePoint(CurrentTime, 0),
            //new ObservablePoint(CurrentTime+10, 10),
            new DateTimePoint(DateTime.Now, 0),
        };
            _observableRotationValues = new ObservableCollection<DateTimePoint>
            {
            //new ObservablePoint(CurrentTime, 0),
            //new ObservablePoint(CurrentTime+20, 20),
            new DateTimePoint(DateTime.Now, 0)
        };

            ChartData = new ObservableCollection<ISeries>
        {
            new LineSeries<DateTimePoint>
            {
                TooltipLabelFormatter = (chartPoint) =>
                $"{new DateTime((long) chartPoint.SecondaryValue):hh:mm:ss}: {chartPoint.PrimaryValue}",


                Values = _observableTemperatureValues,
                Fill = null,
                GeometrySize = 1,
                LineSmoothness = 1
            },
            new LineSeries<DateTimePoint>
            {
                TooltipLabelFormatter = (chartPoint) =>
                $"{new DateTime((long) chartPoint.SecondaryValue):hh:mm:ss}: {chartPoint.PrimaryValue}", //was $"{new DateTime((short) chartPoint.SecondaryValue):MMMM dd}: {chartPoint.PrimaryValue}",

                Values = _observableRotationValues,
                Fill = null,
                GeometrySize = 1,
                LineSmoothness = 1
            }
        };

        }
        public Axis[] XAxes { get; set; } =
    {
        new Axis
        {
            Labeler = value => new DateTime((long) value).ToString("hh:mm:ss"),
            LabelsRotation = 0,
            

            // when using a date time type, let the library know your unit 
            UnitWidth = TimeSpan.FromSeconds(1).Ticks, 

            // if the difference between our points is in hours then we would:
            // UnitWidth = TimeSpan.FromHours(1).Ticks,

            // since all the months and years have a different number of days
            // we can use the average, it would not cause any visible error in the user interface
            // Months: TimeSpan.FromDays(30.4375).Ticks
            // Years: TimeSpan.FromDays(365.25).Ticks

            // The MinStep property forces the separator to be greater than 1 day.
            MinStep = TimeSpan.FromSeconds(1).Ticks
        }
    };

        public ObservableCollection<ISeries> ChartData { get; set; }


        private double _currentTime;
        private double _CurrentTemperature;
        private double _CurrentRotation;
        public double CurrentTemperature
        {
            get { return UpdateService.CurrentTemperature; }
            set
            {
                if (_CurrentTemperature != null)
                {
                    _CurrentTemperature = value;
                    OnPropertyChanged("CurrentTemperature");
                    //ObservablePoint bridgeValue = new ObservablePoint(CurrentTime, value);
                    _observableTemperatureValues.Add(new DateTimePoint(DateTime.Now, value));
                }
            }
        }
        public double CurrentRotation
        {
            get { return UpdateService.CurrentRotation; }
            set
            {
                if (_CurrentRotation != null)
                {
                    _CurrentRotation = value;
                    OnPropertyChanged("CurrentRotation");
                    //ObservablePoint bridgeValue = new ObservablePoint(CurrentTime, value);
                    //_observableRotationValues.Add(new ObservablePoint(CurrentTime, value));
                    _observableRotationValues.Add(new DateTimePoint(DateTime.Now, value));
                }
            }
        }
        public double CurrentTime
        {
            get { return _currentTime; }
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    OnPropertyChanged("CurrentTime");
                }
            }
        }
        public void SetCurrentTime(DateTime currentTime)
        {
            double doubleTime = currentTime.ToOADate();
            _currentTime = doubleTime;
        }

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateService_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(UpdateService.CurrentTemperature))
                CurrentTemperature = UpdateService.CurrentTemperature;
            else if (e.PropertyName == nameof(UpdateService.CurrentRotation))
                CurrentRotation = UpdateService.CurrentRotation;
        }


        #endregion

    }

}

 


