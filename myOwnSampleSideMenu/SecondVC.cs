using System;

using UIKit;

namespace myOwnSampleSideMenu
{
	public partial class SecondVC : BaseVC
	{
		public SecondVC(bool backButtonRequired, bool hamburgerRequired) : base("SecondVC")
		{
			HamburgerMenuRequired = hamburgerRequired ;
			BackButtonRequired = backButtonRequired;
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

