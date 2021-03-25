/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MonitoringStore"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace MonitoringStore.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MonitoringStoreVM>();
            SimpleIoc.Default.Register<ucEditingTablesVM>();
            SimpleIoc.Default.Register<ucMainPageVM>();
        }
        public ucEditingTablesVM EditingVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ucEditingTablesVM>();
            }
        }

        public ucMainPageVM ucMainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ucMainPageVM>();
            }
        }

        public MonitoringStoreVM Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MonitoringStoreVM>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}