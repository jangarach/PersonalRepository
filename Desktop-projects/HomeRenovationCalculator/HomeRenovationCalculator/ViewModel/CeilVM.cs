using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HomeRenovationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeRenovationCalculator.ViewModel
{
    public class CeilVM : ViewModelBase
    {
        public SettingDatasVM SettingDatasVM { get; }
        public CeilVM()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            SettingDatasVM = ServiceLocator.Current.GetInstance<SettingDatasVM>();
            CoverParams.Add(new CoverParameterVM("Толщина слоя штукатурки:, мм"));
            CoverParams.Add(new CoverParameterVM("Толщина слоя шпаклевки:, мм"));
            SelectedPlaster = SettingDatasVM.Plaster.FirstOrDefault();
            SelectedPutty = SettingDatasVM.Putty.FirstOrDefault();
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        public ObservableCollection<CoverParameterVM> CoverParams { get; } = new ObservableCollection<CoverParameterVM>();

        string _UnitText;
        public string UnitText
        {
            get => _UnitText;
            set => Set(ref _UnitText, value);
        }

        double _MinCountPlaster;
        public double MinCountPlaster
        {
            get => _MinCountPlaster;
            set => Set(ref _MinCountPlaster, value);
        }

        double _MinCountPutty;
        public double MinCountPutty
        {
            get => _MinCountPutty;
            set => Set(ref _MinCountPutty, value);
        }

        double _PricePlaster;
        public double PricePlaster
        {
            get => _PricePlaster;
            set => Set(ref _PricePlaster, value);
        }

        double _PricePutty;
        public double PricePutty
        {
            get => _PricePutty;
            set => Set(ref _PricePutty, value);
        }


        BaseCover _SelectedPlaster;
        public BaseCover SelectedPlaster
        {
            get => _SelectedPlaster;
            set => Set(ref _SelectedPlaster, value);
        }

        BaseCover _SelectedPutty;
        public BaseCover SelectedPutty
        {
            get => _SelectedPutty;
            set => Set(ref _SelectedPutty, value);
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
            if (mainVm != null && SelectedPlaster != null && SelectedPutty != null)
            {
                MinCountPlaster = Math.Round(mainVm.RoomParameters.CeilingArea * CoverParams[0].ParamValue * 0.9, 0);
                MinCountPutty = Math.Round(mainVm.RoomParameters.CeilingArea * CoverParams[1].ParamValue * 0.9, 0);
                PricePlaster = MinCountPlaster / SelectedPlaster.Capacity * SelectedPlaster.Price;
                PricePutty = MinCountPutty / SelectedPutty.Capacity * SelectedPutty.Price;
            }
        }
    }
}
