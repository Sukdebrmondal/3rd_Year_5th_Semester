using System;

namespace Diet_tracking_weight_tracking.DTOs
{
/// <summary>
    /// Data Transfer Object for Food Entry information
    /// </summary>
    public class FoodEntryDto
  {
        public int Id { get; set; }
        public int? FoodItemId { get; set; }
    public string FoodName { get; set; }
     public int Calories { get; set; }
   public double Quantity { get; set; }
      public DateTime Timestamp { get; set; }
  public string Note { get; set; }
    }
}