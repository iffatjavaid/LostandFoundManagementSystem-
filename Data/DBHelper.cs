using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
//Database helper class for Managing connections
/// NuGet packages needed:
/// System.Data.SQLite.Core
/// BCrypt.Net-Next

namespace IMFproject
{
    /// <summary>
    /// Manages database connection for the Lost and Found
    /// Management System. Centralizes connection string
    /// configuration and core query execution methods.
    /// All Repository classes use this class for connections.
    /// </summary>
    public static class DBHelper
    {
        private static string _databasePath = string.Empty;
        private static string _connectionString = string.Empty;

        // ── Database file path ───────────────────────────────────
        /// <summary>
        /// Gets the current database file path.
        /// Database file is located in bin/Debug folder.
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                if (string.IsNullOrEmpty(_databasePath))
                {
                    string baseDirectory =
                        AppDomain.CurrentDomain.BaseDirectory;
                    _databasePath = Path.Combine(
                        baseDirectory, "lostfoubd.db");
                }
                return _databasePath;
            }
        }

        // ── Connection string ────────────────────────────────────
        /// <summary>
        /// Gets the SQLite connection string.
        /// Built once and cached for performance.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString =
                        $"Data Source={DatabasePath};Version=3;";
                }
                return _connectionString;
            }
        }

        // ── Get connection ───────────────────────────────────────
        /// <summary>
        /// Creates and returns a new SQLite connection.
        /// Always use inside a using block to auto-close.
        /// Caller is responsible for opening and disposing.
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        // ── Test connection ──────────────────────────────────────
        /// <summary>
        /// Tests if the database file exists and is accessible.
        /// Called on application startup to verify DB is ready.
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                if (!File.Exists(DatabasePath))
                    return false;

                using (var con = GetConnection())
                {
                    con.Open();
                    return con.State ==
                        System.Data.ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        // ── Get database file size ───────────────────────────────
        /// <summary>
        /// Gets database file size in bytes.
        /// Used by backup feature to show file information.
        /// </summary>
        public static long GetDatabaseFileSize()
        {
            if (File.Exists(DatabasePath))
                return new FileInfo(DatabasePath).Length;
            return 0;
        }
    }
}