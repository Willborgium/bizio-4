using BlackPlain.Core;

namespace BlackPlain.Bizio.App
{
    public partial class App : Application
    {
        public App()
        {
            UIManager.SetTaskScheduler();

            InitializeComponent();
        }
    }
}
