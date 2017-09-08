using System;
using CoreGraphics;
using UIKit;

namespace myOwnSampleSideMenu
{
	/// <summary>
	/// Page navigation helper.
	/// </summary>
	public static class PageNavigationHelper
	{

		/// <summary>
		/// Sets the back button.
		/// </summary>
		/// <param name="navigationItem">The navigation item.</param>
		public static void SetBackButton(UINavigationItem navigationItem)
		{
			var barItem = new UIBarButtonItem();
			barItem.Title = string.Empty;
			navigationItem.BackBarButtonItem = barItem;
		}

		/// <summary>
		/// Sets the back button.
		/// </summary>
		/// <param name="navigationItem">The navigation item.</param>
		public static void SetHamburgerMenu(UINavigationItem navigationItem, UIView parentView)
		{

			//var button = new UIButton(UIButtonType.Custom)
			//{
			//	Frame = new CGRect(0, 0, 25, 25) //You may need to adjust as necessary
			//}
			//;
			//button.SetTitle("Menu", UIControlState.Normal);
			//button.SetTitleColor(UIColor.Black, UIControlState.Normal);

			//create a UIBarButtonItem with a UIButton as the custom view.
			//var barButtonItem = new UIBarButtonItem(button);

			navigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
				"Menu", UIBarButtonItemStyle.Plain, (sender, e) =>
				{
                     ShowSideBar(parentView);
				}), true);
		}

		/// <summary>
		/// Backs the button touch up inside.
		/// </summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Event args.</param>
		public static void BackButtonTouchUpInside(object sender, EventArgs e)
		{
			var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;

			appDelegate.MainNavController.PopViewController(true);
		}

		/// <summary>
		/// Shows the side bar.
		/// </summary>
		/// <summary>
		/// Shows the side bar.
		/// </summary>
		public static void ShowSideBar(UIView parentView)
		{

			DependencyProvider.Instance.SideBarMenuController.ShowFrom = PositionEnum.eSideBarFromLeft;
			DependencyProvider.Instance.SideBarMenuController.ShowPercentage = 1.0;
			DependencyProvider.Instance.SideBarMenuController.ShowAlpha = 0.45f;

			var appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
			var currentViewController = appDelegate.MainNavController;
			parentView.EndEditing(true);

			var barFrame = currentViewController.View.Frame;

			barFrame.Width *= (nfloat)0.6;

			DependencyProvider.Instance.SideBarMenuController.ToggleSideBarWithFrame(barFrame, currentViewController.View);

		}
	}
}