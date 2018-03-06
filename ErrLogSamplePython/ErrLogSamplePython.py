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
    'method' : 'Constrictor',
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
