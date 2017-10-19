using System;
using System.Web.Mvc;

namespace ErrLogSampleWebMVCCS.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index() {
            return View();
        }

        /// <summary>
        /// A test method to verify ErrLog is usable. It displays the current version of ErrLog.IO.
        /// </summary>
        public string ErrLogVersion() {
            return $"ErrLog version: {ErrLog.logger.version()}";
        }
        /// <summary>
        /// A test method to verify basic page functionality. It displays "Hello, World!" in a box on the page.
        /// </summary>
        public string HelloWorld() {
            return "Hello, World!";
        }
        /// <summary>
        /// This method creates an <see cref="System.InvalidCastException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start(object, EventArgs)"/> for configuration
        /// </summary>
        public ActionResult InvalidCastException() {
            object str = "This is not an int";

            int c = (int)str;
            return new EmptyResult();
        }
        /// <summary>
        /// This method creates an <see cref="System.NullReferenceException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start(object, EventArgs)"/> for configuration
        /// </summary>
        public ActionResult NullReferenceException() {
            string result = null;

            string upper = result.ToUpper();
            return new EmptyResult();
        }
        /// <summary>
        /// This method creates an <see cref="System.Data.SqlClient.SqlException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start(object, EventArgs)"/> for configuration
        /// </summary>
        public ActionResult SqlException() {
            using (var conn = new System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")) {
                conn.Open();
            }
            return new EmptyResult();
        }
        /// <summary>
        /// This method creates an <see cref="System.IndexOutOfRangeException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start(object, EventArgs)"/> for configuration
        /// </summary>
        public ActionResult IndexOutOfRangeException() {
            int[] array = { 1, 2, 3, 4, 5 };

            int num = array[6];
            return new EmptyResult();
        }
        /// <summary>
        /// This method creates an <see cref="System.ArgumentException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="MvcApplication.Application_Start(object, EventArgs)"/> for configuration
        /// </summary>
        public ActionResult ArgumentException() {
            using (var conn = new System.Data.SqlClient.SqlConnection("This is not a real connection string")) {
                conn.Open();
            }
            return new EmptyResult();
        }
    }
}