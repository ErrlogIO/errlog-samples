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
    "lineno": "abc",
    "colno": 34
	}`)
    req, err := http.NewRequest("POST", url, bytes.NewBuffer(jsonStr))
    //req.Header.Set("X-Custom-Header", "myvalue")
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
