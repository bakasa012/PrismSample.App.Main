using Prism.Events;
using Prism.Mvvm;
using PrismSample.Lib.Views;
using Reactive.Bindings;
using System.Windows;
namespace PrismSample.Lib.ViewModels
{
    public class ConvertExcelFileViewModel : BindableBase
    {
        public ReactiveProperty<string> BtnConvertExcelFile { get; } = new ReactiveProperty<string>("変換");
        public ReactiveCommand<object> ConvertExcelFileCommand { get; }
        public ConvertExcelFileViewModel(IEventAggregator eventAggregator)
        {
            //CloseAppCommand = new ReactiveCommand<object>().WithSubscribe(_ => CloseApp());
            eventAggregator
                .GetEvent<PubSubEvent<double>>()
                .Subscribe(showMess);
            ConvertExcelFileCommand = new ReactiveCommand().WithSubscribe(_ => mess());
        }
        public void showMess(double mess)
        {
            BtnConvertExcelFile.Value = mess.ToString();
        }
        public void mess()
        {
            StartDateViewModel startDateViewModel = new StartDateViewModel();
            StartDateView starDateView = new StartDateView();
            MessageBox.Show("asdsadsad" + startDateViewModel.TextBlock1.Value);
        }
    }
}
