using Cirrious.MvvmCross.ViewModels;
using XamMvvmCorssMarvel.Core.Models;
using System.Collections.Generic;
using XamMvvmCorssMarvel.Core.Services;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace XamMvvmCorssMarvel.Core.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
		private readonly IMarvelApiService _marvelService;
		public FirstViewModel (IMarvelApiService marvelService)
		{
			_marvelService = marvelService;
		}

		public async void Init()
		{
			await LoadData ();
		}

		#region SearchText

		private string _SearchText;

		public string SearchText { 
			get { return _SearchText; }
			set { 
				_SearchText = value; 
				RaisePropertyChanged (() => this.SearchText); 
			}
		}

		#endregion

		#region CharacterList

		private List<CharacterItemViewModel> _CharacterList;

		public List<CharacterItemViewModel> CharacterList { 
			get { return _CharacterList; }
			set { 
				_CharacterList = value; 
				RaisePropertyChanged (() => this.CharacterList); 
			}
		}

		#endregion

		#region SearchByName command
		private MvxCommand _SearchByNameCommand;

		public ICommand SearchByNameCommand
		{
		    get
		    {
				_SearchByNameCommand = _SearchByNameCommand ?? new MvxCommand(async () => await DoSearchByNameCommand());
		       return _SearchByNameCommand;
		    }
		}

		private async Task DoSearchByNameCommand()
		{
			await LoadData (SearchText);
		}
		#endregion

		#region CharacterSelection command
		private MvxCommand<CharacterItemViewModel> _CharacterSelectionCommand;

		public ICommand CharacterSelectionCommand
		{
		    get
		    {
				_CharacterSelectionCommand = _CharacterSelectionCommand ?? new MvxCommand<CharacterItemViewModel>(DoCharacterSelectionCommand);
		       return _CharacterSelectionCommand;
		    }
		}

		private void DoCharacterSelectionCommand(CharacterItemViewModel item)
		{
			this.ShowViewModel<DetailViewModel> (item);      
		}
		#endregion

		#region LoadData

		private async Task LoadData (string filter = null, int limit = 0, int offset = 0)
		{
			IsBusy = true;

			var result = await _marvelService.GetCharacters (filter, limit, offset);


			if (result != null) {
				CharacterList = (from p in result.Results
				                 select new CharacterItemViewModel () {
						Id = p.Id,
						Name = p.Name,
						Thumbnail = p.Thumbnail.Path + "." + p.Thumbnail.Extension,
						Description = p.Description
				}).ToList ();
			}

			IsBusy = false;

		}

		#endregion
    }
}
