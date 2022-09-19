using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CodingChallenge.ViewModels
{
    public class WebViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _url;
        private INavigation _navigation;

        public string Title {
            get => _title;
            set 
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            } 
        }

        public string Url {
            get => _url;
            set
            {
                _url = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));
            } 
        }
        public WebViewModel(INavigation navigation, string url)
        {
            Title = url;
            Url = url;
            _navigation = navigation;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
