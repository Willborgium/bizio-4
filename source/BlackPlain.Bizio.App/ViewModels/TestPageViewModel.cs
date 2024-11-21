using BlackPlain.Bizio.App.Pages;
using BlackPlain.Core;
using System.Windows.Input;

namespace BlackPlain.Bizio.App.ViewModels
{
    public interface ITestPageViewModel
    {
        public ICommand GoToTestPage2Command { get; }
    }

    public interface ITestPage2ViewModel
    {
        public ICommand GoToTestPageCommand { get; }
    }

    internal class TestPageViewModel : ViewModelBase, ITestPageViewModel
    {
        public ICommand GoToTestPage2Command => GetCommand(GoToTestPage2);

        private void GoToTestPage2()
        {
            Navigator.NavigateTo<TestPage2>();
        }
    }

    internal class TestPage2ViewModel : ViewModelBase, ITestPage2ViewModel
    {
        public ICommand GoToTestPageCommand => GetAsyncCommand(GoToTestPage);

        private void GoToTestPage()
        {
            Navigator.NavigateTo<TestPage>();
        }
    }
}
