using Android.App;
using Android.Widget;
using Android.OS;
using PortableLib;

namespace DroidClient
{
    [Activity(Label = "DroidClient", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            string isPortable = new PortableService().Portable();
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

