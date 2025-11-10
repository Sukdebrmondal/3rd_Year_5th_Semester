using System;

namespace Diet_tracking_weight_tracking.Models
{
    /// <summary>
    /// User profile entity containing health and demographic information
    /// </summary>
    public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int HeightCm { get; set; }
        public double WeightKg { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public HealthGoal HealthGoal { get; set; }
        public double? TargetWeightKg { get; set; }
        public int WaterTargetMl { get; set; } = 2000;
        public string ProfileImagePath { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign key relationship
        public virtual User User { get; set; }

        /// <summary>
        /// Calculate BMI from current height and weight
        /// </summary>
        public double CalculateBMI()
        {
            double heightM = HeightCm / 100.0;
            return WeightKg / (heightM * heightM);
        }

        /// <summary>
        /// Get BMI category based on calculated BMI
        /// </summary>
        public BMICategory GetBMICategory()
        {
            double bmi = CalculateBMI();
            if (bmi < 18.5) return BMICategory.Underweight;
            if (bmi < 25) return BMICategory.Normal;
            if (bmi < 30) return BMICategory.Overweight;
            return BMICategory.Obese;
        }

        /// <summary>
        /// Calculate age from date of birth
        /// </summary>
        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DOB.Year;
            if (DOB.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}