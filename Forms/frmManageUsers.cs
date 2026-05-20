using IMFproject.Database;
using IMFproject.Models;
using System;
using System.Windows.Forms;

namespace IMFproject
{
    public partial class frmManageUsers : Form
    {
        // ── UserRepository replaces direct DBHelper calls ────────
        private UserRepository _userRepo = new UserRepository();

        // ── Track selected user using UserModel ──────────────────
        private UserModel selectedUser = null;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");
            cmbRole.SelectedIndex = 1; // Default to Staff

            // Style grid
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ReadOnly = true;

            LoadUsers();
        }

        // ── Load all users into grid ─────────────────────────────
        private void LoadUsers()
        {
            try
            {
                dgvUsers.DataSource = _userRepo.GetAllUsers();
                lblTotal.Text = "Total Users: " + _userRepo.GetTotalUsers();

                // Reset selection
                selectedUser = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row click — fill UserModel ───────────────────────────
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var row = dgvUsers.SelectedRows[0];

                selectedUser = new UserModel
                {
                    UserId = Convert.ToInt32(row.Cells["UserID"].Value),
                    UserName = row.Cells["Username"].Value.ToString(),
                    Role = row.Cells["Role"].Value.ToString()
                };

                // Fill form fields with selected user
                txtUsername.Text = selectedUser.UserName;
                cmbRole.SelectedItem = selectedUser.Role;
                txtPassword.Text = ""; // never show password
            }
        }

        // ── Validate fields before Add or Update ─────────────────
        private bool ValidateFields()
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Username.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a Role.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            return true;
        }

        // ── Add Button ───────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            // Password required for new user
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Password for the new user.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Check username doesn't already exist
            if (_userRepo.UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show(
                    "Username '" + txtUsername.Text.Trim() + "' already exists.\n" +
                    "Please choose a different username.",
                    "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            try
            {
                bool added = _userRepo.AddUser(new UserModel
                {
                    UserName = txtUsername.Text.Trim(),
                    password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text),
                    Role = cmbRole.SelectedItem.ToString()
                });

                if (added)
                {
                    MessageBox.Show(
                        "User Added Successfully!\n\n" +
                        "Username: " + txtUsername.Text.Trim() + "\n" +
                        "Role:     " + cmbRole.SelectedItem.ToString(),
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearFields();
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update Button (button1) ───────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a user from the grid to update.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFields()) return;

            DialogResult confirm = MessageBox.Show(
                "Update user '" + selectedUser.UserName + "'?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                // Build updated model; only hash password if one was entered
                UserModel updatedUser = new UserModel
                {
                    UserId = selectedUser.UserId,
                    UserName = txtUsername.Text.Trim(),
                    password = txtPassword.Text.Trim() != ""
                                   ? BCrypt.Net.BCrypt.HashPassword(txtPassword.Text)
                                   : null,
                    Role = cmbRole.SelectedItem.ToString()
                };

                _userRepo.UpdateUser(updatedUser);

                MessageBox.Show("User Updated Successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete Button ─────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a user to delete.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent deleting the main admin account
            if (selectedUser.UserName.ToLower() == "admin")
            {
                MessageBox.Show(
                    "The main Admin account cannot be deleted.",
                    "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete user '" +
                selectedUser.UserName + "'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                _userRepo.DeleteUser(selectedUser.UserId);

                MessageBox.Show("User Deleted Successfully!",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Clear Button ──────────────────────────────────────────
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cmbRole.SelectedIndex = 0;
            selectedUser = null;
        }

        // ── Designer compatibility stub ───────────────────────────
        // Required because frmManageUsers.Designer.cs wires btnDelete.Click
        // to this method name. Forwards to the real handler.
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }
    }
}
