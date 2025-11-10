using System;

namespace Diet_tracking_weight_tracking.Models
{
    /// <summary>
    /// Gender enumeration for user profiles
    /// </summary>
    public enum Gender
    {
        Male,
        Female,
     Other
    }

    /// <summary>
    /// Activity level enumeration for calculating TDEE
    /// </summary>
    public enum ActivityLevel
    {
        Sedentary,      // 1.2
    Light,          // 1.375
        Moderate,       // 1.55
        Active,       // 1.725
        VeryActive      // 1.9
    }

    /// <summary>
    /// Health goal enumeration for determining calorie targets
    /// </summary>
    public enum HealthGoal
  {
        LoseWeight,
        Maintain,
        GainWeight
    }

    /// <summary>
    /// BMI category enumeration
    /// </summary>
    public enum BMICategory
    {
  Underweight,
      Normal,
      Overweight,
   Obese
    }
}