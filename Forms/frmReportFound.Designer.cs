namespace IMFproject
{
    partial class frmReportFound
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
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.dtpFoundDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtFoundByName = new System.Windows.Forms.TextBox();
            this.Clearbtn = new System.Windows.Forms.Button();
            this.Submitbtn = new System.Windows.Forms.Button();
            this.LocLbl = new System.Windows.Forms.Label();
            this.Datelbl = new System.Windows.Forms.Label();
            this.DesLbl = new System.Windows.Forms.Label();
            this.ItemLbl = new System.Windows.Forms.Label();
            this.FoundNameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(323, 307);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(313, 39);
            this.txtLocation.TabIndex = 23;
            // 
            // dtpFoundDate
            // 
            this.dtpFoundDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFoundDate.Location = new System.Drawing.Point(323, 264);
            this.dtpFoundDate.Name = "dtpFoundDate";
            this.dtpFoundDate.Size = new System.Drawing.Size(336, 28);
            this.dtpFoundDate.TabIndex = 22;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(323, 130);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(313, 122);
            this.txtDescription.TabIndex = 21;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(323, 86);
            this.txtItemName.Multiline = true;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(313, 35);
            this.txtItemName.TabIndex = 20;
            // 
            // txtFoundByName
            // 
            this.txtFoundByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFoundByName.Location = new System.Drawing.Point(323, 38);
            this.txtFoundByName.Multiline = true;
            this.txtFoundByName.Name = "txtFoundByName";
            this.txtFoundByName.Size = new System.Drawing.Size(313, 35);
            this.txtFoundByName.TabIndex = 19;
            // 
            // Clearbtn
            // 
            this.Clearbtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.Clearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clearbtn.ForeColor = System.Drawing.Color.White;
            this.Clearbtn.Location = new System.Drawing.Point(443, 370);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(93, 42);
            this.Clearbtn.TabIndex = 18;
            this.Clearbtn.Text = "Clear";
            this.Clearbtn.UseVisualStyleBackColor = false;
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            // 
            // Submitbtn
            // 
            this.Submitbtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.Submitbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submitbtn.ForeColor = System.Drawing.Color.White;
            this.Submitbtn.Location = new System.Drawing.Point(211, 370);
            this.Submitbtn.Name = "Submitbtn";
            this.Submitbtn.Size = new System.Drawing.Size(93, 42);
            this.Submitbtn.TabIndex = 17;
            this.Submitbtn.Text = "Submit";
            this.Submitbtn.UseVisualStyleBackColor = false;
            this.Submitbtn.Click += new System.EventHandler(this.Submitbtn_Click);
            // 
            // LocLbl
            // 
            this.LocLbl.AutoSize = true;
            this.LocLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocLbl.Location = new System.Drawing.Point(142, 310);
            this.LocLbl.Name = "LocLbl";
            this.LocLbl.Size = new System.Drawing.Size(86, 22);
            this.LocLbl.TabIndex = 16;
            this.LocLbl.Text = "Location";
            // 
            // Datelbl
            // 
            this.Datelbl.AutoSize = true;
            this.Datelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datelbl.Location = new System.Drawing.Point(142, 270);
            this.Datelbl.Name = "Datelbl";
            this.Datelbl.Size = new System.Drawing.Size(114, 22);
            this.Datelbl.TabIndex = 15;
            this.Datelbl.Text = "Found Date";
            // 
            // DesLbl
            // 
            this.DesLbl.AutoSize = true;
            this.DesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DesLbl.Location = new System.Drawing.Point(135, 133);
            this.DesLbl.Name = "DesLbl";
            this.DesLbl.Size = new System.Drawing.Size(111, 22);
            this.DesLbl.TabIndex = 14;
            this.DesLbl.Text = "Description";
            // 
            // ItemLbl
            // 
            this.ItemLbl.AutoSize = true;
            this.ItemLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemLbl.Location = new System.Drawing.Point(135, 89);
            this.ItemLbl.Name = "ItemLbl";
            this.ItemLbl.Size = new System.Drawing.Size(104, 22);
            this.ItemLbl.TabIndex = 13;
            this.ItemLbl.Text = "Item Name";
            // 
            // FoundNameLbl
            // 
            this.FoundNameLbl.AutoSize = true;
            this.FoundNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoundNameLbl.Location = new System.Drawing.Point(135, 38);
            this.FoundNameLbl.Name = "FoundNameLbl";
            this.FoundNameLbl.Size = new System.Drawing.Size(152, 22);
            this.FoundNameLbl.TabIndex = 12;
            this.FoundNameLbl.Text = "Found By Name";
            // 
            // frmReportFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.dtpFoundDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.txtFoundByName);
            this.Controls.Add(this.Clearbtn);
            this.Controls.Add(this.Submitbtn);
            this.Controls.Add(this.LocLbl);
            this.Controls.Add(this.Datelbl);
            this.Controls.Add(this.DesLbl);
            this.Controls.Add(this.ItemLbl);
            this.Controls.Add(this.FoundNameLbl);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Name = "frmReportFound";
            this.Text = "frmReportFound";
            this.Load += new System.EventHandler(this.frmReportFound_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.DateTimePicker dtpFoundDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtFoundByName;
        private System.Windows.Forms.Button Clearbtn;
        private System.Windows.Forms.Button Submitbtn;
        private System.Windows.Forms.Label LocLbl;
        private System.Windows.Forms.Label Datelbl;
        private System.Windows.Forms.Label DesLbl;
        private System.Windows.Forms.Label ItemLbl;
        private System.Windows.Forms.Label FoundNameLbl;
    }
}