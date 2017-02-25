using System.ComponentModel;
using System.Runtime.CompilerServices;
using KeyboardService.Services.Keyboard;
using TinyIoC;

namespace KeyboardService.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _event;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            var keyboardService = TinyIoCContainer.Current.Resolve<ISoftwareKeyboardService>();
            keyboardService.Hide += _keyboardService_Hide;
            keyboardService.Show += _keyboardService_Show;
        }

        private void _keyboardService_Show(object sender, SoftwareKeyboardEventArgs args)
        {
            Event = "Show event handler invoked";
        }

        private void _keyboardService_Hide(object sender, SoftwareKeyboardEventArgs args)
        {
            Event = "Hide event handler invoked";
        }

        public string Event
        {
            get { return _event; }
            set
            {
                _event = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}