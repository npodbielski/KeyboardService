using KeyboardService.Services.Keyboard;
using KeyboardService.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(ScrollEditorRenderer))]
namespace KeyboardService.Renderers
{
    public class ScrollEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            EditorsScrollingHelper.AttachToControl(Control, this);
        }
    }
}