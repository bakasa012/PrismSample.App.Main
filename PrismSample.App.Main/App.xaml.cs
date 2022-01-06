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
            containerRegistry.Register<IDialogHelper, DialogHelper>();
            containerRegistry.Register<IModel, Model>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            ViewModelLocationProvider.Register<OperandView, OpearndViewModel>();
            ViewModelLocationProvider.Register<Answer, AnswerViewModel>();

            ViewModelLocationProvider.Register<CloseAppView, CloseAppViewModel>();
            ViewModelLocationProvider.Register<StartDateView, StartDateViewModel>();
            ViewModelLocationProvider.Register<LinkUrlUpload, LinkUrlUploadViewModel>();
            ViewModelLocationProvider.Register<LinkUrlSaveFile, LinkUrlSaveFileViewModel>();
            ViewModelLocationProvider.Register<ConvertExcelFileView, ConvertExcelFileViewModel>();
            ViewModelLocationProvider.Register<ConvertExcelFileWindow, ConvertExcelFileWindowViewModel>();

        }

    }
}
