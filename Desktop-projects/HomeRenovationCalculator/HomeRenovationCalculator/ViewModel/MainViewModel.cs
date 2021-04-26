using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HomeRenovationCalculator.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace HomeRenovationCalculator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RoomParameters RoomParameters { get; } = new RoomParameters();
        public MainViewModel()
        {

        }

        RelayCommand _CommandExit;
        public RelayCommand CommandExit
        {
            get => _CommandExit ?? (_CommandExit = new RelayCommand(() =>
            {

            }));
        }


        RelayCommand _CommandSettingDatas;
        public RelayCommand CommandSettingDatas
        {
            get => _CommandSettingDatas ?? (_CommandSettingDatas = new RelayCommand(() =>
            {
                Mouse.OverrideCursor = Cursors.Wait;
                SettingDatas settingDatas = new SettingDatas();
                settingDatas.DataContext = ServiceLocator.Current.GetInstance<SettingDatasVM>();
                Mouse.OverrideCursor = Cursors.Arrow;
                settingDatas.ShowDialog();
            }));
        }

        ViewModelBase _NavigationBaseVM = ServiceLocator.Current.GetInstance<FloorVM>();
        public ViewModelBase NavigationBaseVM
        {
            get => _NavigationBaseVM;
            set => Set(ref _NavigationBaseVM, value);
        }

        RelayCommand<string> _CommandChangeNavigationVM;
        public RelayCommand<string> CommandChangeNavigationVM
        {
            get => _CommandChangeNavigationVM ?? (_CommandChangeNavigationVM = new RelayCommand<string>((v) =>
            {
                if (Enum.TryParse(v, out NavigationsVM navigations))
                {
                    switch (navigations)
                    {
                        case NavigationsVM.FloorVm:
                            NavigationBaseVM = ServiceLocator.Current.GetInstance<FloorVM>();
                            break;
                        case NavigationsVM.CeilingVm:
                            NavigationBaseVM = ServiceLocator.Current.GetInstance<CeilVM>();
                            break;
                        case NavigationsVM.WallVm:
                            NavigationBaseVM = ServiceLocator.Current.GetInstance<WallVM>();
                            break;
                    }
                }
            }));
        }

    }

    enum NavigationsVM
    {
        FloorVm = 0,
        WallVm = 1,
        CeilingVm = 2
    }
}