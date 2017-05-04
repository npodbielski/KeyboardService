using Android.Widget;
using GaspolOrder.Extensions;
using KeyboardService.Renderers;
using System;
using TinyIoC;
using Xamarin.Forms;
using AndroidView = Android.Views.View;
using XamarinView = Xamarin.Forms.View;

namespace KeyboardService.Services.Keyboard
{
    public static class EditorsScrollingHelper
    {
        private static double _elementHeight;
        private static XamarinView _focusedElement;

        static EditorsScrollingHelper()
        {
            TinyIoCContainer.Current.Resolve<ISoftwareKeyboardService>().Show += OnKeyboardShow;
        }

        public static void AttachToControl(TextView control, ScrollEditorRenderer renderer)
        {
            control.FocusChange += (s, e) =>
            {
                FocusChange(e, renderer.Element);
            };
        }

        public static void AttachToControl(TextView control, ScrollEntryRenderer renderer)
        {
            control.FocusChange += (s, e) =>
            {
                FocusChange(e, renderer.Element);
            };
        }

        public static void ScrollIfNotVisible(XamarinView element)
        {
            double translationY = 0;
            var parent = element;
            while (parent != null)
            {
                translationY -= parent.Y;
                parent = parent.Parent as XamarinView;
            }
            var height = Application.Current.MainPage.Bounds.Height;
            var elementHeight = _elementHeight;
            translationY -= elementHeight;
            if (-translationY > height)
            {
                if (Math.Abs(Application.Current.MainPage.TranslationY - translationY) > 0.99)
                {
                    Application.Current.MainPage.SetTranslation(
                        translationY + height / 2 - elementHeight / 2);
                }
            }
        }

        private static void FocusChange(AndroidView.FocusChangeEventArgs e, XamarinView element)
        {
            if (e.HasFocus)
            {
                _focusedElement = element;
                _elementHeight = element.Bounds.Height;
            }
            else _focusedElement = null;
        }

        private static void OnKeyboardShow(object sender, SoftwareKeyboardEventArgs args)
        {
            if (_focusedElement != null)
            {
                ScrollIfNotVisible(_focusedElement);
            }
        }
    }
}