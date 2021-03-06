/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:HomeRenovationCalculator"
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

namespace HomeRenovationCalculator.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SettingDatasVM>();
            SimpleIoc.Default.Register<FloorVM>();
            SimpleIoc.Default.Register<CeilVM>();
            SimpleIoc.Default.Register<WallVM>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public SettingDatasVM SettingDatasVM => ServiceLocator.Current.GetInstance<SettingDatasVM>();
        public FloorVM FloorVM => ServiceLocator.Current.GetInstance<FloorVM>();
        public CeilVM CeilVM => ServiceLocator.Current.GetInstance<CeilVM>();
        public WallVM WallVM => ServiceLocator.Current.GetInstance<WallVM>();

        public static void Cleanup()
        {

        }
    }
}