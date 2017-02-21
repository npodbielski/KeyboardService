namespace KeyboardService.Services.Keyboard
{
    public interface ISoftwareKeyboardService
    {
        event SoftwareKeyboardEventHandler Hide;

        event SoftwareKeyboardEventHandler Show;
    }
}