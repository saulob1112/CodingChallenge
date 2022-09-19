using CodingChallenge.Droid.Dependencies;
using CodingChallenge.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Package))]
namespace CodingChallenge.Droid.Dependencies
{
    public class Package : IPackageService
    {
        public string PackageName {
            get => Android.App.Application.Context.PackageName;     
        }
    }
}