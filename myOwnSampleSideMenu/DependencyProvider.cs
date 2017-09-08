
namespace myOwnSampleSideMenu
{
    /// <summary>
    /// Dependency provider
    /// </summary>
    public class DependencyProvider
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static DependencyProvider _instance;

        /// <summary>
        /// The side bar menu controller.
        /// </summary>
        private SideBarMenuController _sideBarMenuController;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static DependencyProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DependencyProvider();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Gets or sets the language selection controller.
        /// </summary>
        /// <value>
        /// The language selection controller.
        /// </value>
        public SideBarMenuController SideBarMenuController
        {
            get
            {
                if (_sideBarMenuController == null)
                {
                    _sideBarMenuController = new SideBarMenuController();
                }

                return _sideBarMenuController;
            }

            set
            {
                _sideBarMenuController = value;
            }
        }
    }
}