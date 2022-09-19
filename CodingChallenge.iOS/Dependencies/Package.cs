using CodingChallenge.iOS.Dependencies;
using CodingChallenge.Services;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Package))]
namespace CodingChallenge.iOS.Dependencies
{
    public class Package : IPackageService
    {
        public string PackageName
        {
            get => NSBundle.MainBundle.BundleIdentifier;
        }
    }
}