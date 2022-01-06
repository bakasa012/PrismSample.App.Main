using Prism.Events;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using System;
using PrismSample.Lib.Models;
using PrismSample.Lib.Models.ProcessPath;
using PrismSample.Lib.Models.DataBinding;
using System.Collections.Generic;

namespace PrismSample.Lib.ViewModels
{
    public class ConvertExcelFileWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> BtnCloseApp { get; } = new ReactiveProperty<string>("メニュー");
        public ReactiveProperty<string> LabelStartdate { get; } = new ReactiveProperty<string>("年月");
        public ReactiveProperty<string> TextBlock1 { get; }
        [Required,]
        public ReactiveProperty<DateTime> DateStartSelected { get;}
        public ReactiveProperty<string> LabelLinkUrlUpload { get; } = new ReactiveProperty<string>("変換フォルダ");
        public ReactiveProperty<string> LinkUrlUpload { get; } = new ReactiveProperty<string>(@"C:\業務課プログラム\自己調達許諾シール給付申請書システム\解凍後データ保存場所\");
        public ReactiveProperty<string> LabelLinkUrlSaveFile { get; } = new ReactiveProperty<string>("出力先");
        public ReactiveProperty<string> LinkUrlSaveFile { get; } = new ReactiveProperty<string>(@"C:\業務課プログラム\自己調達許諾シール給付申請書システム\提出\");
        public ReactiveProperty<string> BtnConvertExcelFile { get; } = new ReactiveProperty<string>("変換");
       
        
        public ReactiveCommand<object> CloseAppCommand { get; }
        public ReactiveCommand<object> MouseLeftButtonUpLinkUrlUpload { get; }
        public ReactiveCommand<object> MouseLeftButtonUpLinkUrlSaveFile { get; }
        public ReactiveCommand<object> ConvertExcelFileCommand { get; }
        List<DataBindingCompanyCode> dataBindingCompanyCodes = new List<DataBindingCompanyCode>();

        [Obsolete]
        public ConvertExcelFileWindowViewModel()
        {
            CreateOrGetFolder createOrGetFolder = new CreateOrGetFolder();
            ProcessPathFolderOrFile processPathFolderOrFile = new ProcessPathFolderOrFile();
            createOrGetFolder.CheckPathOrCreateFolder(LinkUrlUpload.Value);
            createOrGetFolder.CheckPathOrCreateFolder(LinkUrlSaveFile.Value);
            processPathFolderOrFile.CheckDataJson(Environment.CurrentDirectory + @"\変換M.xls", Environment.CurrentDirectory + @"\dataStore.json", dataBindingCompanyCodes);
            DateStartSelected = new ReactiveProperty<DateTime>(DateTime.Now);
            MouseLeftButtonUpLinkUrlUpload = new ReactiveCommand().WithSubscribe(_ =>DialogOpen.Instance.OpentFolderDialog(LinkUrlUpload));
            MouseLeftButtonUpLinkUrlSaveFile = new ReactiveCommand().WithSubscribe(_ => DialogOpen.Instance.OpentFolderDialog(LinkUrlSaveFile));
            CloseAppCommand = new ReactiveCommand().WithSubscribe(_ => CloseApp());
            ConvertExcelFileCommand = new ReactiveCommand().WithSubscribe(_ => ConvertExcelFileModel.Instance.ProcessConvertExcelFiles(LinkUrlUpload.Value,LinkUrlSaveFile.Value,DateStartSelected.Value.Month.ToString(), dataBindingCompanyCodes));
        }
        void show()
        {
            MessageBox.Show("sadadasdads", LinkUrlSaveFile.Value);
        }
        private void CloseApp()
        {
            MessageBoxResult messageBoxResult = WPFCustomMessageBox.CustomMessageBox.ShowOKCancel("プログラムを終了しますか？", "", "はい", "いいえ");
            if (messageBoxResult == MessageBoxResult.OK)
                Application.Current.MainWindow.Close();
        }
    }
}
