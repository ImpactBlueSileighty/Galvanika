using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Lab1.Model.Electroplating;

namespace Lab1.ViewModel
{
    public class MW_VM : INotifyPropertyChanged
    {

        private double _dur;
        public double Duration
        {
            get => _dur;
            set
            {
                _dur = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        private double _cur;
        public double Current
        {
            get => _cur;
            set
            {
                _cur = value;
                OnPropertyChanged(nameof(Current));
            }
        }

        private int _density;
        public int Density
        {
            get => _density;
            set
            {
                _density = value;
                OnPropertyChanged(nameof(Density));
            }
        }

        private double _w;
        public double Weight
        {
            get => _w;
            set
            {
                _w = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private int _voltage;
        public int Voltage
        {
            get => _voltage;
            set
            {
                _voltage = value;
                OnPropertyChanged(nameof(Voltage));
            }
        }

        private int _thickness;
        public int Thickness
        {
            get => _thickness;
            set
            {
                _thickness = value;
                OnPropertyChanged(nameof(Thickness));
            }
        }

        private double _cOut;
        public double CurrentOutput
        {
            get => _cOut;
            set
            {
                _cOut = value;
                OnPropertyChanged(nameof(CurrentOutput));
            }
        }



        public string InputLength { get; set; }
        public string InputD1 { get; set; }
        public string InputD2 { get; set; }
        public string InputThickness { get; set; }
        public string InputDensity { get; set; }
        public string InputDuration { get; set; }
        public string InputMetal { get; set; }
        public string InputEquivalent { get; set; }

        private double _duration
        {
            get
            {
                return Convert.ToDouble(InputDuration) / 60;
            }
        }

        private double _area
        {
            get
            {
                return Math.Round((2 * Math.PI * (Math.Pow((double)(Convert.ToDouble(InputD2) / 2), 2) - Math.Pow((double)(Convert.ToDouble(InputD1) / 2), 2))
                    + 2 * Math.PI * (Convert.ToDouble(InputD1) / 2) * Convert.ToDouble(InputLength)
                    + 2 * Math.PI * (Convert.ToDouble(InputD2) / 2) * Convert.ToDouble(InputLength))
                    / 1000000, 8);
            }
        }

        private double _weight
        {
            get
            {
                return Math.Round(_area * Convert.ToDouble(InputThickness) * Convert.ToDouble(InputMetal) * Math.Pow(10, -6), 6);
            }
        }

        private double _current
        {
            get
            {
                return Math.Round(_area * Convert.ToDouble(InputDensity) * 100, 2);
            }
        }


        public MW_VM()
        {

        }

        public void Update()
        {

            Duration = _duration;
            Current = _current;
            Density = Convert.ToInt32(InputDensity);
            Weight = _weight;
            Voltage = 10;
            Thickness = Convert.ToInt32(InputThickness);
            CurrentOutput = Math.Round(_weight * 100 / (Convert.ToDouble(InputEquivalent) * Math.Pow(10, -3) * _current * _duration), 2);

        }

        // INotifyPropertyChanged interface implementation 
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
