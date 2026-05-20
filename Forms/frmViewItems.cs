using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using IMFproject.Models;

namespace IMFproject
{
    public partial class frmViewItems : Form
    {
        // ── Currently selected item stored in ItemModel ──────────
        private ItemModel selectedItem = null;

        public frmViewItems()
        {
            InitializeComponent();
        }

        private void frmViewItems_Load(object sender, EventArgs e)
        {
            StyleGrid(dvgLost);
            StyleGrid(dvgFound);
            LoadData();
        }

        // ── Apply consistent grid styling ────────────────────────
        private void StyleGrid(DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
        }

        // ── Load both tables into grids ──────────────────────────
        private void LoadData()
        {
            try
            {
                var con = DBHelper.GetConnection();
                con.Open();

                // Load Lost Items
                SQLiteDataAdapter da1 = new SQLiteDataAdapter(
                    "SELECT LostID, ReporterName, ItemName, " +
                    "Description, Location, LostDate, Status " +
                    "FROM LostItems ORDER BY LostID DESC", con);

                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dvgLost.DataSource = dt1;

                // Load Found Items
                SQLiteDataAdapter da2 = new SQLiteDataAdapter(
                    "SELECT FoundID, FoundbyName, ItemName, " +
                    "Description, Location, FoundDate, Status " +
                    "FROM FoundItems ORDER BY FoundID DESC", con);

                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dvgFound.DataSource = dt2;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row click on Lost grid — fill ItemModel ──────────────
        private void dvgLost_SelectionChanged(object sender, EventArgs e)
        {
            if (dvgLost.SelectedRows.Count > 0)
            {
                var row = dvgLost.SelectedRows[0];

                selectedItem = new ItemModel
                {
                    Id = Convert.ToInt32(row.Cells["LostID"].Value),
                    ReporterName = row.Cells["ReporterName"].Value.ToString(),
                    ItemName = row.Cells["ItemName"].Value.ToString(),
                    Description = row.Cells["Description"].Value.ToString(),
                    Location = row.Cells["Location"].Value.ToString(),
                    Date = Convert.ToDateTime(row.Cells["LostDate"].Value),
                    Type = "Lost",
                    status = row.Cells["Status"].Value.ToString()
                };

                ShowItemDetail(selectedItem);
            }
        }

        // ── Row click on Found grid — fill ItemModel ─────────────
        private void dvgFound_CellContentClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dvgFound.Rows[e.RowIndex];

                selectedItem = new ItemModel
                {
                    Id = Convert.ToInt32(row.Cells["FoundID"].Value),
                    ReporterName = row.Cells["FoundbyName"].Value.ToString(),
                    ItemName = row.Cells["ItemName"].Value.ToString(),
                    Description = row.Cells["Description"].Value.ToString(),
                    Location = row.Cells["Location"].Value.ToString(),
                    Date = Convert.ToDateTime(row.Cells["FoundDate"].Value),
                    Type = "Found",
                    status = row.Cells["Status"].Value.ToString()
                };

                ShowItemDetail(selectedItem);
            }
        }

        // ── Show full item detail using ItemModel ────────────────
        private void ShowItemDetail(ItemModel item)
        {
            string detail =
                "── Item Details ──────────────────\n" +
                "Type:        " + item.Type + "\n" +
                "Item Name:   " + item.ItemName + "\n" +
                "Reported By: " + item.ReporterName + "\n" +
                "Description: " + item.Description + "\n" +
                "Location:    " + item.Location + "\n" +
                "Date:        " + item.Date.ToString("yyyy-MM-dd") + "\n" +
                "Status:      " + item.status;

            MessageBox.Show(detail, "Item Detail",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Refresh Button ───────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            selectedItem = null;
            LoadData();
        }
    }
}