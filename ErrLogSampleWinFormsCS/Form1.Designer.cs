namespace ErrLogSampleWinFormsCS {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHelloWorld = new System.Windows.Forms.Button();
            this.tbMessages = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnErrLogVersion = new System.Windows.Forms.Button();
            this.btnInvalidCastException = new System.Windows.Forms.Button();
            this.btnArrayOutOfBoundsException = new System.Windows.Forms.Button();
            this.btnArgumentException = new System.Windows.Forms.Button();
            this.btnNullReferenceException = new System.Windows.Forms.Button();
            this.btnSqlException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(614, 72);
            this.label3.TabIndex = 0;
            this.label3.Text = "ErrLog.IO Test WinForms";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1161, 35);
            this.label4.TabIndex = 1;
            this.label4.Text = "This project simulates various exceptions and how to handle them with errlog.io";
            // 
            // btnHelloWorld
            // 
            this.btnHelloWorld.AutoSize = true;
            this.btnHelloWorld.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelloWorld.Location = new System.Drawing.Point(12, 115);
            this.btnHelloWorld.Name = "btnHelloWorld";
            this.btnHelloWorld.Size = new System.Drawing.Size(150, 40);
            this.btnHelloWorld.TabIndex = 2;
            this.btnHelloWorld.Text = "Hello, World!";
            this.btnHelloWorld.UseVisualStyleBackColor = true;
            this.btnHelloWorld.Click += new System.EventHandler(this.btnHelloWorld_Click);
            // 
            // tbMessages
            // 
            this.tbMessages.Enabled = false;
            this.tbMessages.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessages.Location = new System.Drawing.Point(12, 236);
            this.tbMessages.Multiline = true;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.Size = new System.Drawing.Size(1156, 122);
            this.tbMessages.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Messages";
            // 
            // btnErrLogVersion
            // 
            this.btnErrLogVersion.AutoSize = true;
            this.btnErrLogVersion.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErrLogVersion.Location = new System.Drawing.Point(168, 115);
            this.btnErrLogVersion.Name = "btnErrLogVersion";
            this.btnErrLogVersion.Size = new System.Drawing.Size(164, 40);
            this.btnErrLogVersion.TabIndex = 2;
            this.btnErrLogVersion.Text = "ErrLog Version";
            this.btnErrLogVersion.UseVisualStyleBackColor = true;
            this.btnErrLogVersion.Click += new System.EventHandler(this.btnErrLogVersion_Click);
            // 
            // btnInvalidCastException
            // 
            this.btnInvalidCastException.AutoSize = true;
            this.btnInvalidCastException.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvalidCastException.Location = new System.Drawing.Point(12, 161);
            this.btnInvalidCastException.Name = "btnInvalidCastException";
            this.btnInvalidCastException.Size = new System.Drawing.Size(220, 40);
            this.btnInvalidCastException.TabIndex = 2;
            this.btnInvalidCastException.Text = "InvalidCastException";
            this.btnInvalidCastException.UseVisualStyleBackColor = true;
            this.btnInvalidCastException.Click += new System.EventHandler(this.btnInvalidCastException_Click);
            // 
            // btnArrayOutOfBoundsException
            // 
            this.btnArrayOutOfBoundsException.AutoSize = true;
            this.btnArrayOutOfBoundsException.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrayOutOfBoundsException.Location = new System.Drawing.Point(238, 161);
            this.btnArrayOutOfBoundsException.Name = "btnArrayOutOfBoundsException";
            this.btnArrayOutOfBoundsException.Size = new System.Drawing.Size(300, 40);
            this.btnArrayOutOfBoundsException.TabIndex = 2;
            this.btnArrayOutOfBoundsException.Text = "ArrayOutOfBoundsException";
            this.btnArrayOutOfBoundsException.UseVisualStyleBackColor = true;
            this.btnArrayOutOfBoundsException.Click += new System.EventHandler(this.btnArrayOutOfBoundsException_Click);
            // 
            // btnArgumentException
            // 
            this.btnArgumentException.AutoSize = true;
            this.btnArgumentException.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArgumentException.Location = new System.Drawing.Point(544, 161);
            this.btnArgumentException.Name = "btnArgumentException";
            this.btnArgumentException.Size = new System.Drawing.Size(213, 40);
            this.btnArgumentException.TabIndex = 2;
            this.btnArgumentException.Text = "ArgumentException";
            this.btnArgumentException.UseVisualStyleBackColor = true;
            this.btnArgumentException.Click += new System.EventHandler(this.btnArgumentException_Click);
            // 
            // btnNullReferenceException
            // 
            this.btnNullReferenceException.AutoSize = true;
            this.btnNullReferenceException.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNullReferenceException.Location = new System.Drawing.Point(763, 161);
            this.btnNullReferenceException.Name = "btnNullReferenceException";
            this.btnNullReferenceException.Size = new System.Drawing.Size(251, 40);
            this.btnNullReferenceException.TabIndex = 2;
            this.btnNullReferenceException.Text = "NullReferenceException";
            this.btnNullReferenceException.UseVisualStyleBackColor = true;
            this.btnNullReferenceException.Click += new System.EventHandler(this.btnNullReferenceException_Click);
            // 
            // btnSqlException
            // 
            this.btnSqlException.AutoSize = true;
            this.btnSqlException.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSqlException.Location = new System.Drawing.Point(1020, 161);
            this.btnSqlException.Name = "btnSqlException";
            this.btnSqlException.Size = new System.Drawing.Size(155, 40);
            this.btnSqlException.TabIndex = 2;
            this.btnSqlException.Text = "SqlException";
            this.btnSqlException.UseVisualStyleBackColor = true;
            this.btnSqlException.Click += new System.EventHandler(this.btnSqlException_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1180, 370);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMessages);
            this.Controls.Add(this.btnErrLogVersion);
            this.Controls.Add(this.btnSqlException);
            this.Controls.Add(this.btnNullReferenceException);
            this.Controls.Add(this.btnArgumentException);
            this.Controls.Add(this.btnArrayOutOfBoundsException);
            this.Controls.Add(this.btnInvalidCastException);
            this.Controls.Add(this.btnHelloWorld);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "ErrLog.IO Test WinForms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

         private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHelloWorld;
        private System.Windows.Forms.TextBox tbMessages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnErrLogVersion;
        private System.Windows.Forms.Button btnInvalidCastException;
        private System.Windows.Forms.Button btnArrayOutOfBoundsException;
        private System.Windows.Forms.Button btnArgumentException;
        private System.Windows.Forms.Button btnNullReferenceException;
        private System.Windows.Forms.Button btnSqlException;
    }
}

