using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Diet_tracking_weight_tracking.Models;

namespace Diet_tracking_weight_tracking.Services
{
  /// <summary>
    /// Simple food catalog service compatible with .NET Framework 4.7.2
    /// </summary>
    public static class FoodCatalogService
    {
        private static string FilePath => Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
        "DietTracker", 
     "food_catalog.txt");

    /// <summary>
/// Load food catalog from file or create with defaults
        /// </summary>
        public static List<FoodItem> LoadCatalog()
        {
            try
        {
   if (!File.Exists(FilePath))
   {
             var defaults = GetDefaultCatalog();
                SaveCatalog(defaults);
            return defaults;
         }

        var lines = File.ReadAllLines(FilePath);
           var items = new List<FoodItem>();
  
  foreach (var line in lines)
          {
   var parts = line.Split('|');
      if (parts.Length >= 4)
   {
  items.Add(new FoodItem
        {
       Id = int.Parse(parts[0]),
                 Name = parts[1],
   DefaultCaloriesPerServing = int.Parse(parts[2]),
       ServingDescription = parts[3]
        });
  }
        }
  
     return items.Any() ? items : GetDefaultCatalog();
         }
            catch
            {
             return GetDefaultCatalog();
         }
        }

        /// <summary>
      /// Save food catalog to file
        /// </summary>
        public static void SaveCatalog(List<FoodItem> items)
        {
    try
            {
          Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
        var lines = new List<string>();
     
          foreach (var item in items)
                {
           lines.Add($"{item.Id}|{item.Name}|{item.DefaultCaloriesPerServing}|{item.ServingDescription}");
     }
  
        File.WriteAllLines(FilePath, lines);
     }
    catch
   {
                // Ignore errors for simplicity
          }
   }

        /// <summary>
        /// Add a custom food item
        /// </summary>
        public static FoodItem AddCustomFood(string name, int calories, string servingDescription = "1 serving")
        {
       var catalog = LoadCatalog();
          var maxId = catalog.Any() ? catalog.Max(x => x.Id) : 0;
 
        var newItem = new FoodItem
        {
  Id = maxId + 1,
     Name = name?.Trim(),
          DefaultCaloriesPerServing = calories,
      ServingDescription = servingDescription,
 IsActive = true,
          CreatedAt = DateTime.UtcNow
     };
  
    catalog.Add(newItem);
   SaveCatalog(catalog);
      return newItem;
        }

        /// <summary>
        /// Get default food catalog items
        /// </summary>
        private static List<FoodItem> GetDefaultCatalog()
      {
return new List<FoodItem>
    {
new FoodItem { Id = 1, Name = "Rice", DefaultCaloriesPerServing = 200, ServingDescription = "1 cup cooked" },
    new FoodItem { Id = 2, Name = "Egg", DefaultCaloriesPerServing = 78, ServingDescription = "1 large" },
   new FoodItem { Id = 3, Name = "Milk", DefaultCaloriesPerServing = 150, ServingDescription = "1 cup" },
            new FoodItem { Id = 4, Name = "Fish", DefaultCaloriesPerServing = 200, ServingDescription = "100g" },
        new FoodItem { Id = 5, Name = "Potato", DefaultCaloriesPerServing = 160, ServingDescription = "1 medium" },
                new FoodItem { Id = 6, Name = "Butter", DefaultCaloriesPerServing = 102, ServingDescription = "1 tbsp" },
     new FoodItem { Id = 7, Name = "Bread", DefaultCaloriesPerServing = 80, ServingDescription = "1 slice" },
  new FoodItem { Id = 8, Name = "Apple", DefaultCaloriesPerServing = 95, ServingDescription = "1 medium" },
   new FoodItem { Id = 9, Name = "Yogurt", DefaultCaloriesPerServing = 59, ServingDescription = "100g" },
  new FoodItem { Id = 10, Name = "Chicken", DefaultCaloriesPerServing = 239, ServingDescription = "100g" }
    };
        }

     /// <summary>
        /// Get the catalog file path for debugging
        /// </summary>
        public static string GetCatalogFilePath()
        {
     return FilePath;
        }
    }
}