using System;

namespace Diet_tracking_weight_tracking.DTOs
{
    /// <summary>
    /// Data Transfer Object for Weight Entry information
    /// </summary>
    public class WeightEntryDto
    {
        public int Id { get; set; }
        public double WeightKg { get; set; }
        public DateTime Timestamp { get; set; }
    }
}