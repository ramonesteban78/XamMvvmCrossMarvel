using System;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

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

        #region NavigateBack command
        private MvxCommand<object> _navigateBackCommand;

        public ICommand NavigateBackCommand
        {
            get
            {
                _navigateBackCommand = _navigateBackCommand ?? new MvxCommand<object>(DoNavigateBackCommand);
                return _navigateBackCommand;
            }
        }

        private void DoNavigateBackCommand(object item)
        {
            Close(this);
        }
        #endregion
    }
}

