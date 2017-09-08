using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace myOwnSampleSideMenu
{
	/// <summary>
	/// Side bar menu controller.
	/// </summary>
	public partial class SideBarMenuController : SideBarControllerBase
	{
		/// <summary>
		/// The menu items.
		/// </summary>
		private List<MenuItem> _menuItems;

		/// <summary>
		/// The menu table source.
		/// </summary>
		private MenuTableSource _menuTableSource;

		/// <summary>
		/// The cell identifier.
		/// </summary>
		private readonly string cellIdentifier = "MenuCellId";

		public AppDelegate MainDelegate
		{

			get { return (AppDelegate)UIApplication.SharedApplication.Delegate; }
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Otis.Meteors.iOS.Views.SideBarMenuController"/> class.
		/// </summary>
		public SideBarMenuController() : base("SideBarMenuController", null)
		{

		}

		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.SetupView();
		}

		/// <summary>
		/// Dids the receive memory warning.
		/// </summary>
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		/// <summary>
		/// Setups the view.
		/// </summary>
		private void SetupView()
		{

			var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
			_menuItems = new List<MenuItem>();
			this.SetupLocalizedStrings();
			tblMenu.RegisterNibForCellReuse(MenuCell.Nib, cellIdentifier);
			tblMenu.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			this.SetupMenu();
		}

		/// <summary>
		/// Setups the menu.
		/// </summary>
		private void SetupMenu()
		{
			_menuTableSource = new MenuTableSource(_menuItems);

			tblMenu.Source = _menuTableSource;

			//_menuTableSource.MenuSelectionHandler += OnMenuItemClick;

			//highlight "Home" by default in menu
			DependencyProvider.Instance.SideBarMenuController = null;
			var indexPath = NSIndexPath.Create(new int[] { 0, 0 });
			tblMenu.SelectRow(indexPath, true, UITableViewScrollPosition.None);
		}

		/// <summary>
		/// Updates the UI language.
		/// </summary>
		private void SetupLocalizedStrings()
		{
			this.lblWelcome.Text = "Welcome";
			//  LocalizationHelper.GetLocalizedString(AppConstants.HamburgerMenu.WelcomeResourceKey);

			this.lblUserName.Text = "Mainak";
			//String.Format("{0} {1}", UserProfile.FirstName, UserProfile.LastName);

			this.lblAppVersion.Text = "1.0";
			//= string.Format("{0} {1}",
			//   LocalizationHelper.GetLocalizedString(AppConstants.HamburgerMenu
			//                                      .ApplicationVersionResourceKey),
			//   NSBundle.MainBundle.InfoDictionary[AppConstants.HamburgerMenu
			//                                    .CFBundleShortVersionString]);

			var homeMenuItem = new MenuItem
			{
				Title = "Home"// LocalizationHelper.GetLocalizedString(AppConstants.HamburgerMenu.HomeResourceKey),
			};

			var LogoutMenuItem = new MenuItem
			{
				Title = "Logout"// LocalizationHelper.GetLocalizedString(AppConstants.HamburgerMenu.LogoutResourceKey),
			};

			_menuItems.Add(homeMenuItem);
			_menuItems.Add(LogoutMenuItem);

		}

		/// <summary>
		/// Ons the menu item click.
		/// </summary>
		/// <param name="currentIndex">Current index.</param>
		/// <param name="menuCell">Menu cell.</param>
		/// <param name="oldInd">Old ind.</param>
		void OnMenuItemClick(int currentIndex, MenuCell menuCell, int oldInd)
		{
			HideSideBar();
			SecondVC home = new SecondVC(false, true);
			var window = UIApplication.SharedApplication.KeyWindow;
			var controller = (UINavigationController)window.RootViewController;

			if (controller != null && !(controller.TopViewController is SecondVC))
			{
				foreach (var viewController in controller.ViewControllers)
				{
					if (viewController is SecondVC)
						home.SelectedTabIndex = ((SecondVC)viewController).SelectedTabIndex;

				}
				BaseNavigationController nav =
				new BaseNavigationController(home);
				this.MainDelegate.MainNavController = nav;
				this.MainDelegate.Window.RootViewController = this.MainDelegate.MainNavController;
			}

		}

		/// <summary>
		/// Menu selection handler.
		/// </summary>
		public delegate void MenuSelectionHandler(int currentIndex, MenuCell menuCell, int oldIndex);

		/// <summary>
		/// Menu table source.
		/// </summary>
		public class MenuTableSource : UITableViewSource
		{
			/// <summary>
			/// The cell identifier.
			/// </summary>
			private readonly string cellIdentifier = "MenuCellId";

			/// <summary>
			/// The menu selection handler.
			/// </summary>
			public MenuSelectionHandler MenuSelectionHandler;

			/// <summary>
			/// The table items.
			/// </summary>
			List<MenuItem> _tableItems;

			/// <summary>
			/// Gets or sets the index of the selected.
			/// </summary>
			/// <value>The index of the selected.</value>
			public int SelectedIndex { get; set; }

			/// <summary>
			/// Initializes a new instance of the
			/// <see cref="T:Otis.Meteors.iOS.Views.SideBarMenuController.MenuTableSource"/> class.
			/// </summary>
			/// <param name="menuitems">Menuitems.</param>
			public MenuTableSource(List<MenuItem> menuitems)
			{
				_tableItems = menuitems;
			}

			/// <summary>
			/// Rowses the in section.
			/// </summary>
			/// <returns>The in section.</returns>
			/// <param name="tableview">Tableview.</param>
			/// <param name="section">Section.</param>
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return _tableItems.Count;
			}

			/// <summary>
			/// Gets the cell.
			/// </summary>
			/// <returns>The cell.</returns>
			/// <param name="tableView">Table view.</param>
			/// <param name="indexPath">Index path.</param>
			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = (MenuCell)tableView.DequeueReusableCell(this.cellIdentifier)
									   ?? new MenuCell(this.cellIdentifier);

				cell.Accessory = UITableViewCellAccessory.None;

				cell.Initialize(_tableItems[indexPath.Row]);

				return cell;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				var oldIndex = SelectedIndex;

				SelectedIndex = indexPath.Row;

				UITableViewCell cell = tableView.CellAt(indexPath);
				var menucell = cell as MenuCell;

				if (MenuSelectionHandler != null)
					MenuSelectionHandler.Invoke(indexPath.Row, menucell, oldIndex);

			}
		}
	}

}


