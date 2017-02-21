using Android.App;
using Android.Content.PM;
using Android.OS;
using KeyboardService.Services.Keyboard;
using TinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace KeyboardService
{
    [Activity(Label = "Keyboard service", Icon = "@drawable/icon", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : FormsApplicationActivity
    {
        protected sealed override void OnCreate(Bundle bundle)
        {
            TinyIoCContainer.Current.Register<ISoftwareKeyboardService, SoftwareKeyboardService>().AsSingleton();
            TinyIoCContainer.Current.Register(this);
            Forms.Init(this, bundle, GetType().Assembly);
            base.OnCreate(bundle);
            LoadApplication(new App());
        }
    }
}