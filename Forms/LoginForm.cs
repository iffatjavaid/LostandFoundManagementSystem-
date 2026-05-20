using IMFproject.Database;
using IMFproject.Models;
using System;
using System.Windows.Forms;

namespace IMFproject
{
    public partial class LoginForm : Form
    {
        // ── Repository handles all DB work ───────────────────────
        private UserRepository _userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        // ── Login Button ─────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxName.Text.Trim();
            string password = textBoxID.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both Username and Password.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UserModel user = _userRepo.GetByUsername(username);

                if (user == null)
                {
                    MessageBox.Show("Username not found. Please try again.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxName.Focus();
                    return;
                }

                bool passwordMatch = user.password.StartsWith("$2")
                    ? BCrypt.Net.BCrypt.Verify(password, user.password)
                    : user.password == password;

                if (passwordMatch)
                {
                    MessageBox.Show("Login Successful! Welcome " + user.UserName,
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Dashboard dashboard = new Dashboard(user.Role);
                    this.Hide();
                    dashboard.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Password. Please try again.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxID.Clear();
                    textBoxID.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Exit Button ──────────────────────────────────────────
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e) { }
        private void textBoxID_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
