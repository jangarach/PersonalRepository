using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HomeRenovationCalculator.View;
using System.Windows;

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
                SettingDatas settingDatas = new SettingDatas();
                settingDatas.ShowDialog();
            }));
        }

        public ViewModelBase BaseViewModel
        {

        }
    }
}