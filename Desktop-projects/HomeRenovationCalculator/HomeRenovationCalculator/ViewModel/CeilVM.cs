using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.ViewModel
{
    public class CeilVM : ViewModelBase
    {
        public CeilVM()
        {

        }

        public ObservableCollection<CoverParameterVM> CoverParams { get; } = new ObservableCollection<CoverParameterVM>();

        string _UnitText;
        public string UnitText
        {
            get => _UnitText;
            set => Set(ref _UnitText, value);
        }

        double _MinCountCover;
        public double MinCountCover
        {
            get => _MinCountCover;
            set => Set(ref _MinCountCover, value);
        }

        RelayCommand _CommandCalcCoverCount;
        public RelayCommand CommandCalcCoverCount
        {
            get => _CommandCalcCoverCount ?? (_CommandCalcCoverCount = new RelayCommand(() =>
            {
                CalculateCoverCount();
            }));
        }

        private void CalculateCoverCount()
        {
            MainViewModel mainVm = ServiceLocator.Current.GetInstance<MainViewModel>();
            if (mainVm == null)
            {
                return;
            }
            var area = mainVm.RoomParameters.FloorArea;
            
        }
    }
}
