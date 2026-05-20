using System.Data;
using System.Data.SQLite;

namespace IMFproject.Database
{
    /// <summary>
    // Base class for all Repository classes.
    /// Uses DBHelper for all database connections.
    /// All repositories inherit from this class.
    /// </summary>
    public abstract class BaseRepository
    {
        /// ── Execute INSERT UPDATE DELETE ─────────────────────────
        /// <summary>
        /// Executes non-query SQL commands safely.
        /// Uses parameterized queries to prevent SQL injection.
        /// Connection auto-closes via using block.
        /// Returns number of rows affected.
        /// </summary>
        protected int ExecuteNonQuery(string query,
            SQLiteParameter[] parameters = null)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        // ── Execute SELECT returns DataTable ─────────────────────
        /// <summary>
        /// Executes SELECT query and returns results as DataTable.
        /// Used by all Repository classes for read operations.
        /// Connection auto-closes via using block.
        /// </summary>
        protected  DataTable ExecuteQuery(string query,
            SQLiteParameter[] parameters = null)
        {
            var dt = new DataTable();
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        // ── Execute SELECT returns single value ──────────────────
        /// <summary>
        /// Executes query returning a single value.
        /// Used for COUNT MAX MIN operations on tables.
        /// Connection auto-closes via using block.
        /// </summary>
        protected object ExecuteScalar(string query,
            SQLiteParameter[] parameters = null)
        {
            using (var con = DBHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}