using CodingChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingChallenge.Pages
{
    public partial class WebPage : ContentPage
    {
        WebViewModel _webviewmodel;
        public WebPage(string url)
        {
            InitializeComponent();
            _webviewmodel = new WebViewModel(Navigation, url);
            BindingContext = _webviewmodel;
        }
    }
}