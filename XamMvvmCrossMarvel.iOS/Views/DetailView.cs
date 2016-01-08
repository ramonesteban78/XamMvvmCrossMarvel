using System;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using UIKit;
using CoreGraphics;
using Cirrious.MvvmCross.Binding.BindingContext;
using XamMvvmCorssMarvel.Core.ViewModels;

namespace XamMvvmCrossMarvel.iOS.Views
{
	public class DetailView : MvxViewController
	{
		MvxImageView thumbnail;
		UILabel description;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			InitView ();

			MvvmBinding ();
		}

		void InitView ()
		{
			this.View.BackgroundColor = UIColor.White;
			thumbnail = new MvxImageView (new CGRect (0, 65, View.Bounds.Width, 320));
			View.Add (thumbnail);

			description = new UILabel (new CGRect (5, 65 + thumbnail.Frame.Height + 10, View.Bounds.Width - 10, View.Bounds.Height - (65 + thumbnail.Frame.Height + 10)));
			description.Lines = 0;
			description.LineBreakMode = UILineBreakMode.WordWrap;
			description.Font = UIFont.SystemFontOfSize (15);


			View.Add (description);
		}

		void MvvmBinding ()
		{
			// MvvmCross Bindings
			var set = this.CreateBindingSet<DetailView, DetailViewModel> ();
			set.Bind (thumbnail).To (vm => vm.Character.Thumbnail);
			set.Bind (this).For ("Title").To (vm => vm.Character.Name);

			description.Text = ((DetailViewModel)this.ViewModel).Character.Description;
			description.SizeToFit ();

			set.Apply ();
		}
	}
}

