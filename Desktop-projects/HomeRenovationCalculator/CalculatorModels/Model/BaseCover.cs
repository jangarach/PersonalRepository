using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.Model
{
    public class BaseCover : ObservableObject
    {
        public int Id { get; set; }

        string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value); 
        }

        double _Capacity;
        public double Capacity
        {
            get => _Capacity;
            set => Set(ref _Capacity, value);
        }

        double _Price;
        public double Price
        {
            get => _Price;
            set => Set(ref _Price, value);
        }
    }
}
