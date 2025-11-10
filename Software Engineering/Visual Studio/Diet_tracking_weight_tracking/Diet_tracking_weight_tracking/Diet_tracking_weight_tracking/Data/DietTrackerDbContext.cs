using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Diet_tracking_weight_tracking.Models;

namespace Diet_tracking_weight_tracking.Data
{
 /// <summary>
    /// Enhanced data context with file-based persistence
    /// Maintains compatibility with existing code while adding persistence
    /// </summary>
    public class DietTrackerDbContext : IDisposable
    {
        private static readonly object _lock = new object();
private static Dictionary<int, User> _users = new Dictionary<int, User>();
      private static Dictionary<int, Profile> _profiles = new Dictionary<int, Profile>();
        private static Dictionary<int, FoodItem> _foodItems = new Dictionary<int, FoodItem>();
        private static List<FoodEntry> _foodEntries = new List<FoodEntry>();
        private static List<WaterEntry> _waterEntries = new List<WaterEntry>();
  private static List<WeightEntry> _weightEntries = new List<WeightEntry>();
        
        private static int _userIdCounter = 1;
        private static int _profileIdCounter = 1;
    private static int _foodItemIdCounter = 1;
        private static int _foodEntryIdCounter = 1;
        private static int _waterEntryIdCounter = 1;
  private static int _weightEntryIdCounter = 1;

        private static bool _isInitialized = false;
 private static string _dataFilePath;

    static DietTrackerDbContext()
     {
        _dataFilePath = Path.Combine(AppPaths.AppDataFolder, "diettracker_data.txt");
     }

        public void EnsureCreated()
        {
            if (!_isInitialized)
   {
  lock (_lock)
         {
       if (!_isInitialized)
       {
       LoadData();
   _isInitialized = true;
      }
        }
         }
        }

        private void LoadData()
   {
   // Try to load from persistent file first
   if (LoadFromFile())
    {
         System.Diagnostics.Debug.WriteLine($"Data loaded from persistent file: {_dataFilePath}");
    }
        else
    {
     // Initialize with sample data if file doesn't exist
   if (_users.Count == 0)
      {
 CreateSampleData();
         SaveToFile(); // Save initial data
         System.Diagnostics.Debug.WriteLine($"Initial data created and saved to: {_dataFilePath}");
}
     }
        }

        private void CreateSampleData()
        {
            // Create sample food items
       var sampleFoods = new[]
            {
            new FoodItem { Id = _foodItemIdCounter++, Name = "Rice", DefaultCaloriesPerServing = 200, ServingDescription = "1 cup cooked" },
     new FoodItem { Id = _foodItemIdCounter++, Name = "Egg", DefaultCaloriesPerServing = 78, ServingDescription = "1 large" },
      new FoodItem { Id = _foodItemIdCounter++, Name = "Milk", DefaultCaloriesPerServing = 150, ServingDescription = "1 cup" },
         new FoodItem { Id = _foodItemIdCounter++, Name = "Fish", DefaultCaloriesPerServing = 200, ServingDescription = "100g" },
new FoodItem { Id = _foodItemIdCounter++, Name = "Potato", DefaultCaloriesPerServing = 160, ServingDescription = "1 medium" },
       new FoodItem { Id = _foodItemIdCounter++, Name = "Butter", DefaultCaloriesPerServing = 102, ServingDescription = "1 tbsp" },
     new FoodItem { Id = _foodItemIdCounter++, Name = "Bread", DefaultCaloriesPerServing = 80, ServingDescription = "1 slice" },
  new FoodItem { Id = _foodItemIdCounter++, Name = "Apple", DefaultCaloriesPerServing = 95, ServingDescription = "1 medium" }
 };

    foreach (var food in sampleFoods)
       {
   _foodItems[food.Id] = food;
   }
        }

     private bool LoadFromFile()
        {
         try
            {
    if (!File.Exists(_dataFilePath))
        return false;

            var lines = File.ReadAllLines(_dataFilePath);
            var currentSection = "";

    foreach (var line in lines)
     {
    if (line.StartsWith("[") && line.EndsWith("]"))
       {
     currentSection = line.Substring(1, line.Length - 2);
       continue;
        }

      if (string.IsNullOrWhiteSpace(line)) continue;

    switch (currentSection)
   {
       case "USERS":
        ParseUser(line);
      break;
         case "PROFILES":
   ParseProfile(line);
    break;
       case "FOODITEMS":
        ParseFoodItem(line);
        break;
       case "COUNTERS":
         ParseCounters(line);
      break;
        }
     }

 return true;
    }
         catch (Exception ex)
{
        System.Diagnostics.Debug.WriteLine($"Error loading data from file: {ex.Message}");
       return false;
      }
        }

        private void SaveToFile()
 {
    try
     {
     var lines = new List<string>();
        
       // Save users
      lines.Add("[USERS]");
   foreach (var user in _users.Values)
       {
lines.Add($"{user.Id}|{user.Username}|{user.PasswordHash}|{user.Email}|{user.CreatedAt:yyyy-MM-dd HH:mm:ss}");
 }

   // Save profiles
   lines.Add("[PROFILES]");
   foreach (var profile in _profiles.Values)
     {
       lines.Add($"{profile.Id}|{profile.UserId}|{profile.FullName}|{profile.PhoneNumber}|{profile.DOB:yyyy-MM-dd}|{(int)profile.Gender}|{profile.HeightCm}|{profile.WeightKg}|{(int)profile.ActivityLevel}|{(int)profile.HealthGoal}|{profile.TargetWeightKg}|{profile.WaterTargetMl}|{profile.ProfileImagePath}|{profile.UpdatedAt:yyyy-MM-dd HH:mm:ss}");
     }

     // Save food items
   lines.Add("[FOODITEMS]");
            foreach (var item in _foodItems.Values)
        {
     lines.Add($"{item.Id}|{item.Name}|{item.DefaultCaloriesPerServing}|{item.ServingDescription}");
      }

      // Save counters
      lines.Add("[COUNTERS]");
       lines.Add($"UserIdCounter|{_userIdCounter}");
    lines.Add($"ProfileIdCounter|{_profileIdCounter}");
    lines.Add($"FoodItemIdCounter|{_foodItemIdCounter}");
  lines.Add($"FoodEntryIdCounter|{_foodEntryIdCounter}");
      lines.Add($"WaterEntryIdCounter|{_waterEntryIdCounter}");
      lines.Add($"WeightEntryIdCounter|{_weightEntryIdCounter}");

      File.WriteAllLines(_dataFilePath, lines);
   System.Diagnostics.Debug.WriteLine($"Data saved to: {_dataFilePath}");
 }
   catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error saving data to file: {ex.Message}");
     }
        }

        private void ParseUser(string line)
     {
            var parts = line.Split('|');
      if (parts.Length >= 5)
    {
   var user = new User
  {
       Id = int.Parse(parts[0]),
    Username = parts[1],
 PasswordHash = parts[2],
    Email = parts[3],
     CreatedAt = DateTime.Parse(parts[4])
       };
   _users[user.Id] = user;
      if (user.Id >= _userIdCounter) _userIdCounter = user.Id + 1;
   }
        }

     private void ParseProfile(string line)
        {
     var parts = line.Split('|');
         if (parts.Length >= 14)
        {
     var profile = new Profile
     {
    Id = int.Parse(parts[0]),
  UserId = int.Parse(parts[1]),
     FullName = parts[2],
   PhoneNumber = parts[3],
    DOB = DateTime.Parse(parts[4]),
     Gender = (Gender)int.Parse(parts[5]),
    HeightCm = int.Parse(parts[6]),
WeightKg = double.Parse(parts[7]),
     ActivityLevel = (ActivityLevel)int.Parse(parts[8]),
      HealthGoal = (HealthGoal)int.Parse(parts[9]),
  TargetWeightKg = string.IsNullOrEmpty(parts[10]) ? (double?)null : double.Parse(parts[10]),
        WaterTargetMl = int.Parse(parts[11]),
            ProfileImagePath = parts[12],
     UpdatedAt = DateTime.Parse(parts[13])
        };
      _profiles[profile.Id] = profile;
       if (profile.Id >= _profileIdCounter) _profileIdCounter = profile.Id + 1;
     }
        }

        private void ParseFoodItem(string line)
        {
    var parts = line.Split('|');
       if (parts.Length >= 4)
     {
 var item = new FoodItem
       {
Id = int.Parse(parts[0]),
       Name = parts[1],
      DefaultCaloriesPerServing = int.Parse(parts[2]),
   ServingDescription = parts[3]
       };
      _foodItems[item.Id] = item;
           if (item.Id >= _foodItemIdCounter) _foodItemIdCounter = item.Id + 1;
    }
    }

     private void ParseCounters(string line)
  {
  var parts = line.Split('|');
     if (parts.Length >= 2)
     {
    switch (parts[0])
    {
        case "UserIdCounter": _userIdCounter = int.Parse(parts[1]); break;
    case "ProfileIdCounter": _profileIdCounter = int.Parse(parts[1]); break;
          case "FoodItemIdCounter": _foodItemIdCounter = int.Parse(parts[1]); break;
        case "FoodEntryIdCounter": _foodEntryIdCounter = int.Parse(parts[1]); break;
     case "WaterEntryIdCounter": _waterEntryIdCounter = int.Parse(parts[1]); break;
       case "WeightEntryIdCounter": _weightEntryIdCounter = int.Parse(parts[1]); break;
      }
    }
        }

     // User operations
        public User CreateUser(string username, string passwordHash, string email)
        {
lock (_lock)
      {
       var user = new User
    {
     Id = _userIdCounter++,
       Username = username,
     PasswordHash = passwordHash,
      Email = email,
    CreatedAt = DateTime.Now
      };
   _users[user.Id] = user;
       SaveToFile(); // Persist changes
    return user;
    }
        }

        public User GetUser(string username)
      {
       lock (_lock)
         {
     return _users.Values.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            }
        }

        public bool UserExists(string username, string email)
        {
  lock (_lock)
     {
    return _users.Values.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) || 
         u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
     }
    }

        // Profile operations
  public void SaveProfile(int userId, Profile profile)
        {
            lock (_lock)
     {
     var existing = _profiles.Values.FirstOrDefault(p => p.UserId == userId);
          if (existing != null)
        {
     // Update existing
        existing.FullName = profile.FullName;
    existing.PhoneNumber = profile.PhoneNumber;
      existing.DOB = profile.DOB;
       existing.Gender = profile.Gender;
        existing.HeightCm = profile.HeightCm;
         existing.WeightKg = profile.WeightKg;
   existing.ActivityLevel = profile.ActivityLevel;
  existing.HealthGoal = profile.HealthGoal;
        existing.TargetWeightKg = profile.TargetWeightKg;
       existing.WaterTargetMl = profile.WaterTargetMl;
         existing.ProfileImagePath = profile.ProfileImagePath;
existing.UpdatedAt = DateTime.Now;
      }
      else
      {
 // Create new
   profile.Id = _profileIdCounter++;
profile.UserId = userId;
         profile.UpdatedAt = DateTime.Now;
      _profiles[profile.Id] = profile;
  }
       SaveToFile(); // Persist changes
   }
        }

    public Profile GetProfile(int userId)
  {
      lock (_lock)
       {
         return _profiles.Values.FirstOrDefault(p => p.UserId == userId);
    }
        }

  // Food operations
        public List<FoodItem> GetFoodItems()
        {
  lock (_lock)
      {
      return _foodItems.Values.ToList();
        }
   }

        public FoodItem GetFoodItem(int id)
        {
      lock (_lock)
     {
    return _foodItems.ContainsKey(id) ? _foodItems[id] : null;
     }
     }

        // Food entry operations
        public void AddFoodEntry(FoodEntry entry)
 {
   lock (_lock)
     {
       entry.Id = _foodEntryIdCounter++;
      _foodEntries.Add(entry);
      SaveToFile(); // Persist changes
  }
}

        public List<FoodEntry> GetFoodEntries(int userId, DateTime date)
     {
   lock (_lock)
       {
     return _foodEntries.Where(e => e.UserId == userId && e.Timestamp.Date == date.Date).ToList();
   }
  }

public bool DeleteFoodEntry(int entryId)
      {
    lock (_lock)
      {
    var entry = _foodEntries.FirstOrDefault(e => e.Id == entryId);
   if (entry != null)
 {
        _foodEntries.Remove(entry);
       SaveToFile(); // Persist changes
     return true;
     }
       return false;
     }
        }

        // Water entry operations
 public void AddWaterEntry(WaterEntry entry)
   {
       lock (_lock)
         {
     entry.Id = _waterEntryIdCounter++;
   _waterEntries.Add(entry);
          SaveToFile(); // Persist changes
     }
        }

    public List<WaterEntry> GetWaterEntries(int userId, DateTime date)
        {
    lock (_lock)
   {
   return _waterEntries.Where(e => e.UserId == userId && e.Timestamp.Date == date.Date).ToList();
  }
        }

   public bool DeleteWaterEntry(int entryId)
        {
  lock (_lock)
          {
   var entry = _waterEntries.FirstOrDefault(e => e.Id == entryId);
   if (entry != null)
       {
_waterEntries.Remove(entry);
      SaveToFile(); // Persist changes
            return true;
  }
   return false;
      }
        }

      // Weight entry operations
        public void AddWeightEntry(WeightEntry entry)
        {
            lock (_lock)
        {
     entry.Id = _weightEntryIdCounter++;
   _weightEntries.Add(entry);
 
        // Update profile weight
      var profile = GetProfile(entry.UserId);
       if (profile != null)
   {
  profile.WeightKg = entry.WeightKg;
     profile.UpdatedAt = DateTime.Now;
          }
     SaveToFile(); // Persist changes
        }
        }

   public List<WeightEntry> GetWeightEntries(int userId, DateTime fromDate, DateTime toDate)
        {
 lock (_lock)
  {
     return _weightEntries.Where(e => e.UserId == userId && 
      e.Timestamp.Date >= fromDate.Date && 
        e.Timestamp.Date <= toDate.Date).ToList();
}
   }

        public bool DeleteWeightEntry(int entryId)
     {
     lock (_lock)
       {
   var entry = _weightEntries.FirstOrDefault(e => e.Id == entryId);
      if (entry != null)
 {
         _weightEntries.Remove(entry);
          
    // Update profile weight to most recent entry after deletion
    var userId = entry.UserId;
     var remainingEntries = _weightEntries.Where(e => e.UserId == userId)
     .OrderByDescending(e => e.Timestamp)
       .FirstOrDefault();
       var profile = GetProfile(userId);
            if (profile != null && remainingEntries != null)
      {
        profile.WeightKg = remainingEntries.WeightKg;
  profile.UpdatedAt = DateTime.Now;
         }
         
        SaveToFile(); // Persist changes
    return true;
     }
      return false;
  }
        }

        // Legacy methods for compatibility
     public void ExecuteNonQuery(string sql, params object[] parameters)
        {
    // No-op for compatibility
        }

 public object ExecuteScalar(string sql, params object[] parameters)
        {
        if (sql.Contains("COUNT(*) FROM Users"))
      return _users.Count;
      if (sql.Contains("COUNT(*) FROM FoodItems"))
         return _foodItems.Count;
     if (sql.Contains("last_insert_rowid()"))
         return _userIdCounter - 1;
       
  return 0;
        }

  public void Dispose()
    {
   // Save any pending changes on disposal
       SaveToFile();
        }
    }
}