using System.Windows;
using Prism.Ioc;
using Prism.Regions;
using Unity;

namespace PrismSample.Lib.Views
{
    public partial class MainWindow : Window
    {
        [Dependency]
        public IContainerExtension containerExtension { get; set; }
        [Dependency]
        public IRegionManager regionManager { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Onloaded(object sender, RoutedEventArgs e)
        {
            //regionManager.AddToRegion("OperandRegion", containerExtension.Resolve<OperandView>());
            //regionManager.AddToRegion("AnswerRegion", containerExtension.Resolve<Answer>());
            regionManager.AddToRegion("CloseAppRegion", containerExtension.Resolve<CloseAppView>());
            regionManager.AddToRegion("StartDateRegion", containerExtension.Resolve<StartDateView>());
            regionManager.AddToRegion("LinkUrlUploadRegion", containerExtension.Resolve<LinkUrlUpload>());
            regionManager.AddToRegion("LinkUrlSaveFileRegion", containerExtension.Resolve<LinkUrlSaveFile>());
            regionManager.AddToRegion("ConvertExcelFileRegion", containerExtension.Resolve<ConvertExcelFileView>());
        }

    }
}
