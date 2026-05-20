using System;
//Model layer for item track
namespace IMFproject.Models
{
    public class ClaimModel
    {
        public int ClaimId { get; set; } 
        public int LostId { get; set; }  
        public int FoundId { get; set; } 
        public string ClaimedByName { get; set; } 
        public DateTime ClaimDate { get; set; }  
        public string Remarks { get; set; }  
    }
}