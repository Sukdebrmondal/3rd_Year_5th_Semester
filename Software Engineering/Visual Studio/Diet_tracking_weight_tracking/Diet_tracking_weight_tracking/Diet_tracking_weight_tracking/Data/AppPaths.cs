using System;
using System.IO;

namespace Diet_tracking_weight_tracking.Data
{
    /// <summary>
    /// Configuration helper for application paths and database connection
    /// </summary>
    public static class AppPaths
 {
        /// <summary>
    /// Gets the application data folder path
  /// </summary>
        public static string AppDataFolder
        {
            get
      {
      var folder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
             "DietTracker");
    Directory.CreateDirectory(folder);
        return folder;
     }
        }

        /// <summary>
        /// Gets the SQLite database file path
    /// </summary>
        public static string DbFilePath
        {
 get
            {
     return Path.Combine(AppDataFolder, "diettracker.db");
    }
        }

        /// <summary>
        /// Gets the SQLite connection string for persistent storage
     /// </summary>
        /// <returns>Connection string pointing to the persistent database file</returns>
        public static string GetSqliteConnectionString()
   {
            return $"Data Source={DbFilePath};Cache=Shared;";
        }

        /// <summary>
        /// Gets diagnostic information about the database setup
    /// </summary>
    /// <returns>String with database path and status information</returns>
        public static string GetDatabaseInfo()
        {
var dbPath = DbFilePath;
            var exists = File.Exists(dbPath);
            var size = exists ? new FileInfo(dbPath).Length : 0;
 
            return $"Database Path: {dbPath}\nExists: {exists}\nSize: {size} bytes";
        }
    }
}