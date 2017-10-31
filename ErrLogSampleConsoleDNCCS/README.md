## Synopsis

This project shows how to use the ErrLog.IO webhook API to log errors from projects that don't 
support the Nuget package.

## Installation

No installation is required as you're not relying on external packages. You just need to 
reference standard .Net Framework classes.

In the example below we use Newtonsoft.Json to serialize the object into a Json string, 
however this isn't required and you can use your own (or alternative) method for 
serializing to JSON.

## Configuration

You'll need to specify your API key in your handler code, but that's about it. Depending on 
how you want to handle the errors, you can either create a separate function to handle 
exceptions which you can reference in try/catch statements or set an application-wide 
UnhandledException handler as shown below.

```
static void Main() {
    AppDomain.CurrentDomain.UnhandledException += MyHandler;
}
```

Create the `MyHandler` method referenced above to catch any unhandled exceptions.

```
static void MyHandler(object sender, UnhandledExceptionEventArgs args) {
    Exception ex = args.ExceptionObject as Exception;
   
    // Exception handling code, similar to below.
}
```

## Usage

The example below manually forces a NullReference exception. You'll have to create your own Json message
```
try {
    Console.WriteLine("We're going to throw an exception that will be handled by a try/catch statement.");

    string result = null;
    string upper = result.ToUpper();
} catch (Exception ex) {
    StackTrace st = new StackTrace(ex, true);

    var obj = new {
        message = "This is a test message",
        apikey = "[Your API key]",
        applicationname = "Test Application",
        type = ex.GetType().ToString(),
        environment = Environment.GetEnvironmentVariables(),
        errordate = DateTime.Now,
        trace = ex.StackTrace,
        filename = st.GetFrame(0).GetFileName(),
        method = st.GetFrame(0).GetMethod().Name,
        lineno = st.GetFrame(0).GetFileLineNumber().ToString(),
        colno = st.GetFrame(0).GetFileColumnNumber().ToString(),
    };

    StringContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

    HttpClient client = new HttpClient();

    // You can capture the response if you are expecting a result. 
    // Most of the time this will be "OK" but could also be "Missing API Key", etc.
    HttpContent response = client.PostAsync(apiUrl, content).Result.Content;
    string result = response.ReadAsStringAsync().Result;
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
Errlog.settings.apikey = "[your API key]";
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

For full documentation see our webiste: https://errlog.io/docs/getting-started. You can also check out the full [webhook API](https://errlog.io/docs/webhook-api) documentation.

## License

&copy; 2017 Kutamo Pty Ltd.
