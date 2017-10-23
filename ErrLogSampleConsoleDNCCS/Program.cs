using System;
using System.Net.Http;

namespace ErrLogSampleConsoleDNCCS
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionCatcher;

            Console.WriteLine("We've configured ErrLog.IO and set the UnhandledExceptionHandler.");
            Console.WriteLine("Press any key to throw an unhandled exception.");
            Console.ReadKey();

            // Throw a classic NullReferenceException
            string result = null;
            string upper = result.ToUpper();
        }

        static void UnhandledExceptionCatcher(object sender, UnhandledExceptionEventArgs e) {
            var ex = e.ExceptionObject as Exception;

            StringContent content = new StringContent(@"{ 
""apikey"": "",
"""": """",
"""": """",
"""": """",
"""": """",
");

            HttpClient client = new HttpClient();
            StringContent response = client.PostAsync("http://localhost:52967/api/v1/log", content).Result.Content;

        }
    }
}
