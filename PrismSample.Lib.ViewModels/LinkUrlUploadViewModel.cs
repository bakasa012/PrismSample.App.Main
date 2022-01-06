using System;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PrismSample.Lib.ViewModels
{
    public class LinkUrlUploadViewModel : BindableBase
    {
        public ReactiveProperty<string> LabelLinkUrlUpload { get; } = new ReactiveProperty<string>("変換フォルダ");

        public ReactiveProperty<string> LinkUrlUpload { get; } = new ReactiveProperty<string>(@"C:\業務課プログラム\自己調達許諾シール給付申請書システム\解凍後データ保存場所\");

        public LinkUrlUploadViewModel()
        {

        }
    }
}
