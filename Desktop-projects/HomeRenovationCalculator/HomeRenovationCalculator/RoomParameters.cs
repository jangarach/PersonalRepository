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

        double _FloorLength;
        /// <summary>
        /// Длина пола
        /// </summary>
        public double FloorLength
        {
            get => _FloorLength;
            set => Set(ref _FloorLength, value);
        }

        double _FloorWidth;
        /// <summary>
        /// Ширина пола
        /// </summary>
        public double FloorWidth
        {
            get => _FloorWidth;
            set => Set(ref _FloorWidth, value);
        }

        double _CeilingLength;
        /// <summary>
        /// Длина потолка
        /// </summary>
        public double CeilingLength
        {
            get => _CeilingLength;
            set => Set(ref _CeilingLength, value);
        }

        double _CeilingWidth;
        /// <summary>
        /// Ширина потолка
        /// </summary>
        public double CeilingWidth
        {
            get => _CeilingWidth;
            set => Set(ref _CeilingWidth, value);
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

    }
}
