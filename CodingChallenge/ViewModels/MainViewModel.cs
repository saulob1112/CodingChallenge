using CodingChallenge.ConcreteServices;
using CodingChallenge.Models;
using CodingChallenge.Pages;
using CodingChallenge.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Core;

namespace CodingChallenge.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _package;
        private IPackageService _packageService;
        private IUniversityService _universityService;
        private INavigation _navigation;

        public bool AreUniversities { get; private set; }
        public string Title {
            get => _title;
            set 
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            } 
        }

        public string Package {
            get => _package;
            set
            {
                _package = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Package)));
            } 
        }

        public ObservableCollection<University> Universities { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoadUniversitiesCommand { get; private set; }
        public ICommand SendWebPageCommand { get; private set; }

        public MainViewModel(INavigation navigation)
        {
            Title = "Coding Challenge for UnoSquare";
            _navigation = navigation;
            _packageService = DependencyService.Get<IPackageService>();
            _universityService = DependencyService.Get<IUniversityService>();
            Package = _packageService.PackageName;
            Universities = new ObservableCollection<University>();
            LoadUniversitiesCommand = new Command(async () => await OnLoadUniversitiesCommand());
            SendWebPageCommand = new Command<string>((x) => OnSendWebPageCommand(x));
        }

        public void OnSendWebPageCommand(object link)
        {
            _navigation.PushAsync(new WebPage(link.ToString()));
        }

        public async Task OnLoadUniversitiesCommand()
        {
            await LoadUniversities();
        }

        public async Task LoadUniversities()
        {
            var universities = await _universityService.GetUniversitiesAsync();
            if (universities != null)
            {
                AreUniversities = true;
                Universities.Clear();
                foreach (var n in universities)
                {
                    Universities.Add(n);
                }
            } else
            {
                AreUniversities = false;
            }
        }
    }
}
