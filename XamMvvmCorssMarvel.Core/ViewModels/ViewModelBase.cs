using System;
using Cirrious.MvvmCross.ViewModels;

namespace XamMvvmCorssMarvel.Core.ViewModels
{
	public class ViewModelBase : MvxViewModel
	{
		#region IsBusy

		private bool _IsBusy;

		public bool IsBusy { 
			get { return _IsBusy; }
			set { 
				_IsBusy = value; 
				RaisePropertyChanged (() => this.IsBusy); 
			}
		}

		#endregion
	}
}

