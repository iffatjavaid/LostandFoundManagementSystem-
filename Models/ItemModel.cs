using System;

namespace IMFproject.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string ReporterName { get; set; }  
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }  
        public string status { get; set; }  
    }
}