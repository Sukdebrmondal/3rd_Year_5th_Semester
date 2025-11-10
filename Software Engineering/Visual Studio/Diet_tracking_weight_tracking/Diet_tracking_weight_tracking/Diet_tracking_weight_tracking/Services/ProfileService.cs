using System;
using System.Threading.Tasks;
using Diet_tracking_weight_tracking.Data;
using Diet_tracking_weight_tracking.DTOs;
using Diet_tracking_weight_tracking.Models;

namespace Diet_tracking_weight_tracking.Services
{
 /// <summary>
    /// Service for user profile management and health calculations
    /// </summary>
    public class ProfileService
    {
        /// <summary>
        /// Save or update user profile information
        /// </summary>
public async Task SaveProfileAsync(int userId, ProfileDto dto)
        {
     await Task.Run(() => SaveProfile(userId, dto));
        }

  /// <summary>
        /// Save or update user profile information (synchronous)
        /// </summary>
        public void SaveProfile(int userId, ProfileDto dto)
        {
      using (var context = new DietTrackerDbContext())
     {
      context.EnsureCreated();
     
   var profile = new Profile
      {
        FullName = dto.FullName,
      PhoneNumber = dto.PhoneNumber,
   DOB = dto.DOB,
     Gender = dto.Gender,
   HeightCm = dto.HeightCm,
  WeightKg = dto.WeightKg,
        ActivityLevel = dto.ActivityLevel,
    HealthGoal = dto.HealthGoal,
    TargetWeightKg = dto.TargetWeightKg,
     WaterTargetMl = dto.WaterTargetMl,
   ProfileImagePath = dto.ProfileImagePath
        };
      
       context.SaveProfile(userId, profile);
  }
        }

        /// <summary>
      /// Get user profile information
     /// </summary>
   public async Task<ProfileDto> GetProfileAsync(int userId)
  {
   return await Task.Run(() =>
{
      using (var context = new DietTrackerDbContext())
         {
            context.EnsureCreated();
      
    var profile = context.GetProfile(userId);
    if (profile != null)
         {
        return new ProfileDto
       {
        FullName = profile.FullName,
       PhoneNumber = profile.PhoneNumber,
     DOB = profile.DOB,
   Gender = profile.Gender,
    HeightCm = profile.HeightCm,
  WeightKg = profile.WeightKg,
       ActivityLevel = profile.ActivityLevel,
     HealthGoal = profile.HealthGoal,
      TargetWeightKg = profile.TargetWeightKg,
      WaterTargetMl = profile.WaterTargetMl,
    ProfileImagePath = profile.ProfileImagePath
 };
        }

     return null;
      }
 });
        }

   /// <summary>
  /// Calculate BMI from height and weight
        /// </summary>
        public double CalculateBMI(double weightKg, int heightCm)
        {
  double heightM = heightCm / 100.0;
          return weightKg / (heightM * heightM);
        }

/// <summary>
        /// Calculate BMR (Basal Metabolic Rate) and TDEE (Total Daily Energy Expenditure)
        /// </summary>
      public (double bmr, double tdee) CalculateBmrTdee(ProfileDto profile)
     {
int age = CalculateAge(profile.DOB);
  double bmr;

            // Mifflin-St Jeor Equation
     if (profile.Gender == Gender.Male)
        {
     bmr = 10 * profile.WeightKg + 6.25 * profile.HeightCm - 5 * age + 5;
        }
     else
        {
      bmr = 10 * profile.WeightKg + 6.25 * profile.HeightCm - 5 * age - 161;
        }

     // Activity factor
       double activityFactor = GetActivityFactor(profile.ActivityLevel);
       double tdee = bmr * activityFactor;

     return (bmr, tdee);
        }

        /// <summary>
   /// Get daily calorie target based on health goal and TDEE
     /// </summary>
        public int GetDailyCalorieTarget(ProfileDto profile)
        {
     var (bmr, tdee) = CalculateBmrTdee(profile);

  switch (profile.HealthGoal)
        {
        case HealthGoal.LoseWeight:
       return (int)(tdee - 500); // 500 calorie deficit for ~1 lb/week loss
            case HealthGoal.GainWeight:
    return (int)(tdee + 300); // 300 calorie surplus for gradual gain
  case HealthGoal.Maintain:
      default:
     return (int)tdee;
    }
  }

     /// <summary>
        /// Calculate age from date of birth
    /// </summary>
        private int CalculateAge(DateTime dob)
 {
       var today = DateTime.Today;
     var age = today.Year - dob.Year;
  if (dob.Date > today.AddYears(-age)) age--;
  return age;
        }

        /// <summary>
        /// Get activity factor for TDEE calculation
        /// </summary>
     private double GetActivityFactor(ActivityLevel activityLevel)
        {
     switch (activityLevel)
        {
case ActivityLevel.Sedentary:
      return 1.2;
       case ActivityLevel.Light:
 return 1.375;
      case ActivityLevel.Moderate:
       return 1.55;
        case ActivityLevel.Active:
        return 1.725;
    case ActivityLevel.VeryActive:
    return 1.9;
      default:
      return 1.55;
     }
     }
    }
}