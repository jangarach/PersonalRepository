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
    public class FloorVM : ViewModelBase
    {
        public FloorVM()
        {
            PropertyChanged += FloorVM_PropertyChanged;
            CoverTypes.Add(new FloorCover(FloorCoverType.Linoleum, "Линолеум"));
            CoverTypes.Add(new FloorCover(FloorCoverType.Laminat, "Ламинат"));
            CoverTypes.Add(new FloorCover(FloorCoverType.Parket, "Паркет"));
            CoverTypes.Add(new FloorCover(FloorCoverType.Plitka, "Плитка"));
            SelectedCoverType = CoverTypes.FirstOrDefault();
        }

        private void FloorVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (nameof(SelectedCoverType) == e.PropertyName && SelectedCoverType != null)
            {
                CoverParams.Clear();
                switch (SelectedCoverType.CoverType)
                {
                    case FloorCoverType.Linoleum:
                        UnitText = " (м.)";
                        CoverParams.Add(new CoverParameterVM("Ширина покрытия [м.]"));
                        break;

                    case FloorCoverType.Laminat:
                    case FloorCoverType.Parket:
                    case FloorCoverType.Plitka:
                        UnitText = " (шт.)";
                        CoverParams.Add(new CoverParameterVM("Длина покрытия [м.]"));
                        CoverParams.Add(new CoverParameterVM("Ширина покрытия [м.]"));
                        break;

                }
            }
        }

        public ObservableCollection<FloorCover> CoverTypes { get; } = new ObservableCollection<FloorCover>();
        public ObservableCollection<CoverParameterVM> CoverParams { get; } = new ObservableCollection<CoverParameterVM>();

        FloorCover _SelectedCoverType;
        public FloorCover SelectedCoverType
        {
            get => _SelectedCoverType;
            set => Set(ref _SelectedCoverType, value);
        }

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
            switch (SelectedCoverType.CoverType)
            {
                case FloorCoverType.Linoleum:
                    MinCountCover = Math.Round((area / CoverParams.FirstOrDefault().ParamValue), 0);
                    break;

                case FloorCoverType.Laminat:
                case FloorCoverType.Parket:
                case FloorCoverType.Plitka:
                    var coverArea = CoverParams[0].ParamValue * CoverParams[1].ParamValue;
                    MinCountCover = Math.Round((area * 1.05) / coverArea);
                    break;
            }
        }
    }

    public enum FloorCoverType
    {
        Linoleum = 0,
        Laminat = 1,
        Parket = 2,
        Plitka = 3
    }

    public class FloorCover
    {
        public FloorCover(FloorCoverType coverType, string coverTypeName)
        {
            CoverType = coverType;
            CoverTypeName = coverTypeName;
        }
        public string CoverTypeName { get; }
        public FloorCoverType CoverType { get; }

    }
}
