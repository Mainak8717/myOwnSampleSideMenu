using System;

using UIKit;

namespace myOwnSampleSideMenu
{
	public partial class LoginViewController : BaseVC
	{
		public LoginViewController(bool backButtonRequired, bool hamburgerRequired)  : base("LoginViewController")
		{
			BackButtonRequired = backButtonRequired;
            HamburgerMenuRequired = hamburgerRequired;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationController.NavigationBar.Hidden = true;
			this.submitBtn.TouchUpInside += (sender, e) =>
			{

				BaseNavigationController nav =
					new BaseNavigationController(new HomeVC(false, true));


				MainDelegate.MainNavController = nav;
					MainDelegate.Window.RootViewController = MainDelegate.MainNavController;

			};
		}
	}
}

