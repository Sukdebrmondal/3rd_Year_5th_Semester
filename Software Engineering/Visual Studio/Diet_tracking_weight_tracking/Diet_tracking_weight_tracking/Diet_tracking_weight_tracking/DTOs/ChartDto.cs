namespace Diet_tracking_weight_tracking.DTOs
{
    /// <summary>
    /// DTO for grouped calorie data used in pie chart
    /// </summary>
    public class GroupedCaloriesDto
    {
        public string Food { get; set; }
     public int Calories { get; set; }
     public double Percentage { get; set; }
    }

    /// <summary>
/// DTO for weight chart data
    /// </summary>
    public class WeightChartDto
    {
        public System.DateTime Timestamp { get; set; }
        public double WeightKg { get; set; }
    }
}