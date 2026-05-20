using System;
using System.Data;
using System.Data.SQLite;
using IMFproject.Models;

namespace IMFproject.Database
{
    /// <summary>
    /// Handles all database operations for the Users table.
    /// Includes login verification, CRUD operations,
    /// and duplicate username checking.
    /// </summary>
    public class UserRepository : BaseRepository
    {
        // ── LOGIN — verify username and password ─────────────────
        /// <summary>
        /// Finds user by username from Users table.
        /// Returns UserModel if found, null if not found.
        /// Password verification done in LoginForm using BCrypt.
        /// </summary>
        public UserModel GetByUsername(string username)
        {
            DataTable dt = ExecuteQuery(
                "SELECT UserID, Username, Password, Role " +
                "FROM Users WHERE Username = @user",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@user", username)
                });

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new UserModel
            {
                UserId = Convert.ToInt32(row["UserID"]),
                UserName = row["Username"].ToString(),
                password = row["Password"].ToString(),
                Role = row["Role"].ToString()
            };
        }

        // ── CREATE — add new user ────────────────────────────────
        /// <summary>
        /// Inserts new user into Users table.
        /// Password must already be BCrypt hashed before calling.
        /// </summary>
        public bool AddUser(UserModel user)
        {
            int rows = ExecuteNonQuery(
                "INSERT INTO Users (Username, Password, Role) " +
                "VALUES (@user, @pass, @role)",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@user", user.UserName),
                    new SQLiteParameter("@pass", user.password),
                    new SQLiteParameter("@role", user.Role)
                });
            return rows > 0;
        }

        // ── READ — get all users ─────────────────────────────────
        /// <summary>
        /// Returns all users from Users table.
        /// Password column excluded for security.
        /// </summary>
        public DataTable GetAllUsers()
        {
            return ExecuteQuery(
                "SELECT UserID, Username, Role " +
                "FROM Users ORDER BY UserID DESC");
        }

        // ── UPDATE — update existing user ────────────────────────
        /// <summary>
        /// Updates username and role of existing user.
        /// If newPassword provided it is also updated.
        /// </summary>
        public bool UpdateUser(UserModel user,
            bool updatePassword = false)
        {
            if (updatePassword)
            {
                int rows = ExecuteNonQuery(
                    "UPDATE Users SET Username=@user, " +
                    "Password=@pass, Role=@role " +
                    "WHERE UserID=@id",
                    new SQLiteParameter[]
                    {
                        new SQLiteParameter("@user", user.UserName),
                        new SQLiteParameter("@pass", user.password),
                        new SQLiteParameter("@role", user.Role),
                        new SQLiteParameter("@id",   user.UserId)
                    });
                return rows > 0;
            }
            else
            {
                int rows = ExecuteNonQuery(
                    "UPDATE Users SET Username=@user, " +
                    "Role=@role WHERE UserID=@id",
                    new SQLiteParameter[]
                    {
                        new SQLiteParameter("@user", user.UserName),
                        new SQLiteParameter("@role", user.Role),
                        new SQLiteParameter("@id",   user.UserId)
                    });
                return rows > 0;
            }
        }

        // ── DELETE — remove user ─────────────────────────────────
        /// <summary>
        /// Deletes user from Users table by UserID.
        /// Returns true if deletion was successful.
        /// </summary>
        public bool DeleteUser(int userId)
        {
            int rows = ExecuteNonQuery(
                "DELETE FROM Users WHERE UserID=@id",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@id", userId)
                });
            return rows > 0;
        }

        // ── CHECK — duplicate username ───────────────────────────
        /// <summary>
        /// Checks if username already exists in Users table.
        /// Used before adding new user to prevent duplicates.
        /// </summary>
        public bool UsernameExists(string username)
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM Users " +
                "WHERE Username = @user",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@user", username)
                });
            return Convert.ToInt32(result) > 0;
        }

        // ── COUNT — total users ──────────────────────────────────
        public int GetTotalUsers()
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM Users");
            return Convert.ToInt32(result);
        }
    }
}