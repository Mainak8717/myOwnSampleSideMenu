// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <myOwnSampleSideMenu/myOwnSampleSideMenu.h>
#import <UIKit/UIKit.h>


@interface SideBarMenuController : UIViewController {
	UILabel *_lblAppVersion;
	UILabel *_lblUserName;
	UILabel *_lblWelcome;
	UITableView *_tblMenu;
}

@property (nonatomic, retain) IBOutlet UILabel *lblAppVersion;

@property (nonatomic, retain) IBOutlet UILabel *lblUserName;

@property (nonatomic, retain) IBOutlet UILabel *lblWelcome;

@property (nonatomic, retain) IBOutlet UITableView *tblMenu;

@end
