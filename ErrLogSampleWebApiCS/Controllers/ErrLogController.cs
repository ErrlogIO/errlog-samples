using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ErrLogSampleWebApiCS.Controllers {
    public class ErrLogController : ApiController {
        [HttpGet]
        [Route("api/ErrLog/CheckRoutes")]
        public void CheckRoutes() {
            //  Check Routes
            string[] routes = {
                   "api/ErrLog/HelloWorld",
                   "api/ErrLog/ErrLogVersion",
                   "api/ErrLog/InvalidCastException",
                   "api/ErrLog/NullReferenceException",
                   "api/ErrLog/SqlException",
                   "api/ErrLog/IndexOutOfRangeException",
                   "api/ErrLog/ArgumentException"
               };

            foreach (var route in routes) {
                using (WebClient client = new WebClient()) {
                    try {
                        var url = HttpContext.Current.Request.Url;
                        string fullRoute = $"{url.Scheme}://{url.Host}:{url.Port}/{route}";

                        client.DownloadString(fullRoute);
                    } catch (Exception ex) {
                        ErrLog.logger.log(ex);
                    }
                }
            }
        }

        [HttpGet]
        [Route("api/ErrLog/HelloWorld")]
        public HttpResponseMessage HelloWorld() {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Hello, World!");

            return response;
        }
        /// <summary>
        /// A test method to verify ErrLog is usable. It displays the current version of ErrLog.IO.
        /// </summary>
        [HttpGet]
        [Route("api/ErrLog/ErrLogVersion")]
        public HttpResponseMessage ErrLogVersion() {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ErrLog.logger.version());

            return response;

        }
        /// <summary>
        /// This method creates an <see cref="System.InvalidCastException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        /// </summary>
        [HttpGet]
        [Route("api/ErrLog/InvalidCastException")]
        public IHttpActionResult InvalidCastException() {
            object str = "This is not an int";

            int c = (int)str;
            return Ok();
        }
        /// <summary>
        /// This method creates an <see cref="System.NullReferenceException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        /// </summary>
        [HttpGet]
        [Route("api/ErrLog/NullReferenceException")]
        public IHttpActionResult NullReferenceException() {
            string result = null;

            string upper = result.ToUpper();
            return Ok();
        }
        /// <summary>
        /// This method creates an <see cref="System.Data.SqlClient.SqlException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        /// </summary>
        [HttpGet]
        [Route("api/ErrLog/SqlException")]
        public IHttpActionResult SqlException() {
            using (var conn = new System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")) {
                conn.Open();
            }
            return Ok();
        }
        /// <summary>
        /// This method creates an <see cref="System.IndexOutOfRangeException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        /// </summary>
        [HttpGet]
        [Route("api/ErrLog/IndexOutOfRangeException")]
        public IHttpActionResult IndexOutOfRangeException() {
            int[] array = { 1, 2, 3, 4, 5 };

            int num = array[6];
            return Ok();
        }
        /// <summary>
        /// This method creates an <see cref="System.ArgumentException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="WebApiApplication.Application_Start"/> for configuration
        /// </summary>
        [HttpGet]
        [Route("api/ErrLog/ArgumentException")]
        public IHttpActionResult ArgumentException() {
            using (var conn = new System.Data.SqlClient.SqlConnection("This is not a real connection string")) {
                conn.Open();
            }
            return Ok();
        }
    }
}
