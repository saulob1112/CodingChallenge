using CodingChallenge.ViewModels;
using Ninject;
using NUnit.Framework;

namespace NUnitTests.ViewModels
{
    public class MainViewModelTests : BaseTests
    {
        [Test]
        public void Show_Universities_ShouldBe_True()
        {
            // 1. Arrange
            var mainViewModel = Kernel.Get<MainViewModel>();

            // 2. Act
            mainViewModel.LoadUniversitiesCommand.Execute();

            // 3. Assert
            Assert.IsTrue(mainViewModel.AreUniversities);
        }
    }
}
