using System;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PrismSample.Lib.ViewModels
{
    public class StartDateViewModel : BindableBase
    {
        public ReactiveProperty<string> LabelStartdate { get; } = new ReactiveProperty<string>("年月");

        public ReactiveProperty<string> DateStartSelected { get; } = new ReactiveProperty<string>("");

    }
}
