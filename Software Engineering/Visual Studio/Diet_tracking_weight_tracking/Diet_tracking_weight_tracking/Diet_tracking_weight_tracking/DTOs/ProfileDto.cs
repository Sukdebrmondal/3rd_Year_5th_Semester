using System;
using Diet_tracking_weight_tracking.Models;

namespace Diet_tracking_weight_tracking.DTOs
{
    /// <summary>
   /// Data Transfer Object for Profile information
    /// </summary>
    public class ProfileDto
    {
     public string FullName { get; set; }
      public string PhoneNumber { get; set; }
      public DateTime DOB { get; set; }
  public Gender Gender { get; set; }
     public int HeightCm { get; set; }
     public double WeightKg { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
      public HealthGoal HealthGoal { get; set; }
    public double? TargetWeightKg { get; set; }
   public int WaterTargetMl { get; set; }
        public string ProfileImagePath { get; set; }
  }
}