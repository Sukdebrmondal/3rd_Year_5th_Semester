using System;
using System.IO;

namespace Diet_tracking_weight_tracking.Services
{
    /// <summary>
  /// Simple credentials data structure
   /// </summary>
    public class SimpleCredentials
{
        public string Username { get; set; }
  public string Password { get; set; }
    }

    /// <summary>
  /// Simple credential store that uses plaintext file for persistence
    /// Compatible with .NET Framework 4.7.2
    /// </summary>
    public static class SimpleCredStore
    {
     private static string AppFolder => Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DietTracker");

        public static string CredFilePath
        {
   get
          {
     Directory.CreateDirectory(AppFolder); // ensure folder exists
return Path.Combine(AppFolder, "credentials.txt");
     }
        }

        /// <summary>
 /// Load credentials from disk. If file doesn't exist, return default admin/admin.
   /// </summary>
/// <returns>Stored credentials or default admin/admin</returns>
      public static SimpleCredentials LoadCredentials()
        {
   try
 {
    var path = CredFilePath;
 if (!File.Exists(path))
  {
       // default credentials
     System.Diagnostics.Debug.WriteLine("Credentials file not found, using default admin/admin");
  return new SimpleCredentials { Username = "admin", Password = "admin" };
     }

  var lines = File.ReadAllLines(path);
   if (lines.Length < 2)
     {
         System.Diagnostics.Debug.WriteLine("Credentials file invalid format, using default admin/admin");
           return new SimpleCredentials { Username = "admin", Password = "admin" };
    }

      var username = lines[0]?.Trim();
       var password = lines.Length > 1 ? lines[1] : "";
       
       if (string.IsNullOrEmpty(username) || password == null)
           {
  System.Diagnostics.Debug.WriteLine("Invalid credentials in file, using default admin/admin");
     return new SimpleCredentials { Username = "admin", Password = "admin" };
         }

 System.Diagnostics.Debug.WriteLine($"Loaded credentials for user: {username}");
      return new SimpleCredentials { Username = username, Password = password };
    }
        catch (Exception ex)
    {
  // on any error fall back to default
   System.Diagnostics.Debug.WriteLine($"Error loading credentials: {ex.Message}, using default admin/admin");
   return new SimpleCredentials { Username = "admin", Password = "admin" };
            }
   }

 /// <summary>
        /// Save credentials (overwrites file). This stores plain text username/password.
   /// </summary>
/// <param name="creds">Credentials to save</param>
    public static void SaveCredentials(SimpleCredentials creds)
  {
     if (creds == null) return;
            try
{
         var path = CredFilePath;
      var lines = new string[] { creds.Username, creds.Password };
           File.WriteAllLines(path, lines);
  System.Diagnostics.Debug.WriteLine($"Saved credentials for user: {creds.Username} to {path}");
    }
            catch (Exception ex)
            {
  System.Diagnostics.Debug.WriteLine($"Error saving credentials: {ex.Message}");
   }
        }

        /// <summary>
        /// Register a new user (overwrites existing credentials)
        /// </summary>
      /// <param name="username">New username</param>
        /// <param name="password">New password</param>
    /// <returns>True if registration successful</returns>
        public static bool RegisterUser(string username, string password)
{
     if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
 return false;

  var creds = new SimpleCredentials { Username = username.Trim(), Password = password };
   SaveCredentials(creds);
   return true;
        }

     /// <summary>
      /// Authenticate user against stored credentials
   /// </summary>
        /// <param name="username">Username to check</param>
/// <param name="password">Password to check</param>
   /// <returns>True if credentials match</returns>
        public static bool AuthenticateUser(string username, string password)
        {
  if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
 return false;

      var stored = LoadCredentials();
       if (stored == null)
     return false;

            // Compare exactly (case-sensitive)
            bool isValid = stored.Username == username.Trim() && stored.Password == password;
        System.Diagnostics.Debug.WriteLine($"Authentication for {username}: {(isValid ? "SUCCESS" : "FAILED")}");
  return isValid;
      }

  /// <summary>
  /// Get current stored username (for display purposes)
        /// </summary>
   /// <returns>Current username or "admin" if none set</returns>
   public static string GetCurrentUsername()
        {
        var stored = LoadCredentials();
            return stored?.Username ?? "admin";
     }

        /// <summary>
        /// Get diagnostic information about the credential system
        /// </summary>
        /// <returns>String with credential file info</returns>
        public static string GetCredentialInfo()
        {
    var path = CredFilePath;
         var exists = File.Exists(path);
  var creds = LoadCredentials();
        
return $"File: {path}\nExists: {exists}\nCurrent User: {creds.Username}\nPassword Length: {creds.Password?.Length ?? 0}";
     }
    }
}