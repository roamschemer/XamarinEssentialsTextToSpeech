using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinEssentialsTextToSpeech.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public ReactiveProperty<string> SpeechText { get; set; } = new ReactiveProperty<string>("初めまして。私は、かきょうらんです。抽選用アプリケーションやってます。");
        public ReactiveCommand SpeechStart { get; set; } = new ReactiveCommand();
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Xamarin.Essentials TextToSpeech";
            SpeechStart.Subscribe(async _ => await SpeakNowDefaultSettings());
        }
        public async Task SpeakNowDefaultSettings()
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            // Grab the first locale
            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = (float)0.5,
                Pitch = (float)2.0,
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(SpeechText.Value, settings);

        }

    }
}
