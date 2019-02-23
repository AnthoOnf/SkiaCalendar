// WARNING
// This file has been generated automatically by Visual Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>


@interface CalendarView : UIView {
	UIView *_CalendarGridWrapperView;
	NSLayoutConstraint *_CalendarGridWrapperViewHeight;
	UILabel *_MonthName;
	UIButton *_NextButton;
	UIButton *_PrevButton;
}

@property (nonatomic, retain) IBOutlet UIView *CalendarGridWrapperView;

@property (nonatomic, retain) IBOutlet NSLayoutConstraint *CalendarGridWrapperViewHeight;

@property (nonatomic, retain) IBOutlet UILabel *MonthName;

@property (nonatomic, retain) IBOutlet UIButton *NextButton;

@property (nonatomic, retain) IBOutlet UIButton *PrevButton;

@end
