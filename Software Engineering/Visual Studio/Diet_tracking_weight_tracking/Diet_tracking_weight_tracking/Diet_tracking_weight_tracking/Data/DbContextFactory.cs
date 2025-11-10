using System;
using System.Diagnostics;
using System.IO;

namespace Diet_tracking_weight_tracking.Data
{
    /// <summary>
    /// Factory for creating DbContext instances with consistent configuration
    /// </summary>
    public static class DbContextFactory
    {
        /// <summary>
        /// Creates a new persistent DbContext instance using the original in-memory context
        /// Updated to use the working DietTrackerDbContext
        /// </summary>
        /// <returns>Configured DbContext instance</returns>
        public static DietTrackerDbContext CreateContext()
        {
            try
            {
                var context = new DietTrackerDbContext();
                context.EnsureCreated();

                Debug.WriteLine($"DbContext created successfully. Using original DietTrackerDbContext");
                return context;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to create DbContext: {ex.Message}");
                throw new InvalidOperationException($"Failed to initialize database: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Initializes the database at application startup
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                Debug.WriteLine("Initializing database...");
                Debug.WriteLine(AppPaths.GetDatabaseInfo());

                using (var context = CreateContext())
                {
                    // Database is initialized in CreateContext()
                    var userCount = context.ExecuteScalar("SELECT COUNT(*) FROM Users");
                    var foodItemCount = context.ExecuteScalar("SELECT COUNT(*) FROM FoodItems");

                    Debug.WriteLine($"Database initialized successfully:");
                    Debug.WriteLine($"  - Users: {userCount}");
                    Debug.WriteLine($"  - Food Items: {foodItemCount}");
                    Debug.WriteLine($"  - Using original DietTrackerDbContext");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Database initialization failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Reports current database status for debugging
        /// </summary>
        public static void ReportDatabaseStatus()
        {
            try
            {
                Debug.WriteLine("=== Database Status Report ===");
                Debug.WriteLine(AppPaths.GetDatabaseInfo());

                using (var context = CreateContext())
                {
                    var userCount = context.ExecuteScalar("SELECT COUNT(*) FROM Users");
                    var foodItemCount = context.ExecuteScalar("SELECT COUNT(*) FROM FoodItems");

                    Debug.WriteLine($"Users in database: {userCount}");
                    Debug.WriteLine($"Food items in database: {foodItemCount}");
                    Debug.WriteLine($"Using original DietTrackerDbContext");
                }

                Debug.WriteLine("=== End Database Status ===");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reporting database status: {ex.Message}");
            }
        }
    }
}