namespace KeyboardService.Services.Keyboard
{
    public abstract class SoftwareKeyboardServiceBase : ISoftwareKeyboardService
    {
        public virtual event SoftwareKeyboardEventHandler Hide;

        public virtual event SoftwareKeyboardEventHandler Show;

        public void InvokeKeyboardHide(SoftwareKeyboardEventArgs args)
        {
            OnHide();
            var handler = Hide;
            handler?.Invoke(this, args);
        }

        public void InvokeKeyboardShow(SoftwareKeyboardEventArgs args)
        {
            var handler = Show;
            handler?.Invoke(this, args);
        }

        protected virtual void OnHide()
        {
        }
    }
}