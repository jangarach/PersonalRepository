using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator
{
    public class RoomParameters : ObservableObject
    {
        public RoomParameters()
        {

        }

        double _WallHeight;
        /// <summary>
        /// Высота стены
        /// </summary>
        public double WallHeight
        {
            get => _WallHeight;
            set => Set(ref _WallHeight, value);
        }

        double _WallLength;
        /// <summary>
        /// Длина стены
        /// </summary>
        public double WallLength
        {
            get => _WallLength;
            set => Set(ref _WallLength, value);
        }

        double _CeilingArea;
        /// <summary>
        /// Площадь потолка
        /// </summary>
        public double CeilingArea
        {
            get => _CeilingArea;
            set => Set(ref _CeilingArea, value);
        }

        double _FloorArea;
        /// <summary>
        /// Площадь пола
        /// </summary>
        public double FloorArea
        {
            get => _FloorArea;
            set => Set(ref _FloorArea, value);
        }
    }
}
