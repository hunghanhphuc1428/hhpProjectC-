namespace Pro_Stu.ControllersAndViews
{
    partial class CheckAttendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bsListCheckAttendance = new System.Windows.Forms.BindingSource(this.components);
            this.btnInsert = new MetroFramework.Controls.MetroButton();
            this.GridViewAttendance = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bsListCheckAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(245, 354);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseSelectable = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // GridViewAttendance
            // 
            this.GridViewAttendance.AllowUserToAddRows = false;
            this.GridViewAttendance.AllowUserToDeleteRows = false;
            this.GridViewAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewAttendance.Dock = System.Windows.Forms.DockStyle.Top;
            this.GridViewAttendance.Location = new System.Drawing.Point(0, 0);
            this.GridViewAttendance.Name = "GridViewAttendance";
            this.GridViewAttendance.Size = new System.Drawing.Size(800, 323);
            this.GridViewAttendance.TabIndex = 2;
            // 
            // CheckAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridViewAttendance);
            this.Controls.Add(this.btnInsert);
            this.Name = "CheckAttendance";
            this.Text = "CheckAttendance";
            ((System.ComponentModel.ISupportInitialize)(this.bsListCheckAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAttendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bsListCheckAttendance;
        private MetroFramework.Controls.MetroButton btnInsert;
        private System.Windows.Forms.DataGridView GridViewAttendance;
    }
}