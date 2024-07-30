﻿namespace GPB.Domain.Entity
{
    public class EntryExit
    {
        public int EntryExitId { get; set; } 
        public int ReservationId { get; set; } 
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; } 
        public string Status { get; set; } 
        public DateTime CreationDate { get; set; } 
        public DateTime UpdateDate { get; set; } 
    }
}