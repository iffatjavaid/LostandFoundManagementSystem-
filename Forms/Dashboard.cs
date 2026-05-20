using IMFproject.Database;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
//Main dashboard Layout::
namespace IMFproject
{
    public partial class Dashboard : Form
    {
        string userRole = "";
        private LostItemRepository _lostRepo = new LostItemRepository();
        private FoundItemRepository _foundRepo = new FoundItemRepository();
        public Dashboard(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Show welcome message with role
            lbl_Welcome.Text = "Welcome, " + userRole + "!";

            LoadCounts();
            LoadRecentItems();
            ApplyRoleAccess();
        }

        // Hide menu items Staff should not see
        public void ApplyRoleAccess()
        {
            if (userRole == "Staff"|| userRole == "User")
            {
                reportsToolStripMenuItem.Visible = false;
                statusToolStripMenuItem.Visible = false;
                manageUsersToolStripMenuItem.Visible = false;
                backupDatabaseToolStripMenuItem.Visible=false;


            }
        }

        // Load the 4 count labels on dashboard
        public void LoadCounts()
        {
            lblLostCount.Text = _lostRepo
                .GetCountByStatus("Pending").ToString();

            lblFoundCount.Text = _foundRepo
                .GetCountByStatus("Available").ToString();

            lblMatchedCount.Text = (
                _lostRepo.GetCountByStatus("Matched") +
                _foundRepo.GetCountByStatus("Matched")).ToString();

            lblClaimedCount.Text = (
                _lostRepo.GetCountByStatus("Claimed") +
                _foundRepo.GetCountByStatus("Claimed")).ToString();
        }

        // Load last 10 items into the grid
        public void LoadRecentItems()
        {
            try
            {
                var con = DBHelper.GetConnection();
                con.Open();

                string query =
                    "SELECT LostID as ID, 'Lost' as Type, " +
                    "ItemName, Location, LostDate as Date, Status " +
                    "FROM LostItems " +
                    "UNION ALL " +
                    "SELECT FoundID, 'Found', ItemName, " +
                    "Location, FoundDate, Status " +
                    "FROM FoundItems " +
                    "ORDER BY Date DESC " +
                    "LIMIT 10";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRecent.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recent items: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Menu Navigation ──────────────────────────────────────

        // View All Items
        private void viewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewItems frm = new frmViewItems();
            frm.Show();
        }

        // Report Lost Item
        private void addProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportLost frm = new frmReportLost();
            frm.ShowDialog();
            // Refresh dashboard after returning
            LoadCounts();
            LoadRecentItems();
        }

        // Report Found Item
        private void manageCatogoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportFound frm = new frmReportFound();
            frm.ShowDialog();
            LoadCounts();
            LoadRecentItems();
        }

        // Search & Match
        private void searchMatchIteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch frm = new frmSearch();
            frm.ShowDialog();
            LoadCounts();
            LoadRecentItems();
        }

        // Update Status
        private void updateItemStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateStatus frm = new frmUpdateStatus();
            frm.ShowDialog();
            LoadCounts();
            LoadRecentItems();
        }

        // Reports — Full Summary
        private void fullSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            frm.Show();
        }

        // Reports — Pending Items
        private void pendingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            frm.Show();
        }

        // Reports — Matched Items
        private void matchedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            frm.Show();
        }

        // Manage Users (Admin only)
        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        // About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        // Logout
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                this.Hide();
                login.Show();
            }
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void databaseToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void lbl_Welcome_Click(object sender, EventArgs e) { }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 

                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "Select folder to save database backup";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = DBHelper.DatabasePath;

                    // Backup filename includes date and time
                    string backupFileName = "lostfoubd_backup_" +
                        DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".db";

                    string destinationPath = System.IO.Path.Combine(
                        folderDialog.SelectedPath, backupFileName);

                    // Check source DB exists
                    if (!System.IO.File.Exists(sourcePath))
                    {
                        MessageBox.Show(
                            "Database file not found: " + sourcePath,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    // Copy the database file
                    System.IO.File.Copy(sourcePath, destinationPath, overwrite: true);
                    long filesize = DBHelper.GetDatabaseFileSize();
                    string filesizeText = (filesize / 1024) + "KB";
                    MessageBox.Show(
                        "Backup Successful!\n\n" +
                        "File saved as:\n" + backupFileName + "\n\n" +
                        "Size : "    +filesizeText +"\n"+
                        "Location:\n" + folderDialog.SelectedPath,
                        "Backup Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Backup Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
} 