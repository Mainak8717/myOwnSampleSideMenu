namespace myOwnSampleSideMenu
{
	/// <summary>
	/// Menu item.
	/// </summary>
	public class MenuItem
	{
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon.</value>
		//public string Icon { get; set; }

		public bool CurrentIndex { get; set; }

		public bool PreviousIndex { get; set; }
	}
}