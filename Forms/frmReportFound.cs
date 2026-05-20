using System;
using System.Data.SQLite;
using System.Windows.Forms;
using IMFproject.Database;
using IMFproject.Models;
//Validation for reporting Found Items
namespace IMFproject
{
    public partial class frmReportFound : Form
    {
        private FoundItemRepository _foundRepo=new FoundItemRepository();
        // ── Using ItemModel to hold form data before saving ──
        private ItemModel currentItem = new ItemModel();

        public frmReportFound()
        {
            InitializeComponent();
        }

        private void frmReportFound_Load(object sender, EventArgs e)
        {
            // Set date picker to today by default
            dtpFoundDate.Value = DateTime.Today;
            dtpFoundDate.Format = DateTimePickerFormat.Short;

            // Can't report a future found date
            dtpFoundDate.MaxDate = DateTime.Today;
        }

        // ── Submit Button ────────────────────────────────────────
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            // Step 1: Validate all fields
            if (!ValidateFields()) return;

            // Step 2: Fill ItemModel from form fields
            currentItem.ItemName = txtItemName.Text.Trim();
            currentItem.Description = txtDescription.Text.Trim();
            currentItem.Location = txtLocation.Text.Trim();
            currentItem.Date = dtpFoundDate.Value;
            currentItem.Type = "Found";
            currentItem.status = "Available";

            // Step 3: Save to database
            SaveFoundItem(currentItem, txtFoundByName.Text.Trim());
        }

        // ── Save using ItemModel data ────────────────────────────
        private void SaveFoundItem(ItemModel item, string foundByName)
        {
            bool saved =_foundRepo.AddFoundItem(item,foundByName);
            if (saved) 
            {
                MessageBox.Show("Found Item Reported Successfully!");
                ClearForm();
                RefreshDashboard();
            }
        }

        // ── Validation ───────────────────────────────────────────
        private bool ValidateFields()
        {
            if (txtFoundByName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the name of person who found the item.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFoundByName.Focus();
                return false;
            }

            if (txtItemName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Item Name.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return false;
            }

            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Description.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (txtLocation.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Location.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            return true;
        }

        // ── Clear Button ─────────────────────────────────────────
        private void Clearbtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // ── Clear all fields properly ────────────────────────────
        private void ClearForm()
        {
            txtFoundByName.Text = "";
            txtItemName.Text = "";
            txtDescription.Text = "";
            txtLocation.Text = "";
            dtpFoundDate.Value = DateTime.Today;

            // Reset ItemModel
            currentItem = new ItemModel();

            txtFoundByName.Focus();
        }

        // ── Refresh dashboard after adding item ──────────────────
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