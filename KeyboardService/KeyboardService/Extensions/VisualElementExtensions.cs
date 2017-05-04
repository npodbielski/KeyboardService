using Xamarin.Forms;

namespace GaspolOrder.Extensions
{
    public static class VisualElementExtensions
    {
        public static void SetTranslation(this VisualElement element, double y)
        {
            element.TranslationY = y;
            var rectangle = new Rectangle
            {
                Left = element.X,
                Top = element.Y //+ y
                ,
                Width = element.Width,
                Height = element.Height + (y < 0 ? -y : 0)
            };
            element.Layout(rectangle);
        }
    }
}