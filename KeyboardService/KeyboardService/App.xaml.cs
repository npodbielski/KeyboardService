using KeyboardService.View;
using KeyboardService.ViewModel;

namespace KeyboardService
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPageView
            {
                BindingContext = new MainPageViewModel()
            };
        }
    }
}