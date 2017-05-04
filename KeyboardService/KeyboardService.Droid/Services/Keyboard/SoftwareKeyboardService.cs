using Android.App;
using GaspolOrder.Extensions;
using Application = Xamarin.Forms.Application;

namespace KeyboardService.Services.Keyboard
{
    public class SoftwareKeyboardService : SoftwareKeyboardServiceBase
    {
        private readonly Activity _activity;
        private GlobalLayoutListener _globalLayoutListener;

        public SoftwareKeyboardService(MainActivity activity)
        {
            _activity = activity;
        }

        public override event SoftwareKeyboardEventHandler Hide
        {
            add
            {
                base.Hide += value;
                CheckListener();
            }
            remove { base.Hide -= value; }
        }

        public override event SoftwareKeyboardEventHandler Show
        {
            add
            {
                base.Show += value;
                CheckListener();
            }
            remove { base.Show -= value; }
        }

        private void CheckListener()
        {
            if (_globalLayoutListener == null)
            {
                _globalLayoutListener = new GlobalLayoutListener(this);
                _activity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(_globalLayoutListener);
            }
        }

        protected override void OnHide()
        {
            if (Application.Current.MainPage != null)
            {
                Application.Current.MainPage.SetTranslation(0);
            }
        }
    }
}