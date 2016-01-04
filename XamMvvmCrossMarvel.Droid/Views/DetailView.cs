using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Android.App;
using Cirrious.MvvmCross.Binding.BindingContext;
using XamMvvmCorssMarvel.Core.ViewModels;

namespace XamMvvmCrossMarvel.Droid.Views
{
	


	[Activity(Icon = "@drawable/icon", Theme="@android:style/Theme.DeviceDefault.Light")]
	public class DetailView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.DetailView);

			// Set title of the page
			this.CreateBinding().For("Title").To<DetailViewModel>(vm => vm.Character.Name).Apply();

			ActionBar.SetHomeButtonEnabled(true);
			ActionBar.SetDisplayHomeAsUpEnabled(true);

		}


		public override bool OnOptionsItemSelected (Android.Views.IMenuItem item)
		{
			Finish ();
			return true;
		}
	}
}