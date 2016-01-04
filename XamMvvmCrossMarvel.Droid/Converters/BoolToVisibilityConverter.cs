using System;
using Cirrious.CrossCore.Converters;
using Android.Views;

namespace XamMvvmCrossMarvel.Droid.Converters
{
	public class BoolToVisibilityConverter : MvxValueConverter<bool, ViewStates>
	{
		protected override ViewStates Convert (bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value)
				return ViewStates.Visible;
			return ViewStates.Gone;
		}
	}
}

