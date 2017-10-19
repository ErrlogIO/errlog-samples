## Synopsis

This project will show you how to use ErrLog.IO in a .Net Framework (F#) console project to catch and log exception errors.

## Installation

Simply install the ErrLog.IO nuget package from Visual Studio's Package Manager Console

```
PM> Install-Package ErrLog.IO
```

## Configuration

Add your `apikey` to the Main method of Program.fs file.

```
[<EntryPoint>]
let main argv = 
    ErrLog.settings.apikey <- @"12345678-90AB-CDEF-1234-567890ABCDEF";
```

You can apparently add a handler for the UnhandledException event but it's a bit complicated to do in F#. Your best options are to:
* Write code that doesn't fail :-/
* Handle the events with try/with blocks as in this example.

## Usage

As mentioned above, there's no easily usable way to catch application-wide unhandled exceptions as there is with C# and VB. The easiest
way to use ErrLog in F# is by 
First of all you need to add the below `ErrLog` lines to your Global.asax. This will configure ErrLog.IO

```   
try 
    // Do something that will generate an exception.
with
    | ex -> ErrLog.logger.log ex |> ignore
```

In the above example the try/with is similar to the C# try/catch statement

```
try {
    /// Do something that will generate an exception.
} catch (Exception ex) {
    ErrLog.logger.log(ex);
}
```

## API Reference

### Settings

#### Errlog.settings.apikey

<table>
    <tr>
        <td>Type</td>
        <td>string</td>
    </tr>
    <tr>
        <td>Required</td>
        <td>yes</td>
    </tr>
    <tr>
        <td>Default</td>
        <td>(empty string)</td>
    </tr>
</table>

This is your personal apikey used to associate your log messages with your ErrLog.IO account. If this is unset requests will receive a message "Missing API Key".

```
Errlog.settings.apikey = "12345678-90AB-CDEF-1234-567890ABCDEF";
```

#### ErrLog.settings.key_check

<table>
    <tr>
        <td>Type</td>
        <td>boolean (true/false)</td>
    </tr>
    <tr>
        <td>Required</td>
        <td>No</td>
    </tr>
    <tr>
        <td>Default</td>
        <td>true</td>
    </tr>
</table>
When set to true, any variable or object that includes the word 'password', 'pwd', or 'token' is excluded from logging. Default to true

```
ErrLog.settings.key_check = true
```

#### Errlog.settings.keys_to_exclude


<table>
    <tr>
        <td>Type</td>
        <td>string array</td>
    </tr>
    <tr>
        <td>Required</td>
        <td>false</td>
    </tr>
    <tr>
        <td>Default</td>
        <td>`{ "password", "pwd", "token", "key", "viewstate", "cookie", "aspnet", "validation" };` </td>
    </tr>
</table>
This is an array of strings that you specifically want to exclude from logging. It can be used to prevent sensitive data from being logged. 

```
Errlog.settings.keys_to_exclude = { "password", "pwd", "token", "key", "viewstate", "cookie", "aspnet", "validation" };
```

#### Errlog.settings.exclude_completely

<table>
    <tr>
        <td>Type</td>
        <td>boolean</td>
    </tr>
    <tr>
        <td>Required</td>
        <td>no</td>
    </tr>
    <tr>
        <td>Default</td>
        <td>true</td>
    </tr>
</table>

When disabled, excluded variables are obfuscated. When enabled, excluded variables are removed entirely.

```
Errlog.settings.exclude_completely = true;
```

#### Errlog.settings.applicationname


<table>
    <tr>
        <td>Type</td>
        <td>string</td>
    </tr>
    <tr>
        <td>Required</td>
        <td>false</td>
    </tr>
    <tr>
        <td>Default</td>
        <td>(automatically detected)</td>
    </tr>
</table>

Derived from the application itself, or can be overriden. This allows you to differentation separate applications in your dashboard.

```
Errlog.settings.applicationname = "My Application";
```

#### Errlog.settings.logging_region


<table>
    <tr>
        <td>Type</td>
        <td>integer</td>
    </tr>
    <tr>
        <td>Required</td>
        <td>false</td>
    </tr>
    <tr>
        <td>Default</td>
        <td>1 (Australia)</td>
    </tr>
</table>

Used to specify the geographic location. Defaults to Australia.

```
Errlog.settings.logging_region = 1;
```

Valid options are:

Region         | Region ID
---------------|----------
Australia      |  1
North America  |  2
Europe         |  3
UK             |  4
Asia           |  5

#### Errlog.settings.logging_verbose


<table>
    <tr>
        <td>Type</td>
        <td>boolean</td>
    </tr>
    <tr>
        <td>Required</td>
        <td>false</td>
    </tr>
    <tr>
        <td>Default</td>
        <td>false</td>
    </tr>
</table>

Enables or disables verbose logging. Set this to true to enable more detailed log messages. Defaults to false.

```
Errlog.settings.logging_verbose = false;
```

### See also

For full documentation see our webiste: https://errlog.io/docs/getting-started

## License

&copy; 2017 Kutamo Pty Ltd.
