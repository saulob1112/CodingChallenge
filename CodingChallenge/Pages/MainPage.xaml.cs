using CodingChallenge.Services;
using CodingChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CodingChallenge
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _mainViewModel;
        public string PhotoPath { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel(Navigation);
            BindingContext = _mainViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _mainViewModel.LoadUniversitiesCommand.Execute(null);
        }

        private void btnTakePhoto_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await TakePhotoAsync();

                PhotoImage.Source = ImageSource.FromFile(PhotoPath);
            });
        }

        public async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Not supported on this device
                Console.WriteLine($"Capture Error: { fnsEx.Message}");
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
                Console.WriteLine($"Capture Error: { pEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Capture Error: { ex.Message}");
            }

        }

        public async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;

        }
    }
}
