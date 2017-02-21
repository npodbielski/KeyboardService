namespace KeyboardService.Services.Keyboard
{
    public abstract class KeyboardServiceBase
    {
        public virtual event SoftwareKeyboardEventHandler Hide;

        public virtual event SoftwareKeyboardEventHandler Show;

        public void OnOnKeyboardHide(SoftwareKeyboardEventArgs args)
        {
            OnHide();
            var handler = Hide;
            handler?.Invoke(this, args);
        }

        public void OnOnKeyboardShow(SoftwareKeyboardEventArgs args)
        {
            var handler = Show;
            handler?.Invoke(this, args);
        }

        protected virtual void OnHide()
        {
        }
    }
}