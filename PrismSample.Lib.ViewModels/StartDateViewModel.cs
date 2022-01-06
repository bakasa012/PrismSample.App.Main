using System;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Reactive.Linq;
using System.ComponentModel.DataAnnotations;
using Prism.Events;
using PrismSample.Lib.Models;

namespace PrismSample.Lib.ViewModels
{
    public class StartDateViewModel : BindableBase
    {
        public IStartDateModel startDateModel;
        public ReactiveProperty<string> LabelStartdate { get; } = new ReactiveProperty<string>("年月");
        public ReactiveProperty<string> TextBlock1 { get; }

        [Required,]
        public ReactiveProperty<string> DateStartSelected { get; set; }
        public StartDateViewModel()
        {
            DateStartSelected = new ReactiveProperty<string>(DateTime.Now.ToString()).SetValidateAttribute(() => DateStartSelected);
            TextBlock1 = DateStartSelected
                .Delay(TimeSpan.FromMilliseconds(100))
                .Select(x => x.ToUpper())
                .ToReactiveProperty();
                //.Subscribe(s => ReactiveCollection());
            //TextBlock1 = new ReactiveProperty<string>(startDateModel.startDate(DateStartSelected.ToString()));


            //if (eventAggregator != null)
            //Observable.WithLatestFrom(DateStartSelected, DateStartSelected.ObserveHasErrors, (r, e) => (r, e)).Where(z => !z.e).Subscribe(z =>
            //   {
            //       eventAggregator.GetEvent<PubSubEvent<double>>().Publish(double.Parse(z.r));
            //   });
        }
    }
}
