using System;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PrismSample.Lib.ViewModels
{
    public class LinkUrlSaveFileViewModel :BindableBase
    {
        public ReactiveProperty<string> LabelLinkUrlSaveFile { get; } = new ReactiveProperty<string>("出力先");

        public ReactiveProperty<string> LinkUrlSaveFile { get; } = new ReactiveProperty<string>(@"C:\業務課プログラム\自己調達許諾シール給付申請書システム\提出\");

    }
}
