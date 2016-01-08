using System;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Foundation;
using UIKit;
using XamMvvmCorssMarvel.Core.Models;
using Cirrious.MvvmCross.Binding.BindingContext;
using CoreGraphics;

namespace XamMvvmCrossMarvel.iOS.Tables
{
	public class CharacterViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("CharcaterViewCell");
		//public static nfloat RowHeight = 60f;


		MvxImageView thumbnail;
		UILabel name;

		public CharacterViewCell (IntPtr handle): base(handle)
		{
			InitCell ();

			this.DelayBind(() => {
				var set = this.CreateBindingSet<CharacterViewCell, CharacterItemViewModel> ();
				set.Bind(name).To (item => item.Name);
				set.Bind (thumbnail).To (item => item.Thumbnail); 
				set.Apply();
			});
		}


		public static float GetCellHeight()
		{
			return 80f;
		}

		private void InitCell()
		{
			Frame = new CGRect(0, 0, ContentView.Bounds.Width, GetCellHeight());
			BackgroundColor = UIColor.Clear;

			thumbnail = new MvxImageView (new CGRect (0, 0, 80, GetCellHeight()));
			this.AddSubview (thumbnail);

			name = new UILabel (new CGRect (85, 0, ContentView.Bounds.Width - 85, GetCellHeight()));
			name.Font = UIFont.BoldSystemFontOfSize (17);
			name.Lines = 0;
			name.LineBreakMode = UILineBreakMode.WordWrap;
			this.AddSubview (name);

		}
	}
}

