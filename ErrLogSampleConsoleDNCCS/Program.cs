using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ErrLogSampleConsoleDNCCS {
    class Program {
        //    private static string apiUrl => "http://localhost:52967/api/v1/log";
        private static string apiUrl => "https://relay.errlog.io/api/v1/log";

        static void Main(string[] args) {
            try {
                Console.WriteLine("We're going to throw an exception that will be handled by a try/catch statement.");

                string result = null;
                string upper = result.ToUpper();
            } catch (Exception ex) {
                StackTrace st = new StackTrace(ex, true);

                var obj = new {
                    message = "This is a test message",
                    apikey = "12345678-90AB-CDEF-1234-567890ABCDEF",
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
        }

    }
}
