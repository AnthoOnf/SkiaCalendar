
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

__The constructor is_ `new CalendarSettings(minDate, maxDate, selectedDate, onDateSelected)`. `selectedDate` and `onDateSelected` are optional._

****Instantiate CalendarSettings with default settings****

```csharp

var minimumDate = DateTime.Today;
var maximumDate = DateTime.Today.Add(TimeSpan.FromDays(365));

CalendarSettings settings = new CalendarSettings(minimumDate, maximumDate);
```

****Customizing settings****

You can set your culture info, and the DateTime Format for the label of the month in the header.

```csharp
var minimumDate = DateTime.Today;
var maximumDate = DateTime.Today.Add(TimeSpan.FromDays(365));

CalendarSettings settings = new CalendarSettings(minimumDate, maximumDate)
{
    Culture = new CultureInfo("en"),
    DateMonthFormat = "MMMM yyyy"
};
```

****Create the view****

Now you have to create the view and add it in subview to your parent view. Call the CalendarView.Create with the calendarSettings.

```csharp
CalendarView calendarView = CalendarView.Create(settings);
this.CalendarContentView.AddSubview(calendarView);
calendarView.FillParent();
calendarView.AdjustCalendarView();
```
