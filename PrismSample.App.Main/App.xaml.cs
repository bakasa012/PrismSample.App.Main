using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using Prism.Mvvm;
using PrismSample.Lib.Views;
using PrismSample.Lib.ViewModels;
using PrismSample.Lib.Models;

namespace PrismSample.App.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            
            return Container.Resolve<ConvertExcelFileWindow>();

        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<ConvertExcelFileWindow, ConvertExcelFileWindowViewModel>();

        }

    }
}
