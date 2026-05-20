using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using IMFproject.Models;
//Status matching rules Application
namespace IMFproject
{
    public partial class frmUpdateStatus : Form
    {
        // ── Selected item stored in ItemModel ────────────────────
        private ItemModel selectedItem = null;
        bool isLoaded = false;

        public frmUpdateStatus()
        {
            InitializeComponent();
        }

        private void frmUpdateStatus_Load(object sender, EventArgs e)
        {
            
            // Setup Type dropdown
            cmbType.Items.Clear();
            cmbType.Items.Add("Lost");
            cmbType.Items.Add("Found");
            cmbType.SelectedIndex = 0;

            // Setup Status dropdown
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Matched");
            cmbStatus.Items.Add("Claimed");
            cmbStatus.SelectedIndex = 0;

            // Style grid
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.RowHeadersVisible = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.ReadOnly = true;

            LoadItems();
            isLoaded= true;
        }

        // ── Load items based on selected Type ────────────────────
        private void LoadItems()
        {
            try
            {
                var con = DBHelper.GetConnection();
                con.Open();

                string query = "";

                if (cmbType.SelectedItem.ToString() == "Lost")
                {
                    query =
                        "SELECT LostID as ID, ReporterName as Name, " +
                        "ItemName, Location, LostDate as Date, Status " +
                        "FROM LostItems " +
                        "ORDER BY LostID DESC";
                }
                else
                {
                    query =
                        "SELECT FoundID as ID, FoundbyName as Name, " +
                        "ItemName, Location, FoundDate as Date, Status " +
                        "FROM FoundItems " +
                        "ORDER BY FoundID DESC";
                }

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvItems.DataSource = dt;

                con.Close();

                // Reset selection
                selectedItem = null;
                txtItemID.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row click — fill ItemModel from selected row ─────────
        private void dgvItems_CellContentClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvItems.Rows[e.RowIndex];

                selectedItem = new ItemModel
                {
                    Id = Convert.ToInt32(row.Cells["ID"].Value),
                    ItemName = row.Cells["ItemName"].Value.ToString(),
                    Location = row.Cells["Location"].Value.ToString(),
                    Type = cmbType.SelectedItem.ToString(),
                    status = row.Cells["Status"].Value.ToString()
                };

                // Show selected ID in textbox
                txtItemID.Text = selectedItem.Id.ToString();

                // Auto set status dropdown to current status
                cmbStatus.SelectedItem = selectedItem.status;
            }
        }

        // ── Also handle full row selection click ─────────────────
        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                var row = dgvItems.SelectedRows[0];

                selectedItem = new ItemModel
                {
                    Id = Convert.ToInt32(row.Cells["ID"].Value),
                    ItemName = row.Cells["ItemName"].Value.ToString(),
                    Location = row.Cells["Location"].Value.ToString(),
                    Type = cmbType.SelectedItem.ToString(),
                    status = row.Cells["Status"].Value.ToString()
                };

                txtItemID.Text = selectedItem.Id.ToString();
                cmbStatus.SelectedItem = selectedItem.status;
            }
        }

        // ── Type dropdown changed — reload grid ──────────────────
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;
            LoadItems();
        }

        // ── Update Button ─────────────────────────────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validation
            if (selectedItem == null || txtItemID.Text == "")
            {
                MessageBox.Show("Please select an item from the grid first.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = cmbStatus.SelectedItem.ToString();
            string oldStatus = selectedItem.status;

            // Warn if status is same
            if (newStatus == oldStatus)
            {
                MessageBox.Show(
                    "Item is already set to '" + newStatus + "'.\nPlease select a different status.",
                    "No Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // If marking as Claimed — ask for owner name using ClaimModel
            if (newStatus == "Claimed")
            {
                HandleClaim(selectedItem);
                return;
            }

            // Confirm update for other statuses
            DialogResult confirm = MessageBox.Show(
                "Update status of '" + selectedItem.ItemName + "' from " +
                "'" + oldStatus + "' to '" + newStatus + "'?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            UpdateStatus(selectedItem.Id, selectedItem.Type, newStatus);
        }

        // ── Handle Claimed status — needs owner name ──────────────
        private void HandleClaim(ItemModel item)
        {
            // Ask for owner name before marking claimed
            string ownerName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter the name of the person claiming this item:",
                "Claim Item — " + item.ItemName,
                "");

            if (ownerName.Trim() == "")
            {
                MessageBox.Show("Owner name is required to mark item as Claimed.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var con = DBHelper.GetConnection();
                con.Open();

                // Update item status to Claimed
                string updateQuery = item.Type == "Lost"
                    ? "UPDATE LostItems SET Status='Claimed' WHERE LostID=@id"
                    : "UPDATE FoundItems SET Status='Claimed' WHERE FoundID=@id";

                var cmd1 = new SQLiteCommand(updateQuery, con);
                cmd1.Parameters.AddWithValue("@id", item.Id);
                cmd1.ExecuteNonQuery();

                // Build ClaimModel and insert into ClaimRecord
                ClaimModel claim = new ClaimModel
                {
                    LostId = item.Type == "Lost" ? item.Id : 0,
                    FoundId = item.Type == "Found" ? item.Id : 0,
                    ClaimedByName = ownerName.Trim(),
                    ClaimDate = DateTime.Today,
                    Remarks = "Claimed by owner"
                };

                var cmd2 = new SQLiteCommand(
                    @"INSERT INTO ClaimRecord
                        (LostID, FoundID, ClaimedbyName, ClaimDate, Remarks)
                      VALUES
                        (@lid, @fid, @cname, @date, @remarks)", con);

                cmd2.Parameters.AddWithValue("@lid", claim.LostId);
                cmd2.Parameters.AddWithValue("@fid", claim.FoundId);
                cmd2.Parameters.AddWithValue("@cname", claim.ClaimedByName);
                cmd2.Parameters.AddWithValue("@date", claim.ClaimDate.ToString("yyyy-MM-dd"));
                cmd2.Parameters.AddWithValue("@remarks", claim.Remarks);
                cmd2.ExecuteNonQuery();

                con.Close();

                MessageBox.Show(
                    "Item marked as Claimed!\n\n" +
                    "Item:       " + item.ItemName + "\n" +
                    "Claimed By: " + ownerName.Trim() + "\n" +
                    "Date:       " + DateTime.Today.ToString("yyyy-MM-dd"),
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadItems();
                RefreshDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update status for non-Claimed statuses ────────────────
        private void UpdateStatus(int id, string type, string newStatus)
        {
            try
            {
                var con = DBHelper.GetConnection();
                con.Open();

                string query = type == "Lost"
                    ? "UPDATE LostItems SET Status=@status WHERE LostID=@id"
                    : "UPDATE FoundItems SET Status=@status WHERE FoundID=@id";

                var cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show(
                    "Status updated to '" + newStatus + "' successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadItems();
                RefreshDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Refresh Button ────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            selectedItem = null;
            txtItemID.Text = "";
            LoadItems();
        }

        // ── Refresh dashboard counts ──────────────────────────────
        private void RefreshDashboard()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Dashboard)
                {
                    ((Dashboard)f).LoadCounts();
                    ((Dashboard)f).LoadRecentItems();
                    break;
                }
            }
        }
    }
}