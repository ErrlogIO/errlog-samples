# Using Go

We don't currently have a custom package available, however you can use our generic api at `https://relay.errlog.io/api/v1/log` to provide your own logging mechanism to your ErrLog.IO account.

For a look at the fields you can include with your API calls check out [Payload Variables](https://errlog.io/docs/payload-variables.aspx)

## Requirements

The example below uses the following packages:

*   [`net/http`](https://golang.org/pkg/net/http/)
*   [`fmt`](https://golang.org/pkg/fmt/)
*   [`bytes`](https://golang.org/pkg/bytes/)
*   [`io/ioutil`](https://golang.org/pkg/io/ioutil/)

## Usage

### Imports

The first part is pretty obvious. Make sure you have your imports ready to go.

```
import ("net/http"
    "fmt"
    "bytes"
    "io/ioutil"
);
```
### Craft your payload

You can control what data goes into the package. This is probably best done as part of a `try ... except ...` block where you can pull values out of an Exception object.

You can see a full list of available fields [here](https://errlog.io/docs/payload-variables).

```
 var jsonStr = []byte(`
{
    "message": "This is a test message from Go",
    "apikey": "[YOUR_API_KEY]",
    "applicationname": "Sample Go Application",
    "type": "RandomlyGeneratedException",
    "filename": "ErrLogSampleGo.go",
    "method": "main()",
    "lineno": 12,
    "colno": 34
}`)
```

### Specify the end-point and headers

Here the url needs to be defined as below and the Content-Type needs to be `application/json` otherwise you will receive a `415 Unsupported Media Type` response.

```
req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonStr))
req.Header.Set("Content-Type", "application/json")
```

### Perform the request

If everything has gone well you will receive an HTTP 200 response from the web request and your exception will have been logged to your ErrLog.IO [dashboard](https://errlog.io/dashboard)

```
client := &http.Client{}
resp, err := client.Do(req)
if err != nil {
    panic(err)
}
defer resp.Body.Close()

fmt.Println("response Status:", resp.Status)
fmt.Println("response Body:", string(body))
```

## Complete Code Sample

```
package main;
import ("net/http"
"fmt"
"bytes"
"io/ioutil"
);

func main() {
 url := "https://relay.errlog.io/api/v1/log"
fmt.Println("URL:>", url)

var jsonStr = []byte(`
{
"message": "This is a test message",
"apikey": "[YOUR_API_KEY]",
"applicationname": "Test Application",
"type": "RandomlyGeneratedException",
"filename": "ErrLogSampleGo.go",
"method": "main()",
"lineno": 12,
"colno": 34
}`)

req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonStr))
req.Header.Set("Content-Type", "application/json")

client := &http.Client{}
resp, err := client.Do(req)
if err != nil {
panic(err)
}
defer resp.Body.Close()

fmt.Println("response Status:", resp.Status)
fmt.Println("response Headers:", resp.Header)
body, _ := ioutil.ReadAll(resp.Body)
fmt.Println("response Body:", string(body))
}
```

## See Also

*   [Go Language (homepage)](https://golang.org/)
*   [Go - Language Specification](https://golang.org/ref/spec)
*   [Go - Package Reference](https://golang.org/pkg/)
