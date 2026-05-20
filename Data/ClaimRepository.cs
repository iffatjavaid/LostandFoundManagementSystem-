using System;
using System.Data;
using System.Data.SQLite;
using IMFproject.Models;

namespace IMFproject.Database
{
    /// <summary>
    /// Handles all database operations for the ClaimRecord table.
    /// Records are created when items are matched or claimed.
    /// </summary>
    public class ClaimRepository : BaseRepository
    {
        // ── CREATE — add new claim record ────────────────────────
        /// <summary>
        /// Inserts new record into ClaimRecord table.
        /// Called by frmSearch when items are matched and
        /// by frmUpdateStatus when item is claimed by owner.
        /// </summary>
        public bool AddClaim(ClaimModel claim)
        {
            int rows = ExecuteNonQuery(
                @"INSERT INTO ClaimRecord
                  (LostID, FoundID, ClaimedbyName,
                   ClaimDate, Remarks)
                  VALUES
                  (@lid, @fid, @cname, @date, @remarks)",
                new SQLiteParameter[]
                {
                    new SQLiteParameter("@lid",
                        claim.LostId),
                    new SQLiteParameter("@fid",
                        claim.FoundId),
                    new SQLiteParameter("@cname",
                        claim.ClaimedByName),
                    new SQLiteParameter("@date",
                        claim.ClaimDate.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@remarks",
                        claim.Remarks)
                });
            return rows > 0;
        }

        // ── READ — get all claim records ─────────────────────────
        /// <summary>
        /// Returns all claim records joined with item names
        /// from LostItems and FoundItems tables.
        /// </summary>
        public DataTable GetAllClaims()
        {
            return ExecuteQuery(
                "SELECT C.ClaimID, " +
                "L.ItemName as LostItem, " +
                "F.ItemName as FoundItem, " +
                "C.ClaimedbyName, C.ClaimDate, C.Remarks " +
                "FROM ClaimRecord C " +
                "LEFT JOIN LostItems L ON C.LostID = L.LostID " +
                "LEFT JOIN FoundItems F ON C.FoundID = F.FoundID " +
                "ORDER BY C.ClaimID DESC");
        }

        // ── READ — get count ─────────────────────────────────────
        public int GetTotalClaims()
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM ClaimRecord");
            return Convert.ToInt32(result);
        }
    }
}