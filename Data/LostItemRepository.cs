using IMFproject.Models;
using System;
using System.Data;
using System.Data.SQLite;

namespace IMFproject.Database
{
    /// <summary>
    /// Handles all database operations for the LostItems table.
    /// Includes CRUD operations and status management.
    /// </summary>
    public class LostItemRepository : BaseRepository
    {
        // ── CREATE — add new lost item ───────────────────────────
        /// <summary>
        /// Inserts new lost item into LostItems table.
        /// Status automatically set to Pending on creation.
        /// </summary>
        public bool AddLostItem(ItemModel item, string reporterName)
        {
            int rows = ExecuteNonQuery(
                @"INSERT INTO LostItems
                  (ReporterName, ItemName, Description,
                   LostDate, Location, Status)
                  VALUES
                  (@name, @item, @desc, @date, @loc, @status)",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@name",   reporterName),
                    new SQLiteParameter("@item",   item.ItemName),
                    new SQLiteParameter("@desc",   item.Description),
                    new SQLiteParameter("@date",
                        item.Date.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@loc",    item.Location),
                    new SQLiteParameter("@status", "Pending")
                });
            return rows > 0;
        }

        // ── READ — get all lost items ────────────────────────────
        /// <summary>
        /// Returns all lost items ordered by most recent first.
        /// </summary>
        public DataTable GetAllLostItems()
        {
            return ExecuteQuery(
                "SELECT LostID, ReporterName, ItemName, " +
                "Description, Location, LostDate, Status " +
                "FROM LostItems ORDER BY LostID DESC");
        }

        // ── READ — get by status ─────────────────────────────────
        /// <summary>
        /// Returns lost items filtered by status.
        /// Status values: Pending, Matched, Claimed
        /// </summary>
        public DataTable GetByStatus(string status)
        {
            return ExecuteQuery(
                "SELECT LostID, ReporterName, ItemName, " +
                "Location, LostDate, Status " +
                "FROM LostItems WHERE Status=@status " +
                "ORDER BY LostID DESC",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@status", status)
                });
        }

        // ── READ — search by keyword ─────────────────────────────
        /// <summary>
        /// Searches LostItems by ItemName or Description.
        /// Uses parameterized LIKE query — no SQL injection risk.
        /// </summary>
        public DataTable SearchLostItems(string keyword)
        {
            return ExecuteQuery(
                "SELECT LostID, ReporterName, ItemName, " +
                "Location, LostDate, Status " +
                "FROM LostItems " +
                "WHERE ItemName LIKE @kw " +
                "OR Description LIKE @kw",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@kw", "%" + keyword + "%")
                });
        }

        // ── UPDATE — change status ───────────────────────────────
        /// <summary>
        /// Updates status of a lost item by ID.
        /// Called by frmUpdateStatus and frmSearch (matching).
        /// </summary>
        public bool UpdateStatus(int lostId, string newStatus)
        {
            int rows = ExecuteNonQuery(
                "UPDATE LostItems SET Status=@status " +
                "WHERE LostID=@id",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@status", newStatus),
                    new SQLiteParameter("@id",     lostId)
                });
            return rows > 0;
        }

        // ── DELETE — remove lost item ────────────────────────────
        /// <summary>
        /// Deletes lost item by ID.
        /// Returns true if deletion successful.
        /// </summary>
        public bool DeleteLostItem(int lostId)
        {
            int rows = ExecuteNonQuery(
                "DELETE FROM LostItems WHERE LostID=@id",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@id", lostId)
                });
            return rows > 0;
        }

        // ── COUNT — for dashboard ────────────────────────────────
        /// <summary>
        /// Returns count of lost items with given status.
        /// Used by Dashboard.LoadCounts() for live statistics.
        /// </summary>
        public int GetCountByStatus(string status)
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM LostItems " +
                "WHERE Status=@status",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@status", status)
                });
            return Convert.ToInt32(result);
        }
    }
}