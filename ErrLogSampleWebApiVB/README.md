## Synopsis

This project will show you how to use ErrLog.IO in a ASP.NET WebApi (VB) project to catch and log exception errors.

## Installation

Simply install the ErrLog.IO nuget package from Visual Studio's Package Manager Console

```
PM> Install-Package ErrLog.IO
```

## Configuration

Add your `apikey` to the Application_Start method of Global.asax.vb

```
Protected Sub Application_Start()
    GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
    ErrLog.settings.apikey = "12345678-90AB-CDEF-1234-567890ABCDEF"
End Sub
```

Create an Application_Error method in Global.asax.vb that will catch all unhandled exceptions.

```
Protected Sub Application_Error(sender As Object, e As EventArgs)
    Dim ex As Exception = Server.GetLastError().GetBaseException()
    ErrLog.logger.log(ex)
End Sub
```

## Usage

The hard work has already been done. The application will now catch and log all unhandled exceptions. 

As it is an unhandled exception it will be the last thing the application does before it dies. It means 
you won't be able to retain information from the ErrLog environment, which will all be reinitialized the 
next time the application starts. 

One of the most useful features of ErrLog.IO is that you can manually handle exceptions and log them with try/catch blocks.

For example

```
...
Try
	potentiallyNullableVariable.value
Catch ex As Exception
	Errlog.logger.log(ex)
End Try
...
```

This will catch and log the exception, while continuing the execution as you normally would.

If desired you can also access the return value of the `log(ex)` method if you are experiencing issues.

```
...
Try
	potentiallyNullableVariable.value
Catch ex As Exception
	Dim response As String = Errlog.logger.log(ex)
	' Response will be "OK", "Missing API Key", etc.
End Try
...
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
