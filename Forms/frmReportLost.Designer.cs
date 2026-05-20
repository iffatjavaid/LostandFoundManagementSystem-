namespace IMFproject
{
    partial class frmReportLost
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
            this.ReporterLbl = new System.Windows.Forms.Label();
            this.ItemLbl = new System.Windows.Forms.Label();
            this.DesLbl = new System.Windows.Forms.Label();
            this.Datelbl = new System.Windows.Forms.Label();
            this.LocLbl = new System.Windows.Forms.Label();
            this.Submitbtn = new System.Windows.Forms.Button();
            this.Clearbtn = new System.Windows.Forms.Button();
            this.RptNmetxtBox = new System.Windows.Forms.TextBox();
            this.ItmNmetxtBox = new System.Windows.Forms.TextBox();
            this.DestxtBox = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Loctxtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ReporterLbl
            // 
            this.ReporterLbl.AutoSize = true;
            this.ReporterLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReporterLbl.Location = new System.Drawing.Point(81, 67);
            this.ReporterLbl.Name = "ReporterLbl";
            this.ReporterLbl.Size = new System.Drawing.Size(145, 22);
            this.ReporterLbl.TabIndex = 0;
            this.ReporterLbl.Text = "Reporter Name";
            // 
            // ItemLbl
            // 
            this.ItemLbl.AutoSize = true;
            this.ItemLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLbl.Location = new System.Drawing.Point(81, 115);
            this.ItemLbl.Name = "ItemLbl";
            this.ItemLbl.Size = new System.Drawing.Size(104, 22);
            this.ItemLbl.TabIndex = 1;
            this.ItemLbl.Text = "Item Name";
            // 
            // DesLbl
            // 
            this.DesLbl.AutoSize = true;
            this.DesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesLbl.Location = new System.Drawing.Point(81, 162);
            this.DesLbl.Name = "DesLbl";
            this.DesLbl.Size = new System.Drawing.Size(111, 22);
            this.DesLbl.TabIndex = 2;
            this.DesLbl.Text = "Description";
            this.DesLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelbl.Location = new System.Drawing.Point(81, 296);
            this.Datelbl.Name = "Datelbl";
            this.Datelbl.Size = new System.Drawing.Size(96, 22);
            this.Datelbl.TabIndex = 3;
            this.Datelbl.Text = "Lost Date";
            // 
            // LocLbl
            // 
            this.LocLbl.AutoSize = true;
            this.LocLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocLbl.Location = new System.Drawing.Point(81, 336);
            this.LocLbl.Name = "LocLbl";
            this.LocLbl.Size = new System.Drawing.Size(86, 22);
            this.LocLbl.TabIndex = 4;
            this.LocLbl.Text = "Location";
            // 
            // Submitbtn
            // 
            this.Submitbtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.Submitbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submitbtn.ForeColor = System.Drawing.Color.White;
            this.Submitbtn.Location = new System.Drawing.Point(186, 396);
            this.Submitbtn.Name = "Submitbtn";
            this.Submitbtn.Size = new System.Drawing.Size(93, 42);
            this.Submitbtn.TabIndex = 5;
            this.Submitbtn.Text = "Submit";
            this.Submitbtn.UseVisualStyleBackColor = false;
            this.Submitbtn.Click += new System.EventHandler(this.Submitbtn_Click);
            // 
            // Clearbtn
            // 
            this.Clearbtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.Clearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clearbtn.ForeColor = System.Drawing.Color.White;
            this.Clearbtn.Location = new System.Drawing.Point(425, 396);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(93, 42);
            this.Clearbtn.TabIndex = 6;
            this.Clearbtn.Text = "Clear";
            this.Clearbtn.UseVisualStyleBackColor = false;
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            // 
            // RptNmetxtBox
            // 
            this.RptNmetxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RptNmetxtBox.Location = new System.Drawing.Point(262, 64);
            this.RptNmetxtBox.Multiline = true;
            this.RptNmetxtBox.Name = "RptNmetxtBox";
            this.RptNmetxtBox.Size = new System.Drawing.Size(313, 35);
            this.RptNmetxtBox.TabIndex = 7;
            // 
            // ItmNmetxtBox
            // 
            this.ItmNmetxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItmNmetxtBox.Location = new System.Drawing.Point(262, 112);
            this.ItmNmetxtBox.Multiline = true;
            this.ItmNmetxtBox.Name = "ItmNmetxtBox";
            this.ItmNmetxtBox.Size = new System.Drawing.Size(313, 35);
            this.ItmNmetxtBox.TabIndex = 8;
            // 
            // DestxtBox
            // 
            this.DestxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestxtBox.Location = new System.Drawing.Point(262, 156);
            this.DestxtBox.Multiline = true;
            this.DestxtBox.Name = "DestxtBox";
            this.DestxtBox.Size = new System.Drawing.Size(313, 122);
            this.DestxtBox.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(262, 290);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(336, 28);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // Loctxtbox
            // 
            this.Loctxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loctxtbox.Location = new System.Drawing.Point(262, 333);
            this.Loctxtbox.Multiline = true;
            this.Loctxtbox.Name = "Loctxtbox";
            this.Loctxtbox.Size = new System.Drawing.Size(313, 39);
            this.Loctxtbox.TabIndex = 11;
            // 
            // frmReportLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Loctxtbox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.DestxtBox);
            this.Controls.Add(this.ItmNmetxtBox);
            this.Controls.Add(this.RptNmetxtBox);
            this.Controls.Add(this.Clearbtn);
            this.Controls.Add(this.Submitbtn);
            this.Controls.Add(this.LocLbl);
            this.Controls.Add(this.Datelbl);
            this.Controls.Add(this.DesLbl);
            this.Controls.Add(this.ItemLbl);
            this.Controls.Add(this.ReporterLbl);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Name = "frmReportLost";
            this.Text = "frmReportLost";
            this.Load += new System.EventHandler(this.frmReportLost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ReporterLbl;
        private System.Windows.Forms.Label ItemLbl;
        private System.Windows.Forms.Label DesLbl;
        private System.Windows.Forms.Label Datelbl;
        private System.Windows.Forms.Label LocLbl;
        private System.Windows.Forms.Button Submitbtn;
        private System.Windows.Forms.Button Clearbtn;
        private System.Windows.Forms.TextBox RptNmetxtBox;
        private System.Windows.Forms.TextBox ItmNmetxtBox;
        private System.Windows.Forms.TextBox DestxtBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox Loctxtbox;
    }
}