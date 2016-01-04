using System;
using XamMvvmCorssMarvel.Core.Models;

namespace XamMvvmCorssMarvel.Core.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		public DetailViewModel ()
		{
		}

		#region Character

		private CharacterItemViewModel _Character;

		public CharacterItemViewModel Character { 
			get { return _Character; }
			set { 
				_Character = value; 
				RaisePropertyChanged (() => this.Character); 
			}
		}

		#endregion


		public void Init(CharacterItemViewModel character)
		{
			Character = character;
		}

	}
}

