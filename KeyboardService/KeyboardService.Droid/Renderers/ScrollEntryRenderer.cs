using KeyboardService.Renderers;
using KeyboardService.Services.Keyboard;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(ScrollEntryRenderer))]
// ReSharper disable once CheckNamespace

namespace KeyboardService.Renderers
{
    /// <summary>
    ///     Class ScrollEntryRenderer.
    /// </summary>
    public class ScrollEntryRenderer : EntryRenderer
    {
        /// <summary>
        ///     Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            EditorsScrollingHelper.AttachToControl(Control, this);
        }
    }
}