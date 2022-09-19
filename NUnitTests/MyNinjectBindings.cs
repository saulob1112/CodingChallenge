using CodingChallenge.Services;
using Moq;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests
{
    public class MyNinjectBindings : NinjectModule
    {
        public override void Load()
        {
            var packageService = new Mock<IPackageService>();
            var universityService = new Mock<IUniversityService>();
        }
    }
}
