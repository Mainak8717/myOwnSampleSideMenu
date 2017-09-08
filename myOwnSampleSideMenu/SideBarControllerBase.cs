using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace myOwnSampleSideMenu
{
    /// <summary>
    /// Position enum.
    /// </summary>
    public enum PositionEnum
    {
        /// <summary>
        /// The side bar from left.
        /// </summary>
        eSideBarFromLeft,

        /// <summary>
        /// The side bar from right.
        /// </summary>
        eSideBarFromRight,
    };

    /// <summary>
    /// Side bar controller base.
    /// </summary>
    public class SideBarControllerBase : UIViewController
    {
        #region Private Members

        private UIView _surfaceView;
        private UITapGestureRecognizer _tapGesture;
        private UISwipeGestureRecognizer _swipeGesture;
        private bool _isShowing;

        private void CleanupSurfaceView()
        {

            _surfaceView.RemoveGestureRecognizer(_tapGesture);
            _surfaceView.RemoveGestureRecognizer(_swipeGesture);
            _surfaceView.RemoveFromSuperview();
            _surfaceView.Dispose();

        }

        private CGRect GetSideBarFrame()
        {

            CGRect frame = View.Frame;
            CGRect surfaceFrame = _surfaceView.Frame;

            switch (ShowFrom)
            {

                case PositionEnum.eSideBarFromLeft:
                    {
                        frame.X = surfaceFrame.X - frame.Width;
                    }

                    break;

                case PositionEnum.eSideBarFromRight:
                    {
                        frame.X = surfaceFrame.Width;
                    }

                    break;
            }

            return frame;

        }

        private void PrepareSideBar()
        {

            CGRect surfaceFrame = _surfaceView.Frame;
            CGRect frame = GetSideBarFrame();

            frame.Y = surfaceFrame.Y;
            View.Frame = frame;

        }

        private void PrepareSurfaceView()
        {

            _surfaceView = new UIView(ParentView.Bounds);
            ParentView.Superview.AddSubview(_surfaceView);
            ParentView.BringSubviewToFront(_surfaceView);
            _surfaceView.UserInteractionEnabled = true;

            _tapGesture = new UITapGestureRecognizer((UITapGestureRecognizer obj) =>
            {

                HideSideBar();

            });

            _tapGesture.ShouldReceiveTouch += (UIGestureRecognizer recognizer, UITouch touch) =>
            {

                bool isSurfaceView = (touch.View != _surfaceView);
                return !isSurfaceView;

            };

            _swipeGesture = new UISwipeGestureRecognizer((UISwipeGestureRecognizer obj) =>
            {

                HideSideBar();

            });

            _swipeGesture.Direction = UISwipeGestureRecognizerDirection.Left;
            _swipeGesture.ShouldReceiveTouch += (UIGestureRecognizer recognizer, UITouch touch) =>

            {

                return true;

            };

            _surfaceView.AddGestureRecognizer(_tapGesture);
            _surfaceView.AddGestureRecognizer(_swipeGesture);

        }

        #endregion Private Members

        #region Protected Members

        protected void ShowSideBar()
        {

            CGRect frame = View.Frame;
            UIView.Animate(0.3, () =>
            {

                if (ShowFrom == PositionEnum.eSideBarFromLeft)
                    frame.X += (nfloat)(Math.Abs(frame.X) * ShowPercentage);
                else if (ShowFrom == PositionEnum.eSideBarFromRight)
                    frame.X = _surfaceView.Frame.Width - frame.Width;


                View.Frame = frame;

                UIView.Animate(0.1, () =>
                {

                    ParentView.Alpha = (nfloat)ShowAlpha;
                    _isShowing = true;

                });

            });
        }

        protected void HideSideBar()
        {

            CGRect frame = View.Frame;
            UIView.Animate(0.2, () =>
            {

                PrepareSideBar();

                UIView.Animate(0.1, () =>
                {

                    ParentView.Alpha = (nfloat)1.0;

                }, () =>
                  {

                      CleanupSurfaceView();
                      View.RemoveFromSuperview();
                      _isShowing = false;

                  });
            });

        }

        protected virtual void ShowSideBarWithFrame(CGRect frame)
        {

            if (ParentView.Superview == null)
                return;

            View.Frame = frame;
            PrepareSurfaceView();
            PrepareSideBar();
            _surfaceView.AddSubview(View);
            ShowSideBar();

        }

        #endregion Protected Members

        #region Public Members

        public UIView ParentView { get; set; }
        public PositionEnum ShowFrom { get; set; }
        public double ShowPercentage { get; set; }
        public double ShowAlpha { get; set; }

        public SideBarControllerBase(IntPtr handle) : base(handle)
        {
        }

        public SideBarControllerBase(string nibName, NSBundle bundle)
                    : base(nibName, bundle)
        {

            _isShowing = false;

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public void ToggleSideBarWithFrame(CGRect frame, UIView parentView)
        {

            ParentView = parentView;
            if (_isShowing == true)
                HideSideBar();
            else
                ShowSideBarWithFrame(frame);

        }

        #endregion Public Members

    }

}

