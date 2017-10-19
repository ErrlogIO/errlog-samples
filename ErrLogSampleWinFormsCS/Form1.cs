using System;
using System.Windows.Forms;

namespace ErrLogSampleWinFormsCS {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        /// <summary>
        /// A test method to verify ErrLog is usable. It displays the current version of ErrLog.IO.
        /// </summary>
        protected void btnErrLogVersion_Click(object sender, EventArgs e) {
            tbMessages.Text = $"ErrLog version: {ErrLog.logger.version()}";
        }
        /// <summary>
        /// A test method to verify basic page functionality. It displays "Hello, World!" in a box on the page.
        /// </summary>
        protected void btnHelloWorld_Click(object sender, EventArgs e) {
            tbMessages.Text = @"Hello, World!";
        }
        /// <summary>
        /// This method creates an <see cref="System.InvalidCastException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="Program.Main"/> for configuration
        /// </summary>
        protected void btnInvalidCastException_Click(object sender, EventArgs e) {
            object str = "This is not an int";

            int c = (int)str;
        }
        /// <summary>
        /// This method creates an <see cref="System.NullReferenceException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="Program.Main"/> for configuration
        /// </summary>
        protected void btnNullReferenceException_Click(object sender, EventArgs e) {
            string result = null;

            string upper = result.ToUpper();
        }
        /// <summary>
        /// This method creates an <see cref="System.Data.SqlClient.SqlException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="Program.Main"/> for configuration
        /// </summary>
        protected void btnSqlException_Click(object sender, EventArgs e) {
            using (var conn = new System.Data.SqlClient.SqlConnection("Server=server.invalid;Database=doesnt_exist;Trusted_Connection=True;Connection Timeout=1")) {
                conn.Open();
            }
        }

        /// <summary>
        /// This method creates an <see cref="System.IndexOutOfRangeException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="Program.Main"/> for configuration
        /// </summary>
        protected void btnArrayOutOfBoundsException_Click(object sender, EventArgs e) {
            int[] array = { 1, 2, 3, 4, 5 };

            int num = array[6];
        }
        /// <summary>
        /// This method creates an <see cref="System.ArgumentException"/> which will get logged by the <see cref="ErrLog.logger.log"/> method. See also <see cref="Program.Main"/> for configuration
        /// </summary>
        protected void btnArgumentException_Click(object sender, EventArgs e) {
            using (var conn = new System.Data.SqlClient.SqlConnection("This is not a real connection string")) {
                conn.Open();
            }
        }
    }
}
