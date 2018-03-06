# Using Python

We don't currently have a custom package available, however you can use our generic api at `https://relay.errlog.io/api/v1/log` to provide your own logging mechanism to your ErrLog.IO account.

For a look at the fields you can include with your API calls check out [Payload Variables](https://errlog.io/docs/payload-variables.aspx)

## Requirements

The example below uses the following packages:

*   [`json`](https://docs.python.org/2/library/json.html)
*   [`requests`](http://docs.python-requests.org/en/master/)
*   [`datetime`](https://docs.python.org/2/library/datetime.html)

## Usage

### Imports

The first part is pretty obvious. Make sure you have your imports ready to go.

```
import json
import requests
from datetime import datetime
```

### Craft your payload

You can control what data goes into the package. This is probably best done as part of a `try ... except ...` block where you can pull values out of an Exception object.

You can see a full list of available fields [here](https://errlog.io/docs/payload-variables).

```
obj = {
    'message' : 'This is a test message from Python!!',
    'apikey' : '[YOUR_API_KEY]',
    'applicationname' : 'Python Test Application',
    'type' : 'SnakeException',
    'errordate' : datetime.utcnow().strftime("%Y-%m-%d %H:%M:%S"),
    'filename' : 'ErrLogSamplePython.py',
    'method' : 'Constrictor`,
    'lineno' : 12,
    'colno' : 34
}
```

### Specify the end-point and headers

Here the url needs to be defined as below and the Content-Type needs to be `application/json` otherwise you will receive a `415 Unsupported Media Type` response.

```
url = 'https://relay.errlog.io/api/v1/log'

headers = {'Content-Type': 'application/json','Accept': 'application/json'}
```

### Perform the request

If everything has gone well you will receive an HTTP 200 response from the web request and your exception will have been logged to your ErrLog.IO [dashboard](https://errlog.io/dashboard)

```
r = requests.post(url, data = json.dumps(obj), headers = headers)

print "Response:", r
print "Text: " , r.text
```

## Complete Code Sample

```
import json
import requests
from datetime import datetime

obj = {
    'message' : 'This is a test message from Python!!',
    'apikey' : '[YOUR_API_KEY]',
    'applicationname' : 'Python Test Application',
    'type' : 'SnakeException',
    'errordate' : datetime.utcnow().strftime("%Y-%m-%d %H:%M:%S"),
    'filename' : 'ErrLogSamplePython.py',
    'method' : 'Constrictor`,
    'lineno' : 12,
    'colno' : 34
}

# If you want to see the data you're sending.
# print "Json Data: ", data

url = 'https://relay.errlog.io/api/v1/log'

headers = {'Content-Type': 'application/json','Accept': 'application/json'}
r = requests.post(url, data = json.dumps(obj), headers = headers)

print "Response:", r
print "Text: " , r.text
```

## See Also

*   [Python (official homepage)](https://www.python.org/)
*   [Python - Language Reference](https://docs.python.org/3/reference/index.html)