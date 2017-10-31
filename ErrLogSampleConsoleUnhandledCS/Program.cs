using System;

namespace ErrLogSampleConsoleUnhandled {
    class Program {
        static void Main(string[] args) {
            ErrLog.settings.apikey = "[your api key]";

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
            ErrLog.logger.log(ex);
        }
    }
}
