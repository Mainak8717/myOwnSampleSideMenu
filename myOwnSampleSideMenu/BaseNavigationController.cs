namespace myOwnSampleSideMenu
{
  
    using UIKit;

    /// <summary>
    /// Base navigation controller.
    /// </summary>
    public class BaseNavigationController : UINavigationController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNavigationController"/> class.
        /// </summary>
        public BaseNavigationController() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNavigationController"/> class.
        /// </summary>
        /// <param name="rootViewController">The root controller to add to the top of the UINavigationController's controller stack.</param>
        /// <remarks>
        /// The UINavigationController class manages a stack of view controllers. The view for the controller passed into this constructor, in the rootViewController parameter, will be presented initially when the UINavigationController is loaded.
        /// </remarks>
        public BaseNavigationController(UIViewController rootViewController) : base(rootViewController)
        {
        }

        /// <summary>
        /// Turns auto-rotation on or off.
        /// </summary>
        /// <returns>
        ///   <see langword="true" /> if the <see cref="T:UIKit.UIViewController" /> should auto-rotate, <see langword="false" /> otherwise.
        /// </returns>
        public override bool ShouldAutorotate()
        {
            return TopViewController.ShouldAutorotate();
        }

        /// <summary>
        /// The orientations supported by this <see cref="T:UIKit.UIViewController" />.
        /// </summary>
        /// <returns>
        /// A <see cref="T:UIKit.UIInterfaceOrientationMask" /> of the orientations supported by this <see cref="T:UIKit.UIViewController" />.
        /// </returns>
        /// <remarks>
        /// <para>When the user changes the device orientation, the system calls this method on the root view controller or the top most presented view controller that fills the window. If the view controller supports the new orientation, the window and view controller are rotated to the new orientation. This method is only called if the view controller's should Auto rotate method returns YES.</para>
        /// <para>Override this method to report all of the orientations that the view controller supports. The default values for a view controller's supported interface orientations is set to UIInterfaceOrientationMaskAll for the iPad idiom and UIInterfaceOrientationMaskAllButUpsideDown for the iPhone idiom.</para>
        /// <para>The system intersects the view controller's supported orientations with the app's supported orientations (as determined by the Info.PLIST file or the app delegate's application:supportedInterfaceOrientationsForWindow: method) to determine whether to rotate.
        /// </para>
        /// </remarks>
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return TopViewController.GetSupportedInterfaceOrientations();
        }

        /// <summary>
        /// The orientation that best displays the content of this <see cref="T:UIKit.UIViewController" />.
        /// </summary>
        /// <returns>
        /// The default value is the first entry in the “Supported Interface Orientations” list in <c>Info.plist</c> or, in an already running application, the current orientation of the status bar.
        /// </returns>
        /// <remarks>
        /// If an application supports more than one orientation, the system uses this orientation when first presenting the <see cref="T:UIKit.UIViewController" /> in full screen. The application developer should set this to the <see cref="T:UIKit.UIInterfaceOrientation" /> that best displays the content view.
        /// </remarks>
        public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
        {
            return TopViewController.PreferredInterfaceOrientationForPresentation();
        }
    }
}