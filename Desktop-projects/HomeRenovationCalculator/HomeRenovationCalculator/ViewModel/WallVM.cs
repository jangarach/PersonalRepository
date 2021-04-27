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
    public class WallVM : ViewModelBase
    {
        public SettingDatasVM SettingDatasVM { get; }
        public WallVM()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            SettingDatasVM = ServiceLocator.Current.GetInstance<SettingDatasVM>();
            CoverParams.Add(new CoverParameterVM("Толщина слоя штукатурки:, мм."));
            CoverParams.Add(new CoverParameterVM("Толщина слоя шпаклевки:, мм."));

            CoverParams.Add(new CoverParameterVM("Ширина окна:, м."));
            CoverParams.Add(new CoverParameterVM("Длина окна:, м."));
            CoverParams.Add(new CoverParameterVM("Количество окон:, м."));

            CoverParams.Add(new CoverParameterVM("Ширина двери:, м."));
            CoverParams.Add(new CoverParameterVM("Длина двери:, м."));
            CoverParams.Add(new CoverParameterVM("Количество дверей:, м."));
            SelectedPlaster = SettingDatasVM.Plaster.FirstOrDefault();
            SelectedPutty = SettingDatasVM.Putty.FirstOrDefault();
            SelectedWallPaper = SettingDatasVM.WallPaper.FirstOrDefault();
            SelectedGlue = SettingDatasVM.Glue.FirstOrDefault();
            SelectedWallPaint = SettingDatasVM.WallPaint.FirstOrDefault();
            SelectedWallPaperType = SettingDatasVM.WallPaperType.FirstOrDefault();
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

        double _MinCountWallPaper;
        public double MinCountWallPaper
        {
            get => _MinCountWallPaper;
            set => Set(ref _MinCountWallPaper, value);
        }

        double _MinCountGlue;
        public double MinCountGlue
        {
            get => _MinCountGlue;
            set => Set(ref _MinCountGlue, value);
        }

        double _MinCountPaint;
        public double MinCountPaint
        {
            get => _MinCountPaint;
            set => Set(ref _MinCountPaint, value);
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

        WallPaper _SelectedWallPaper;
        public WallPaper SelectedWallPaper
        {
            get => _SelectedWallPaper;
            set => Set(ref _SelectedWallPaper, value);
        }

        BaseCover _SelectedGlue;
        public BaseCover SelectedGlue
        {
            get => _SelectedGlue;
            set => Set(ref _SelectedGlue, value);
        }

        BaseCover _SelectedWallPaint;
        public BaseCover SelectedWallPaint
        {
            get => _SelectedWallPaint;
            set => Set(ref _SelectedWallPaint, value);
        }

        WallPaperType _S_SelectedWallPaperType;
        public WallPaperType SelectedWallPaperType
        {
            get => _S_SelectedWallPaperType;
            set => Set(ref _S_SelectedWallPaperType, value);
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
                var s = mainVm.RoomParameters.WallHeight * mainVm.RoomParameters.WallLength;
                MinCountPlaster = Math.Round(s * CoverParams[0].ParamValue * 0.9, 0);
                MinCountPutty = Math.Round(s * CoverParams[1].ParamValue * 0.9, 0);
                PricePlaster = MinCountPlaster / SelectedPlaster.Capacity * SelectedPlaster.Price;
                PricePutty = MinCountPutty / SelectedPutty.Capacity * SelectedPutty.Price;
                var pWindow = ((CoverParams[2].ParamValue + CoverParams[3].ParamValue) * 2) * CoverParams[4].ParamValue;
                var pDoor = ((CoverParams[5].ParamValue + CoverParams[6].ParamValue) * 2) * CoverParams[7].ParamValue;
                var perimetr = (2 * (mainVm.RoomParameters.WallHeight + mainVm.RoomParameters.WallLength));
                MinCountWallPaper = (perimetr - pWindow - pDoor) / SelectedWallPaper.Length;
                MinCountGlue = (s / SelectedGlue.Capacity) * SelectedWallPaperType.Rate;
                MinCountPaint = s / SelectedWallPaint.Capacity;
            }
        }
    }
}