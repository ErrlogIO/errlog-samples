using System;
using System.Windows.Forms;

namespace ErrLogSampleWinFormsCS {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            ErrLog.settings.apikey = "[your API key]";
            AppDomain.CurrentDomain.UnhandledException += MyHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args) {
            Exception ex = args.ExceptionObject as Exception;
            ErrLog.logger.log(ex);
        }
    }
}
