using System;
using UIKit;

namespace myOwnSampleSideMenu
{
	public class BaseVC : UIViewController
	{
		public bool _backButtonRequired = true;
		public bool _hamburgerMenuRequired = true;
		protected SideBarMenuController SideBarMenuController { get; set; }
		public int SelectedTabIndex { get; set; }
		public BaseVC(string nibName)
			: base(nibName, null)
		{
			Title = string.Empty;
		}
		public bool BackButtonRequired
		{
			get
			{
				return _backButtonRequired;
			}

			set
			{
				_backButtonRequired = value;
			}
		}
		public bool HamburgerMenuRequired
		{
			get
			{
				return _hamburgerMenuRequired;
			}

			set
			{
				_hamburgerMenuRequired = value;
			}
		}
		public AppDelegate MainDelegate
		{
			get
			{
				return (AppDelegate)UIApplication.SharedApplication.Delegate;
			}
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			MainDelegate.MainNavController.NavigationBar.BarTintColor = UIColor.FromRGB(32, 33, 82);
			MainDelegate.MainNavController.NavigationBar.TitleTextAttributes = new UIStringAttributes
			{
				ForegroundColor = UIColor.White,
				Font = UIFont.BoldSystemFontOfSize(20.0f)
			};
			MainDelegate.MainNavController.NavigationBar.TintColor = UIColor.White;
			AutomaticallyAdjustsScrollViewInsets = false;
			EdgesForExtendedLayout = UIRectEdge.None;

			if (NavigationItem != null && _backButtonRequired)
			{
				PageNavigationHelper.SetBackButton(NavigationItem);
			}

			if (NavigationItem != null && _hamburgerMenuRequired)
			{
				PageNavigationHelper.SetHamburgerMenu(NavigationItem, View);
			}
		}
		/// <summary>
		/// Views the did appear.
		/// </summary>
		/// <param name="animated">if set to <c>true</c> [animated].</param>
		/// <remarks>
		/// <para>This method is called after the <see cref="T:UIKit.UIView" /> that is <c>this</c> <see cref="T:UIKit.UIViewController" />’s <see cref="P:UIKit.UIViewController.View" /> property is added to the display <see cref="T:UIKit.UIView" /> hierarchy. </para>
		/// <para>Application developers who override this method must call <c>base.ViewDidAppear()</c> in their overridden method.</para>
		/// </remarks>
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

		}

		///// <summary>
		///// Handles the button touch down.
		///// </summary>
		///// <param name="sender">The sender.</param>
		///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		//public void HandleButtonTouchDown(object sender, EventArgs e)
		//{
		//	if (sender != null && sender is UIButton)
		//	{
		//		((UIButton)sender).StyleTouchState();
		//	}
		//	Console.Write(e);
		//}

		/// <summary>
		/// Turns auto-rotation on or off.
		/// </summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:UIKit.UIViewController" /> should auto-rotate, <see langword="false" /> otherwise.
		/// </returns>
		public override bool ShouldAutorotate()
		{
			return true;
		}

		/// <summary>
		/// The orientations supported by this <see cref="T:UIKit.UIViewController" />.
		/// </summary>
		/// <returns>
		/// A <see cref="T:UIKit.UIInterfaceOrientationMask" /> of the orientations supported by this <see cref="T:UIKit.UIViewController" />.
		/// </returns>
		/// <remarks>
		/// <para>When the user changes the device orientation, the system calls this method on the root view controller or the topmost presented view controller that fills the window. If the view controller supports the new orientation, the window and view controller are rotated to the new orientation. This method is only called if the view controller's should Auto rotate method returns YES.</para>
		/// <para>Override this method to report all of the orientations that the view controller supports. The default values for a view controller's supported interface orientations is set to UIInterfaceOrientationMaskAll for the iPad idiom and UIInterfaceOrientationMaskAllButUpsideDown for the iPhone idiom.</para>
		/// <para>The system intersects the view controller's supported orientations with the app's supported orientations (as determined by the Info.PLIST file or the app delegate's application:supportedInterfaceOrientationsForWindow: method) to determine whether to rotate.
		/// </para>
		/// </remarks>
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.Portrait;
		}

		/// <summary>
		/// Hides the back button.
		/// </summary>
		public void HideBackButton()
		{
			NavigationItem.LeftBarButtonItem = null;
		}

		/// <summary>
		/// Navigates to login screen.
		/// </summary>
		/// <returns>
		///   <c>true</c>, if to login screen was navigated, <c>false</c> otherwise.
		/// </returns>
		//public bool NavigateToLoginScreen()
		//{
		//	MainDelegate.Window.RootViewController = new HomeVC();
		//	return true;
		//}
		/// <summary>
		/// Backs the button disabled.
		/// </summary>
		public void BackButtonDisabled()
		{
			NavigationController.NavigationBar.UserInteractionEnabled = false;
		}
		/// <summary>
		/// Backs the button enabled.
		/// </summary>
		public void BackButtonEnabled()
		{
			NavigationController.NavigationBar.UserInteractionEnabled = true;
		}
	}
}