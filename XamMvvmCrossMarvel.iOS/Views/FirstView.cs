using System;
using Cirrious.MvvmCross.Touch.Views;
using UIKit;
using Foundation;
using CoreGraphics;
using Cirrious.MvvmCross.Binding.Touch.Views;
using XamMvvmCorssMarvel.Core.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using System.Collections.Generic;
using XamMvvmCrossMarvel.iOS.Tables;
using XamMvvmCrossMarvel.iOS.Controls;

namespace XamMvvmCrossMarvel.iOS.Views
{
	[Register("FirstView")]
	public class FirstView : MvxViewController
	{
		UISearchBar searchBar;
		UITableView tvCharacters;
		CustomActivityIndicatorView activity;
		CharacterTableViewSource source;

		private float y_axis = 65;


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.InitView ();

			this.MvvmBindings ();
		}

		private void InitView()
		{
			Title = "Marvel Characters";

			searchBar = new UISearchBar (new CGRect (0, y_axis, UIScreen.MainScreen.Bounds.Width, 44));
			searchBar.BarStyle = UIBarStyle.Default;
			View.Add (searchBar);

			y_axis += 44;

			tvCharacters = new UITableView (new CGRect (0, y_axis, View.Bounds.Width, View.Bounds.Height - searchBar.Frame.Height)); 
			tvCharacters.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			View.Add (tvCharacters);


			activity = new CustomActivityIndicatorView (new CGRect (0, 0, View.Bounds.Width, View.Bounds.Height));
			activity.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
			View.Add (activity);
			View.BringSubviewToFront (activity);

		}

		private void MvvmBindings()
		{
			// Init the table source
			source = new CharacterTableViewSource(tvCharacters);

			// MvvmCross Bindings
			var set = this.CreateBindingSet<FirstView, FirstViewModel> ();
			//set.Bind (searchBar).For("SearchButtonClicked").To (vm => vm.SearchByNameCommand);
			set.Bind (searchBar).To (vm => vm.SearchText);
			set.Bind (source).To (vm => vm.CharacterList);
			set.Bind(source).For(s => s.SelectionChangedCommand).To (vm => vm.CharacterSelectionCommand);
			set.Bind (activity).For (x => x.Animate).To (vm => vm.IsBusy);


			var viewModel = this.ViewModel as FirstViewModel;
			searchBar.SearchButtonClicked += (object sender, EventArgs e) => {
				viewModel.SearchByNameCommand.Execute(null);
				this.searchBar.ResignFirstResponder ();
			};



			this.tvCharacters.Source = source;
			this.tvCharacters.ReloadData();

			set.Apply ();
		}
	}
}

