namespace KeyboardService.Services.Keyboard
{
    public class SoftwareKeyboardService : KeyboardServiceBase, ISoftwareKeyboardService
    {
        private readonly MainActivity _activity;
        private GlobalLayoutListener _globalLayoutListener;

        public SoftwareKeyboardService(MainActivity activity)
        {
            _activity = activity;
        }

        public override event SoftwareKeyboardEventHandler Show
        {
            add
            {
                base.Show += value;
                if (_globalLayoutListener == null)
                {
                    _globalLayoutListener = new GlobalLayoutListener(this);
                    _activity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(_globalLayoutListener);
                }
            }
            remove { base.Show -= value; }
        }
    }
}