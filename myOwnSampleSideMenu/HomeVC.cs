using System;

using UIKit;

namespace myOwnSampleSideMenu
{
	public partial class HomeVC : BaseVC
	{

		public HomeVC(bool backButtonRequired, bool hamburgerRequired) : base("HomeVC")
		{
			BackButtonRequired = backButtonRequired;
            HamburgerMenuRequired = hamburgerRequired;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

