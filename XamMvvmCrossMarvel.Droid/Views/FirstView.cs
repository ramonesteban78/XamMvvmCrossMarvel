using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Android.App;
using XamMvvmCorssMarvel.Core.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace XamMvvmCrossMarvel.Droid.Views
{
	[Activity(Label = "Marvel Comics",  MainLauncher = true, Icon = "@drawable/icon", Theme="@android:style/Theme.DeviceDefault.Light")]
	public class FirstView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.FirstView);


		}
	}
}