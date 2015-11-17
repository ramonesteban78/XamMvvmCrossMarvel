using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace XamMvvmCrossMarvel.Droid.Views
{
	[Activity(Label = "Marvel Comics",  MainLauncher = true, Icon = "@drawable/icon")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}