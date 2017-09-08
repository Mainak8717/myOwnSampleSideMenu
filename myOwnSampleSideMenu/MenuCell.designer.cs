// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace myOwnSampleSideMenu
{
    [Register ("MenuCell")]
    partial class MenuCell
    {
        [Outlet]
        UIKit.UIImageView menuIcon { get; set; }


        [Outlet]
        UIKit.UILabel menuTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (menuIcon != null) {
                menuIcon.Dispose ();
                menuIcon = null;
            }

            if (menuTitle != null) {
                menuTitle.Dispose ();
                menuTitle = null;
            }
        }
    }
}