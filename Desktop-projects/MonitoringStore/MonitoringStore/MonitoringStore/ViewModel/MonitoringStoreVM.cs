using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MonitoringStore.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MonitoringStore.ViewModel
{
    public class MonitoringStoreVM : ViewModelBase
    {
        public MonitoringStoreVM()
        {
            CurrentControlVM = ServiceLocator.Current.GetInstance<ucMainPageVM>();
        }
        public ViewModelBase _CurrentControlVM;
        public ViewModelBase CurrentControlVM
        {
            get => _CurrentControlVM;
            set => Set(ref _CurrentControlVM, value);
        }

        private RelayCommand _CommandOpenEditingControl;
        public RelayCommand CommanOpenEditingControl
        {
            get
            {
                return _CommandOpenEditingControl ?? new RelayCommand(() =>
                {
                    CurrentControlVM = ServiceLocator.Current.GetInstance<ucEditingTablesVM>();
                });
            }
        }
    }
}
