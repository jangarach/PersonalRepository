using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringStore.ViewModel
{
    public class SectorVM : ViewModelBase
    {
        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

    }
}
