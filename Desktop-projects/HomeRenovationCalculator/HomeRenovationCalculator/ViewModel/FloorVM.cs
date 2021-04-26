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
            CoverTypes.Add(new Cover(CoverType.Linoleum, "Линолеум"));
            CoverTypes.Add(new Cover(CoverType.Laminat, "Ламинат"));
            CoverTypes.Add(new Cover(CoverType.Parket, "Паркет"));
            CoverTypes.Add(new Cover(CoverType.Plitka, "Плитка"));
            SelectedCoverType = CoverTypes.FirstOrDefault();
        }

        private void FloorVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (nameof(SelectedCoverType) == e.PropertyName && SelectedCoverType != null)
            {
                CoverParams.Clear();
                switch (SelectedCoverType.CoverType)
                {
                    case CoverType.Linoleum:
                        UnitText = " (м.)";
                        CoverParams.Add(new CoverParameterVM("Ширина покрытия [м.]"));
                        break;

                    case CoverType.Laminat:
                    case CoverType.Parket:
                    case CoverType.Plitka:
                        UnitText = " (шт.)";
                        CoverParams.Add(new CoverParameterVM("Длина покрытия [м.]"));
                        CoverParams.Add(new CoverParameterVM("Ширина покрытия [м.]"));
                        break;

                }
            }
        }

        public ObservableCollection<Cover> CoverTypes { get; } = new ObservableCollection<Cover>();
        public ObservableCollection<CoverParameterVM> CoverParams { get; } = new ObservableCollection<CoverParameterVM>();

        Cover _SelectedCoverType;
        public Cover SelectedCoverType
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
                case CoverType.Linoleum:
                    MinCountCover = Math.Round((area / CoverParams.FirstOrDefault().ParamValue), 0);
                    break;

                case CoverType.Laminat:
                case CoverType.Parket:
                case CoverType.Plitka:
                    var coverArea = CoverParams[0].ParamValue * CoverParams[1].ParamValue;
                    MinCountCover = Math.Round((area * 1.05) / coverArea);
                    break;
            }
        }
    }

    public enum CoverType
    {
        Linoleum = 0,
        Laminat = 1,
        Parket = 2,
        Plitka = 3
    }

    public class Cover
    {
        public Cover(CoverType coverType, string coverTypeName)
        {
            CoverType = coverType;
            CoverTypeName = coverTypeName;
        }
        public string CoverTypeName { get; }
        public CoverType CoverType { get; }

    }
}
