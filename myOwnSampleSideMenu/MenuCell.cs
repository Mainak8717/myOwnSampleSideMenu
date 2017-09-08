using System;
using Foundation;
using UIKit;

namespace myOwnSampleSideMenu
{
    /// <summary>
    /// Menu cell.
    /// </summary>
    public partial class MenuCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("MenuCell");
        public static readonly UINib Nib;

        /// <summary>
        /// Initializes the <see cref="T:Otis.Meteors.iOS.Views.MenuCell"/> class.
        /// </summary>
        static MenuCell()
        {
            Nib = UINib.FromName("MenuCell", NSBundle.MainBundle);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Otis.Meteors.iOS.Views.MenuCell"/> class.
        /// </summary>
        /// <param name="reuseIdentifier">Reuse identifier.</param>
        public MenuCell(string reuseIdentifier) : base(UITableViewCellStyle.Default, reuseIdentifier)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Otis.Meteors.iOS.Views.MenuCell"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        protected MenuCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        /// <summary>
        /// Initialize the specified menuItem.
        /// </summary>
        /// <returns>The initialize.</returns>
        /// <param name="menuItem">Menu item.</param>
        public void Initialize(MenuItem menuItem)
        {
            menuTitle.Text = menuItem.Title;
            //menuIcon.Image = UIImage.FromBundle(menuItem.Icon);
        }


    }
}
