using System;
using System.Windows.Forms;
using IMFproject.Database;
using IMFproject.Models;
//Validation for Reporting Lost Items
namespace IMFproject
{
    public partial class frmReportLost : Form
    {
        // ── Repository handles all DB work ───────────────────────
        private LostItemRepository _lostRepo = new LostItemRepository();

        // ── ItemModel holds form data before saving ──────────────
        private ItemModel currentItem = new ItemModel();

        public frmReportLost()
        {
            InitializeComponent();
        }

        private void frmReportLost_Load(object sender, EventArgs e)
        {
            // Set date picker to today by default
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Short;

            // Can't report a future lost item
            dateTimePicker1.MaxDate = DateTime.Today;
        }

        // ── Submit Button ────────────────────────────────────────
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            // Step 1: Validate all fields
            if (!ValidateFields()) return;

            // Step 2: Fill ItemModel from form fields
            currentItem.ItemName = ItmNmetxtBox.Text.Trim();
            currentItem.Description = DestxtBox.Text.Trim();
            currentItem.Location = Loctxtbox.Text.Trim();
            currentItem.Date = dateTimePicker1.Value;
            currentItem.Type = "Lost";
            currentItem.status = "Pending";

            // Step 3: Save via repository (no raw SQL here)
            try
            {
                _lostRepo.AddLostItem(currentItem, RptNmetxtBox.Text.Trim());

                MessageBox.Show(
                    "Lost Item Reported Successfully!\n\n" +
                    "Item: " + currentItem.ItemName + "\n" +
                    "Location: " + currentItem.Location + "\n" +
                    "Status: Pending",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Validation ───────────────────────────────────────────
        private bool ValidateFields()
        {
            if (RptNmetxtBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Reporter Name.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RptNmetxtBox.Focus();
                return false;
            }

            if (ItmNmetxtBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Item Name.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ItmNmetxtBox.Focus();
                return false;
            }

            if (DestxtBox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Description.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DestxtBox.Focus();
                return false;
            }

            if (Loctxtbox.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Location.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Loctxtbox.Focus();
                return false;
            }

            return true;
        }

        // ── Clear Button ─────────────────────────────────────────
        private void Clearbtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            RptNmetxtBox.Text = "";
            ItmNmetxtBox.Text = "";
            DestxtBox.Text = "";
            Loctxtbox.Text = "";
            dateTimePicker1.Value = DateTime.Today;

            // Reset ItemModel
            currentItem = new ItemModel();

            RptNmetxtBox.Focus();
        }

        // ── Refresh dashboard counts after adding item ────────────
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

        private void label1_Click(object sender, EventArgs e) { }
    }
}