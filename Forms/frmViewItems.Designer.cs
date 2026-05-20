namespace IMFproject
{
    partial class frmViewItems
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
            this.LostItem = new System.Windows.Forms.TabControl();
            this.LostItems = new System.Windows.Forms.TabPage();
            this.dvgLost = new System.Windows.Forms.DataGridView();
            this.FoundItems = new System.Windows.Forms.TabPage();
            this.dvgFound = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.LostItem.SuspendLayout();
            this.LostItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgLost)).BeginInit();
            this.FoundItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFound)).BeginInit();
            this.SuspendLayout();
            // 
            // LostItem
            // 
            this.LostItem.Controls.Add(this.LostItems);
            this.LostItem.Controls.Add(this.FoundItems);
            this.LostItem.Location = new System.Drawing.Point(37, 55);
            this.LostItem.Name = "LostItem";
            this.LostItem.SelectedIndex = 0;
            this.LostItem.Size = new System.Drawing.Size(844, 343);
            this.LostItem.TabIndex = 0;
            // 
            // LostItems
            // 
            this.LostItems.Controls.Add(this.dvgLost);
            this.LostItems.Location = new System.Drawing.Point(4, 29);
            this.LostItems.Name = "LostItems";
            this.LostItems.Padding = new System.Windows.Forms.Padding(3);
            this.LostItems.Size = new System.Drawing.Size(836, 310);
            this.LostItems.TabIndex = 0;
            this.LostItems.Text = "Lost Items";
            this.LostItems.UseVisualStyleBackColor = true;
            // 
            // dvgLost
            // 
            this.dvgLost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgLost.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dvgLost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgLost.ColumnHeadersVisible = false;
            this.dvgLost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgLost.Location = new System.Drawing.Point(3, 3);
            this.dvgLost.Name = "dvgLost";
            this.dvgLost.RowHeadersWidth = 62;
            this.dvgLost.RowTemplate.Height = 28;
            this.dvgLost.Size = new System.Drawing.Size(830, 304);
            this.dvgLost.TabIndex = 0;
            // 
            // FoundItems
            // 
            this.FoundItems.Controls.Add(this.dvgFound);
            this.FoundItems.Location = new System.Drawing.Point(4, 29);
            this.FoundItems.Name = "FoundItems";
            this.FoundItems.Padding = new System.Windows.Forms.Padding(3);
            this.FoundItems.Size = new System.Drawing.Size(836, 310);
            this.FoundItems.TabIndex = 1;
            this.FoundItems.Text = "Found Items";
            this.FoundItems.UseVisualStyleBackColor = true;
            // 
            // dvgFound
            // 
            this.dvgFound.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgFound.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dvgFound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgFound.Location = new System.Drawing.Point(3, 3);
            this.dvgFound.Name = "dvgFound";
            this.dvgFound.RowHeadersVisible = false;
            this.dvgFound.RowHeadersWidth = 62;
            this.dvgFound.RowTemplate.Height = 28;
            this.dvgFound.Size = new System.Drawing.Size(830, 304);
            this.dvgFound.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(328, 439);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(137, 47);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmViewItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(923, 553);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.LostItem);
            this.Name = "frmViewItems";
            this.Text = "frmViewItems";
            this.Load += new System.EventHandler(this.frmViewItems_Load);
            this.LostItem.ResumeLayout(false);
            this.LostItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgLost)).EndInit();
            this.FoundItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgFound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl LostItem;
        private System.Windows.Forms.TabPage LostItems;
        private System.Windows.Forms.TabPage FoundItems;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dvgLost;
        private System.Windows.Forms.DataGridView dvgFound;
    }
}