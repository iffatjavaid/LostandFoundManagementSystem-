using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

  namespace IMFproject
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            LoadReports();
        }
        private void LoadReports() 
        {
			try
			{
				var con = DBHelper.GetConnection();
				con.Open();
      // Pending Items
				SQLiteDataAdapter da1 =new SQLiteDataAdapter("SELECT LostID as ID, ReporterName," +"ItemName, Location, LostDate, Status " +
				"FROM LostItems WHERE Status='Pending'",con);
				DataTable dt1 = new DataTable();
				da1.Fill(dt1);
				dgvPending.DataSource = dt1;
				dgvPending.RowHeadersVisible = false;
				dgvPending.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;
                // Matched Items
                SQLiteDataAdapter da2 = new SQLiteDataAdapter("SELECT " + "LostID as ID, " + "'Lost' as Type, " +  "ReporterName as Name, " + "ItemName, " +
                "Location, " + "LostDate as Date, " + "Status " +  "FROM LostItems " + "WHERE Status='Matched' " + "UNION ALL " +
                "SELECT " + "FoundID, " + "'Found', " +  "FoundByName, " + "ItemName, " + "Location, " + "FoundDate, " + "Status " +
                "FROM FoundItems " + "WHERE Status='Matched'" , con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dgvMatched.DataSource = dt2;
                dgvMatched.RowHeadersVisible = false;
                dgvMatched.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
                //  Full Summary
                SQLiteDataAdapter da3 =new SQLiteDataAdapter("SELECT LostID as ID,'Lost' as Type," +"ItemName, Location, LostDate as Date," +
				"Status FROM LostItems " +"UNION ALL " +"SELECT FoundID,'Found'," +"ItemName, Location, FoundDate," +
				"Status FROM FoundItems",con);
				DataTable dt3 = new DataTable();
				da3.Fill(dt3);
				dgvAll.DataSource = dt3;
				dgvAll.RowHeadersVisible = false;
				dgvAll.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;

	 // Update Total Label
				lblTotal.Text = "Total Records: " +dt3.Rows.Count.ToString();
				con.Close();
			}
			catch (Exception ex) 
            {
				MessageBox.Show("Error: " + ex.Message);
			}
		}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void dgvMatched_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
  }
