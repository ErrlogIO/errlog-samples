using System;

namespace ErrLogSampleConsoleCS {
    class Program {
        private static void PrintHelp() {
            Console.WriteLine(
@"1) Print ""Hello, World!""
2) Print Current ErrLog version
3) Throw an InvalidCastException
4) Throw an IndexOutOfBoundsException
5) Throw an ArgumentException
6) Throw a NullReferenceException
7) Throw a SQLException
or
q) Quit");
        }
        static void Main(string[] args) {
            ErrLog.settings.apikey = "[your api key]";

            PrintHelp();

            while (true) {
                try {
                    Console.Write("Please select an option: ");
                    char key = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (key) {
                        case 'h':
                        case 'H':
                            PrintHelp();
                            break;
                        case 'q':
                        case 'Q':
                            Environment.Exit(0);
                            break;
                        case '1':
                            // Hello, World!
                            Console.WriteLine("Hello, World!");
                            break;
                        case '2':
                            // ErrLog version
                            Console.WriteLine($"ErrLog.IO version: {ErrLog.logger.version()}");
                            break;
                        case '3':
                            // InvalidCastException
                            object str = "This is not an int";

                            int c = (int)str;

                            break;
                        case '4':
                            // IndexOutOfBoundsException
                            int[] array = { 1, 2, 3, 4, 5 };

                            int num = array[6];
                            break;
                        case '5':
                            // ArgumentException
                            using (var conn = new System.Data.SqlClient.SqlConnection("This is not a real connection string")) {
                                conn.Open();
                            }
                            break;
                        case '6':
                            // NullReferenceException
                            string result = null;

                            string upper = result.ToUpper();
                            break;
                        case '7':
                            // SQLException
                            using (var conn = new System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")) {
                                conn.Open();
                            }
                            break;
                        default:
                            PrintHelp();
                            break;
                    }
                } catch (Exception ex) {
                    Console.WriteLine($"Sending exception to errlog.io: {ex.Message}");

                    DateTime startTime = DateTime.Now;
                    Console.WriteLine($"ErrLog.IO Response: {ErrLog.logger.log(ex)}");
                    DateTime endTime = DateTime.Now;

                    TimeSpan timespan = endTime - startTime;

                    Console.WriteLine($"Submission took {timespan.TotalSeconds} seconds");
                }

            }
        }
    }
}