using System;
using CoreGraphics;
using UIKit;

namespace XamMvvmCrossMarvel.iOS.Controls
{
	public class CustomActivityIndicatorView: UIActivityIndicatorView
	{
		public CustomActivityIndicatorView (CGRect frame): base(frame)
		{
		}

		private bool _Animate;
		public bool Animate { 
			get 
			{	
				return _Animate;
			} 
			set
			{ 
				Hidden = !value;
				_Animate = value;
				if (value) {
					this.StartAnimating ();
				} else {
					this.StopAnimating ();
				}
			} 
		}
	}
}

