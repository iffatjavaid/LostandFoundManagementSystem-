namespace IMFproject
{
    partial class frmSearch
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
            this.searchlbl = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLostResults = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFoundResults = new System.Windows.Forms.DataGridView();
            this.matchbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLostResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoundResults)).BeginInit();
            this.SuspendLayout();
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlbl.Location = new System.Drawing.Point(75, 27);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(77, 22);
            this.searchlbl.TabIndex = 0;
            this.searchlbl.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(162, 24);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(176, 31);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(403, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 39);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lost Items Result :";
            // 
            // dgvLostResults
            // 
            this.dgvLostResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvLostResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLostResults.Location = new System.Drawing.Point(79, 111);
            this.dgvLostResults.Name = "dgvLostResults";
            this.dgvLostResults.RowHeadersWidth = 62;
            this.dgvLostResults.RowTemplate.Height = 28;
            this.dgvLostResults.Size = new System.Drawing.Size(483, 110);
            this.dgvLostResults.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Found Item Results :";
            // 
            // dgvFoundResults
            // 
            this.dgvFoundResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvFoundResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFoundResults.Location = new System.Drawing.Point(79, 278);
            this.dgvFoundResults.Name = "dgvFoundResults";
            this.dgvFoundResults.RowHeadersWidth = 62;
            this.dgvFoundResults.RowTemplate.Height = 28;
            this.dgvFoundResults.Size = new System.Drawing.Size(483, 99);
            this.dgvFoundResults.TabIndex = 6;
            // 
            // matchbtn
            // 
            this.matchbtn.BackColor = System.Drawing.Color.MidnightBlue;
            this.matchbtn.ForeColor = System.Drawing.Color.White;
            this.matchbtn.Location = new System.Drawing.Point(253, 398);
            this.matchbtn.Name = "matchbtn";
            this.matchbtn.Size = new System.Drawing.Size(127, 49);
            this.matchbtn.TabIndex = 7;
            this.matchbtn.Text = "Match Items";
            this.matchbtn.UseVisualStyleBackColor = false;
            this.matchbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 459);
            this.Controls.Add(this.matchbtn);
            this.Controls.Add(this.dgvFoundResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLostResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.searchlbl);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLostResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFoundResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLostResults;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFoundResults;
        private System.Windows.Forms.Button matchbtn;
    }
}