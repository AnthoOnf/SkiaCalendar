
# SkiaCalendar

A calendar for iOS



Minimum requirement:

![iOSVersion](https://img.shields.io/badge/iOS-11-green.svg)



## About

If you need a customizable calendar, you've come to the right place. 
Apple did'nt make a calendar component, and I know it not pretty simple to make it. 

So I share with you this calendar, all PR and suggestions are welcome.

You can customize the color of the calendar, and some rules.
Like if you want to disable some date, enable the week end, set your start date and your end date etc...



## Usage

Using the SkiaCalendar with a default configuration is pretty simple.

First you have to instantiate CalendarSettings with a minimum date and maximum date.

__The constructor is_ `new CalendarSettings(minDate, maxDate, selectedDate, onDateSelected)`. selectedDate and onDateSelected are optional._

****Instantiate CalendarSettings with default settings****

```csharp

var minimumDate = DateTime.Today;
var maximumDate = DateTime.Today.Add(TimeSpan.FromDays(365));

CalendarSettings settings = new CalendarSettings(minimumDate, maximumDate);
```

****Customizing settings****

```csharp
var controller = UIStoryboard.FromName("Main", null).InstantiateViewController("ChildViewController");

SheetSize[] sheetSizes = { SheetSize.Fixed(300f), SheetSize.FullScreen };

var bottomSheetController = SheetViewController(controller)
bottomSheetController.DismissOnBackgroundTap = false;
bottomSheetController.RoundTopCorner = false;

this.PresentModalViewController(bottomSheetController, false)
```

## Settings

```csharp
// The color of the overlay above the sheet.
public UIColor OverlayColor => UIColor.FromRGBA(0, 0, 0, (int)70  *  255);
```

```csharp
// Sets the heights, the sheets will try to stick to. It will not resize the current size, but will affect all future resizing of the sheet.
public void SetSizes(SheetSize[]  sizes, bool animated = true)
```

```csharp
/// This should be called by any child view controller that expects the sheet to use be able to expand/collapse when the scroll view is at the top.
public void HandleScrollView(UIScrollView scrollView)
``` 

There is an extension on UIViewController that gives you a `BottomSheetViewController` that attempts to find the current SheetViewController so you can attach like this:

```csharp
public override void ViewDidLoad() {

base.ViewDidLoad()
this.bottomSheetViewController?.HandleScrollView(this.scrollView) // or tableView/collectionView/etc

}
```
