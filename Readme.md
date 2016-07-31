FappSettings provides an easy way to access the web.config or app.config AppSettings

## Install

Use Nuget and the package manager console in Visual Studio. Type:

Install-Package FappSettings

## Usage

To get an AppSetting called George that is a string:

``` csharp
string george = AppSettings.ValueOf(a => a.George);
```

To get an AppSetting called TimeOfDay that is a TimeSpan:

``` csharp
var timeSpan = AppSettings<TimeSpan>.ValueOf(a => a.TimeOfDay);
```

To get an AppSetting called Allowed that is a bool:

``` csharp
var allowed = AppSettings<bool>.ValueOf(a => a.Allowed);
```

For all of them there is TryValueOf version following the classic Try pattern in Dotnet.

Last but not least ConnectionStrings can be accessed via 

``` csharp
string conn = ConnectionStrings.ValueOf(c => c.ConnName);
```

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