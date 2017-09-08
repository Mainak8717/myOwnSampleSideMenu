// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace myOwnSampleSideMenu
{
	[Register ("SideBarMenuController")]
	partial class SideBarMenuController
	{
		[Outlet]
		UIKit.UILabel lblAppVersion { get; set; }

		[Outlet]
		UIKit.UILabel lblUserName { get; set; }

		[Outlet]
		UIKit.UILabel lblWelcome { get; set; }

		[Outlet]
		UIKit.UITableView tblMenu { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblUserName != null) {
				lblUserName.Dispose ();
				lblUserName = null;
			}

			if (lblWelcome != null) {
				lblWelcome.Dispose ();
				lblWelcome = null;
			}

			if (tblMenu != null) {
				tblMenu.Dispose ();
				tblMenu = null;
			}

			if (lblAppVersion != null) {
				lblAppVersion.Dispose ();
				lblAppVersion = null;
			}
		}
	}
}
