# Diet Tracker Application

A comprehensive Windows Forms application for tracking daily food intake, water consumption, and weight management built for .NET Framework 4.7.2.

## Features

### Authentication
- User registration with profile setup
- Secure login with password hashing (SHA-256 with salt)
- Unique username and email validation

### Profile Management
- Complete health profile setup (height, weight, age, gender, activity level)
- Health goal selection (lose weight, maintain, gain weight)
- Automatic BMI, BMR, and TDEE calculations
- Daily calorie and water target recommendations

### Food Tracking
- Daily food entry logging
- Quick-add buttons for common foods (Rice, Egg, Milk, Fish, etc.)
- Food search and selection from database
- Calorie tracking with quantity adjustments
- Food entry history with timestamps

### Water Tracking
- Daily water intake logging
- Visual progress bar showing water goal completion
- Water entry history with timestamps
- Customizable daily water targets

### Weight Monitoring
- Weight entry logging
- Historical weight tracking
- BMI updates with weight changes
- Visual weight history display

### Dashboard
- Comprehensive overview of daily progress
- Real-time BMI display with color-coded categories
- Daily calorie and water targets vs. actual consumption
- Quick action buttons for easy logging

## Technology Stack

- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms
- **Database**: SQLite (via System.Data.SQLite)
- **Architecture**: Service-based with DTO pattern
- **Security**: SHA-256 password hashing with salt

## Database Schema

### Tables
- **Users**: Authentication and basic user info
- **Profiles**: Complete health and demographic data
- **FoodItems**: Catalog of food items with calorie information
- **FoodEntries**: User food consumption logs
- **WaterEntries**: User water consumption logs
- **WeightEntries**: User weight measurement logs

## Installation & Setup

### Prerequisites
- Windows 10 or later
- .NET Framework 4.7.2 or later
- Visual Studio 2019 or later (for development)

### Building the Application
1. Open the solution in Visual Studio
2. Restore NuGet packages (if any)
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

### First Run
On first run, the application will:
1. Create a SQLite database at `%AppData%\DietTracker\DietTracker.db`
2. Initialize database tables
3. Seed initial food items
4. Create a demo user account (username: "demo", password: "demo123")

## Usage Guide

### Getting Started
1. **Registration**: Create a new account with your email and basic information
2. **Profile Setup**: Complete your health profile (height, weight, goals, etc.)
3. **Dashboard**: Start logging your daily food and water intake

### Daily Tracking
- **Add Food**: Use quick-add buttons or search for specific foods
- **Log Water**: Enter water amounts and track toward your daily goal
- **Record Weight**: Log weight measurements to track progress over time

### Features Overview

#### BMI Calculation
- **Underweight**: BMI < 18.5 (Blue)
- **Normal**: BMI 18.5-24.9 (Green)
- **Overweight**: BMI 25-29.9 (Orange)
- **Obese**: BMI ? 30 (Red)

#### Calorie Targets
- **Lose Weight**: TDEE - 500 calories
- **Maintain Weight**: TDEE
- **Gain Weight**: TDEE + 300 calories

#### Activity Level Multipliers
- **Sedentary**: 1.2x BMR
- **Light**: 1.375x BMR
- **Moderate**: 1.55x BMR
- **Active**: 1.725x BMR
- **Very Active**: 1.9x BMR

## Customization

### Adding New Food Items
Edit the `DatabaseInitializer.SeedFoodItems` method to add new food items:

```csharp
context.ExecuteNonQuery(@"
    INSERT INTO FoodItems (Name, DefaultCaloriesPerServing, ServingDescription) 
    VALUES ('New Food', 150, '1 serving')
");
```

### Modifying Quick-Add Buttons
Update the `quickFoods` array in `DashboardForm.SetupQuickAddButtons`:

```csharp
string[] quickFoods = { "Rice", "Egg", "Milk", "Fish", "Potato", "Butter", "Bread", "Apple", "Chicken" };
```

## Data Storage

### Database Location
- **Path**: `%AppData%\DietTracker\DietTracker.db`
- **Type**: SQLite database file
- **Backup**: Copy the .db file to backup user data

### Data Export
User data can be exported by accessing the SQLite database directly or extending the EntryService with export methods.

## Security Features

- Password hashing using SHA-256 with application-specific salt
- Input validation for all user inputs
- SQL injection prevention through parameterized queries
- User session management

## Known Limitations

1. **Charts**: Advanced charting features are planned for future versions
2. **Food Database**: Limited initial food database (can be expanded)
3. **Offline Only**: No cloud synchronization (local database only)
4. **Single User**: Designed for single-user desktop use

## Future Enhancements

- Advanced charting and visualization
- Food nutrition tracking (macros, vitamins, etc.)
- Export functionality (CSV, PDF)
- Exercise tracking integration
- Cloud backup and synchronization
- Mobile companion app

## Demo Account

For testing purposes, a demo account is automatically created:
- **Username**: demo
- **Password**: demo123
- **Profile**: Pre-configured with sample data

## Support

For issues or feature requests, please:
1. Check the demo account functionality
2. Verify database file permissions
3. Ensure .NET Framework 4.7.2 is installed
4. Review error logs in the application

## License

This application is provided as-is for educational and personal use.

---

**Built with ?? using Windows Forms and .NET Framework**