using System.ComponentModel;
using System.Runtime.CompilerServices;
using KeyboardService.Services.Keyboard;
using TinyIoC;

namespace KeyboardService.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            var keyboardService = TinyIoCContainer.Current.Resolve<ISoftwareKeyboardService>();
            keyboardService.Hide += _keyboardService_Hide;
            keyboardService.Show += _keyboardService_Show;
        }

        private static void _keyboardService_Show(object sender, SoftwareKeyboardEventArgs args)
        {
            
        }

        private static void _keyboardService_Hide(object sender, SoftwareKeyboardEventArgs args)
        {
            
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}