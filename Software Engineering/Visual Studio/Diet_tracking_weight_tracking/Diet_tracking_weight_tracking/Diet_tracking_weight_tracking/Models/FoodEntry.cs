using System;

namespace Diet_tracking_weight_tracking.Models
{
    /// <summary>
    /// Food entry entity for tracking daily food consumption
    /// </summary>
    public class FoodEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? FoodItemId { get; set; }
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public double Quantity { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Note { get; set; }

        // Navigation properties (not used in simplified version)
        public virtual User User { get; set; }
        public virtual FoodItem FoodItem { get; set; }
    }
}