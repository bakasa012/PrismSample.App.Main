using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Windows;

namespace PrismSample.Lib.ViewModels
{
    public class CloseAppViewModel : BindableBase
    {
        public ReactiveProperty<string> BtnCloseApp { get; } = new ReactiveProperty<string>("メニュー");

        public ReactiveCommand<object> CloseAppCommand { get; }

        public CloseAppViewModel(IEventAggregator eventAggregator)
        {
            CloseAppCommand = new ReactiveCommand<object>().WithSubscribe(_ => CloseApp());
        }

        private void CloseApp()
        {
            MessageBoxResult messageBoxResult = WPFCustomMessageBox.CustomMessageBox.ShowOKCancel("プログラムを終了しますか？", "", "はい", "いいえ");
            if (messageBoxResult == MessageBoxResult.OK)
                Application.Current.MainWindow.Close();
        }
    }
}
