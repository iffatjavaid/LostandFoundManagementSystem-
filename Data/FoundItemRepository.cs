using System;
using System.Data;
using System.Data.SQLite;
using IMFproject.Models;

namespace IMFproject.Database
{
    /// <summary>
    /// Handles all database operations for the FoundItems table.
    /// Includes CRUD operations and status management.
    /// </summary>
    public class FoundItemRepository : BaseRepository
    {
        // ── CREATE — add new found item ──────────────────────────
        /// <summary>
        /// Inserts new found item into FoundItems table.
        /// Status automatically set to Available on creation.
        /// </summary>
        public bool AddFoundItem(ItemModel item, string foundByName)
        {
            int rows = ExecuteNonQuery(
                @"INSERT INTO FoundItems
                  (FoundbyName, ItemName, Description,
                   FoundDate, Location, Status)
                  VALUES
                  (@name, @item, @desc, @date, @loc, @status)",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@name",   foundByName),
                    new SQLiteParameter("@item",   item.ItemName),
                    new SQLiteParameter("@desc",   item.Description),
                    new SQLiteParameter("@date",
                        item.Date.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@loc",    item.Location),
                    new SQLiteParameter("@status", "Available")
                });
            return rows > 0;
        }

        // ── READ — get all found items ───────────────────────────
        public DataTable GetAllFoundItems()
        {
            return ExecuteQuery(
                "SELECT FoundID, FoundbyName, ItemName, " +
                "Description, Location, FoundDate, Status " +
                "FROM FoundItems ORDER BY FoundID DESC");
        }

        // ── READ — get by status ─────────────────────────────────
        /// <summary>
        /// Returns found items filtered by status.
        /// Status values: Available, Matched, Claimed
        /// </summary>
        public DataTable GetByStatus(string status)
        {
            return ExecuteQuery(
                "SELECT FoundID, FoundbyName, ItemName, " +
                "Location, FoundDate, Status " +
                "FROM FoundItems WHERE Status=@status " +
                "ORDER BY FoundID DESC",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@status", status)
                });
        }

        // ── READ — search by keyword ─────────────────────────────
        /// <summary>
        /// Searches FoundItems by ItemName or Description.
        /// Parameterized query prevents SQL injection.
        /// </summary>
        public DataTable SearchFoundItems(string keyword)
        {
            return ExecuteQuery(
                "SELECT FoundID, FoundbyName, ItemName, " +
                "Location, FoundDate, Status " +
                "FROM FoundItems " +
                "WHERE ItemName LIKE @kw " +
                "OR Description LIKE @kw",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@kw", "%" + keyword + "%")
                });
        }

        // ── UPDATE — change status ───────────────────────────────
        public bool UpdateStatus(int foundId, string newStatus)
        {
            int rows = ExecuteNonQuery(
                "UPDATE FoundItems SET Status=@status " +
                "WHERE FoundID=@id",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@status", newStatus),
                    new SQLiteParameter("@id",     foundId)
                });
            return rows > 0;
        }

        // ── DELETE — remove found item ───────────────────────────
        public bool DeleteFoundItem(int foundId)
        {
            int rows = ExecuteNonQuery(
                "DELETE FROM FoundItems WHERE FoundID=@id",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@id", foundId)
                });
            return rows > 0;
        }

        // ── COUNT — for dashboard ────────────────────────────────
        public int GetCountByStatus(string status)
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM FoundItems " +
                "WHERE Status=@status",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@status", status)
                });
            return Convert.ToInt32(result);
        }
    }
}