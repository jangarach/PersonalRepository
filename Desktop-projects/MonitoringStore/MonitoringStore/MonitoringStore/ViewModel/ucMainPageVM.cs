using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringStore.ViewModel
{
    
    public class ucMainPageVM : ViewModelBase
    {
        public ObservableCollection<SectorVM> CollectionSectors { get; set; }
        public ucMainPageVM()
        {
            CollectionSectors = new ObservableCollection<SectorVM>();
            for (int i = 0; i < 30; i++)
            {
                CollectionSectors.Add(new SectorVM() { Name = $"Test {i}" });
            }
        }
    }
}
