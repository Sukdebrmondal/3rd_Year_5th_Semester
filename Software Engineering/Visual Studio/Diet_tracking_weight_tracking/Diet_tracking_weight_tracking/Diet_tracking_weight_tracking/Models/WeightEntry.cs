using System;

namespace Diet_tracking_weight_tracking.Models
{
    /// <summary>
    /// Weight entry entity for tracking weight changes over time
    /// </summary>
    public class WeightEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double WeightKg { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        // Foreign key relationship
        public virtual User User { get; set; }
    }
}