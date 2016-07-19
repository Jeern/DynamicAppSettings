DynamicAppSettings provides an easy way to access the web.config or app.config AppSettings

## Usage

To get an AppSetting called George that is a string:

string george = AppSettings.ValueOf(c => c.George);

To get an AppSetting called TimeOfDay that is a TimeSpan:

var timeSpan = AppSettings<TimeSpan>.ValueOf(c => c.TimeOfDay);

To get an AppSetting called Allowed that is a bool:

var allowed = AppSettings<bool>.ValueOf(c => c.Allowed);

## Types

The following types are supported for now:

* string
* bool
* int
* double
* float
* decimal
* DateTime
* TimeSpan