using IMFproject.Database;
using IMFproject.Models;
using System;
using System.Windows.Forms;

namespace IMFproject
{
    public partial class frmSearch : Form
    {
        // ── Repositories replace all direct DBHelper calls ───────
        private LostItemRepository _lostRepo = new LostItemRepository();
        private FoundItemRepository _foundRepo = new FoundItemRepository();
        private ClaimRepository _claimRepo = new ClaimRepository();

        // ── Track selected items using ItemModel ─────────────────
        private ItemModel selectedLostItem = null;
        private ItemModel selectedFoundItem = null;

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            dgvLostResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFoundResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLostResults.MultiSelect = false;
            dgvFoundResults.MultiSelect = false;

            dgvLostResults.RowHeadersVisible = false;
            dgvFoundResults.RowHeadersVisible = false;

            dgvLostResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFoundResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ── Search Button ────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("Please enter an item name to search.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            // Reset selections
            selectedLostItem = null;
            selectedFoundItem = null;

            SearchItems(txtSearch.Text.Trim());
        }

        // ── Search both tables via repositories ──────────────────
        private void SearchItems(string keyword)
        {
            dgvLostResults.DataSource = _lostRepo.SearchLostItems(keyword);
            dgvFoundResults.DataSource = _foundRepo.SearchFoundItems(keyword);
        }

        // ── Row click on Lost grid — fill selectedLostItem ───────
        private void dgvLostResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLostResults.SelectedRows.Count > 0)
            {
                var row = dgvLostResults.SelectedRows[0];
                selectedLostItem = new ItemModel
                {
                    Id = Convert.ToInt32(row.Cells["LostID"].Value),
                    ItemName = row.Cells["ItemName"].Value.ToString(),
                    Location = row.Cells["Location"].Value.ToString(),
                    Type = "Lost",
                    status = row.Cells["Status"].Value.ToString()
                };
            }
        }

        // ── Row click on Found grid — fill selectedFoundItem ─────
        private void dgvFoundResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFoundResults.SelectedRows.Count > 0)
            {
                var row = dgvFoundResults.SelectedRows[0];
                selectedFoundItem = new ItemModel
                {
                    Id = Convert.ToInt32(row.Cells["FoundID"].Value),
                    ItemName = row.Cells["ItemName"].Value.ToString(),
                    Location = row.Cells["Location"].Value.ToString(),
                    Type = "Found",
                    status = row.Cells["Status"].Value.ToString()
                };
            }
        }

        // ── Match Button ─────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedLostItem == null || selectedFoundItem == null)
            {
                MessageBox.Show(
                    "Please select one item from each grid to match.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Match these items?\n\n" +
                "Lost:  " + selectedLostItem.ItemName + " (" + selectedLostItem.Location + ")\n" +
                "Found: " + selectedFoundItem.ItemName + " (" + selectedFoundItem.Location + ")",
                "Confirm Match", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            MatchItems();
        }

        // ── Core match logic — all DB work done by repositories ──
        private void MatchItems()
        {
            try
            {
                // Update both item statuses
                _lostRepo.UpdateStatus(selectedLostItem.Id, "Matched");
                _foundRepo.UpdateStatus(selectedFoundItem.Id, "Matched");

                // Record the match as a claim
                _claimRepo.AddClaim(new ClaimModel
                {
                    LostId = selectedLostItem.Id,
                    FoundId = selectedFoundItem.Id,
                    ClaimedByName = "Pending Owner",
                    ClaimDate = DateTime.Today,
                    Remarks = "Matched"
                });

                MessageBox.Show(
                    "Items Matched Successfully!\n\n" +
                    "Lost Item ID:  " + selectedLostItem.Id + "\n" +
                    "Found Item ID: " + selectedFoundItem.Id + "\n\n" +
                    "Both statuses updated to Matched.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset selections
                selectedLostItem = null;
                selectedFoundItem = null;

                // Re-run search to show updated statuses
                if (txtSearch.Text.Trim() != "")
                    SearchItems(txtSearch.Text.Trim());

                RefreshDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Match Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Refresh dashboard counts ─────────────────────────────
        private void RefreshDashboard()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Dashboard dash)
                {
                    dash.LoadCounts();
                    dash.LoadRecentItems();
                    break;
                }
            }
        }
    }
}