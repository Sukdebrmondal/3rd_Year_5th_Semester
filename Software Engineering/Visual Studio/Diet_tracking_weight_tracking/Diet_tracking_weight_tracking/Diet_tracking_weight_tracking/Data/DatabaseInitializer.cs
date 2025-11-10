using System;
using Diet_tracking_weight_tracking.Data;
using Diet_tracking_weight_tracking.Models;
using Diet_tracking_weight_tracking.Services;

namespace Diet_tracking_weight_tracking.Data
{
    /// <summary>
    /// Database initializer that creates tables and seeds initial data
    /// </summary>
 public static class DatabaseInitializer
    {
/// <summary>
 /// Initialize the database with tables and seed data
 /// </summary>
   public static void Initialize()
    {
            using (var context = new DietTrackerDbContext())
     {
   context.EnsureCreated();
    SeedSampleData();
   }
     }

    /// <summary>
 /// Seed sample data for demonstration
      /// </summary>
   private static void SeedSampleData()
        {
    using (var context = new DietTrackerDbContext())
          {
            context.EnsureCreated();

   // Check if users already exist
      var userCount = context.ExecuteScalar("SELECT COUNT(*) FROM Users");
          if (Convert.ToInt32(userCount) > 0) return;

      // Create a sample user with properly hashed password
       var passwordHash = PasswordHelper.HashPassword("demo123");

  var user = context.CreateUser("demo", passwordHash, "demo@example.com");

    // Create sample profile
   var profile = new Profile
     {
       FullName = "Demo User",
  PhoneNumber = "1234567890",
      DOB = new DateTime(1990, 1, 1),
 Gender = Gender.Male,
       HeightCm = 175,
        WeightKg = 70,
     ActivityLevel = ActivityLevel.Moderate,
      HealthGoal = HealthGoal.Maintain,
    TargetWeightKg = 70,
  WaterTargetMl = 2000
     };

   context.SaveProfile(user.Id, profile);

        System.Diagnostics.Debug.WriteLine("Sample data seeded successfully");
 }
    }
    }
}