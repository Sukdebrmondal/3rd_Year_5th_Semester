# Diet Tracker Application - Complete Implementation

A comprehensive Windows Forms application for tracking daily food intake, water consumption, and weight management built for .NET Framework 4.7.2 with custom charting functionality.

## Features

### Authentication & Profile Management
- ? User registration with secure password hashing (SHA-256 with salt)
- ? Login system with credential validation
- ? Complete health profile setup (height, weight, age, gender, activity level)
- ? Automatic BMI, BMR, and TDEE calculations
- ? Health goal selection (lose/maintain/gain weight)

### Food Tracking with Visual Charts
- ? **Custom Pie Chart** - Shows daily calorie distribution by food type
- ? Daily food entry logging with pre-defined food database
- ? Quick-add buttons for common foods (Rice, Egg, Milk, Fish, etc.)
- ? Food search and selection with portion quantity adjustment
- ? Real-time chart updates when adding/deleting food entries
- ? Automatic grouping of small items (<3%) into "Other" category
- ? Interactive tooltips and percentage labels

### Weight Monitoring with Trend Analysis
- ? **Custom Line Chart** - Shows weight history over time
- ? Weight entry logging with automatic BMI updates
- ? Historical weight tracking (last 30 days default)
- ? Visual trend indicators and data points
- ? Automatic chart scaling and axis formatting

### Water Tracking
- ? Daily water intake logging with target tracking
- ? Visual progress bar showing goal completion
- ? Water entry history with timestamps
- ? Customizable daily water targets

### Dashboard & Real-time Updates
- ? Comprehensive overview with live BMI display
- ? Color-coded BMI categories (Normal/Underweight/Overweight/Obese)
- ? Daily calorie and water targets vs. actual consumption
- ? **Auto-refreshing charts** when data changes
- ? Thread-safe chart updates using proper UI threading

## Technology Stack

- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms with custom GDI+ charting
- **Data Storage**: In-memory collections with file persistence
- **Architecture**: Service-based with DTO pattern
- **Security**: SHA-256 password hashing with application salt
- **Charts**: Custom implementations using Graphics/GDI+ drawing

## Custom Chart Implementation

Since .NET Framework 4.7.2 doesn't include `System.Windows.Forms.DataVisualization.Charting` by default, this application implements **custom chart controls** using GDI+ drawing:

### Pie Chart Features
- **Visual Elements**: Gradient colors, percentage labels, interactive legend
- **Data Grouping**: Small items automatically grouped under "Other"
- **Real-time Updates**: Charts refresh immediately when food entries change
- **Error Handling**: Graceful fallback for missing data

### Line Chart Features
- **Time-series Display**: X-axis shows dates, Y-axis shows weight
- **Visual Enhancements**: Grid lines, data point markers, trend visualization
- **Auto-scaling**: Automatic axis range calculation with padding
- **Responsive Design**: Adapts to different date ranges

## Chart Integration Examples

### Updating Charts After Data Changes

```csharp
// After adding a food entry
private async void btnAddFood_Click(object sender, EventArgs e)
{
    await AddFoodEntry(food, quantity);
    await OnFoodEntryAddedAsync(); // Triggers chart update
}

private async Task OnFoodEntryAddedAsync()
{
    await RefreshFoodEntries();
    await UpdateCaloriesPieChartAsync(DateTime.Today); // Updates pie chart
}

// After logging weight
private async void btnAddWeight_Click(object sender, EventArgs e)
{
    await _entryService.AddWeightEntryAsync(_user.Id, weight);
await OnWeightEntryAddedAsync(); // Triggers chart update
}

private async Task OnWeightEntryAddedAsync()
{
    await UpdateHeaderStats(); // BMI might change
    await UpdateWeightLineChartAsync(DateTime.Today.AddDays(-30), DateTime.Today);
}
```

### Chart Update Methods

```csharp
// Pie chart for calorie distribution
public async Task UpdateCaloriesPieChartAsync(DateTime date)
{
    // Fetch data off UI thread
    var groupedEntries = await Task.Run(() => {
 // Database operations in background
        return GetGroupedCaloriesForDate(date);
    });

    // Update UI on main thread
    if (this.InvokeRequired)
        this.BeginInvoke(new Action(() => 
     UpdateCaloriesPieChartInternal(groupedEntries, date)));
    else
        UpdateCaloriesPieChartInternal(groupedEntries, date);
}

// Line chart for weight history
public async Task UpdateWeightLineChartAsync(DateTime fromDate, DateTime toDate)
{
    var weightEntries = await Task.Run(() => GetWeightHistory(fromDate, toDate));
    
    if (this.InvokeRequired)
        this.BeginInvoke(new Action(() => 
    SimpleChartHelpers.DrawLineChart(picWeight, weightEntries, title)));
    else
 SimpleChartHelpers.DrawLineChart(picWeight, weightEntries, title);
}
```

### Sample Data Queries

```csharp
// Today's grouped calories
var groupedCalories = entries
    .GroupBy(f => f.FoodName)
    .Select(g => new GroupedCaloriesDto 
    { 
        Food = g.Key, 
        Calories = g.Sum(x => x.Calories) 
    })
 .OrderByDescending(g => g.Calories)
    .ToList();

// Weight history for last 30 days
var weightHistory = context.GetWeightEntries(_user.Id, fromDate, toDate)
    .Select(w => new WeightChartDto 
    { 
    Timestamp = w.Timestamp, 
        WeightKg = w.WeightKg 
    })
    .OrderBy(w => w.Timestamp)
    .ToList();
```

## Data Storage

The application uses a simplified in-memory data context that:
- Stores data in `Dictionary<int, T>` collections for fast access
- Provides thread-safe operations using lock statements
- Includes sample data initialization for demonstration
- Avoids external database dependencies

## Installation & Setup

### Prerequisites
- Windows 10 or later
- .NET Framework 4.7.2 or later
- Visual Studio 2019+ (for development)

### Building the Application
1. Open `Diet_tracking_weight_tracking.sln` in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

### First Run Experience
On first run, the application will:
1. Initialize in-memory data storage
2. Create sample food items database
3. Create a demo user account:
   - **Username**: `demo`
   - **Password**: `demo123`
   - **Profile**: Pre-configured with sample data

## Usage Guide

### Getting Started
1. **Login** with demo account or create a new account
2. **Complete Profile** if registering (height, weight, activity level, goals)
3. **Dashboard** shows your daily progress with live charts

### Daily Tracking Workflow
1. **Log Food**: Use quick-add buttons or search for specific foods
   - Charts update immediately showing calorie distribution
2. **Track Water**: Enter water amounts toward your daily goal
3. **Record Weight**: Log weight measurements to see progress trend

### Chart Features

#### Calorie Pie Chart
- Shows **percentage breakdown** of calories by food type
- **Auto-groups** small items (<3%) under "Other"
- **Updates in real-time** when adding/deleting food entries
- **Color-coded** with consistent palette

#### Weight Line Chart
- Displays **weight trend** over last 30 days (configurable)
- Shows **individual data points** with hover information
- **Auto-scales** Y-axis based on data range
- **Grid lines** for easy value reading

### BMI & Health Calculations
- **Real-time BMI** updates with color coding:
  - **Blue**: Underweight (BMI < 18.5)
  - **Green**: Normal (BMI 18.5-24.9)
  - **Orange**: Overweight (BMI 25-29.9)
  - **Red**: Obese (BMI ? 30)

### Calorie Targets
- **Automatic calculation** based on:
  - BMR using Mifflin-St Jeor equation
  - Activity level multipliers
- Health goals (lose/maintain/gain)

## Architecture

### Key Classes
- **`SimpleChartHelpers`**: Custom GDI+ chart drawing
- **`DashboardForm`**: Main UI with chart integration
- **`DietTrackerDbContext`**: In-memory data management
- **`AuthenticationService`**: User login/registration
- **`ProfileService`**: Health calculations (BMI, BMR, TDEE)
- **`EntryService`**: Food/water/weight data operations

### Threading & Performance
- **Background data loading** using `Task.Run()`
- **UI thread safety** with `Invoke`/`BeginInvoke`
- **Efficient chart rendering** using cached bitmaps
- **Real-time updates** without blocking UI

### Error Handling
- Graceful fallback for missing data
- User-friendly error messages
- Chart error states with clear messaging
- Thread-safe exception handling

## Customization

### Adding New Food Items
The food database can be extended in `DietTrackerDbContext.CreateSampleData()`:

```csharp
var newFoods = new[] {
    new FoodItem { Name = "Chicken Breast", DefaultCaloriesPerServing = 165, ServingDescription = "100g" },
    new FoodItem { Name = "Broccoli", DefaultCaloriesPerServing = 34, ServingDescription = "1 cup" }
};
```

### Customizing Chart Appearance
Colors and styling can be modified in `SimpleChartHelpers`:

```csharp
// Pie chart colors
Color[] colors = {
    Color.FromArgb(255, 99, 132),   // Red
    Color.FromArgb(54, 162, 235),   // Blue
    // Add more colors...
};

// Line chart styling
using (var linePen = new Pen(Color.FromArgb(0, 123, 255), 3)) // Line color & thickness
```

### Chart Update Frequency
Modify chart refresh settings in dashboard event handlers:

```csharp
// Update charts after every food entry
private async Task OnFoodEntryAddedAsync()
{
    await RefreshFoodEntries();
    await UpdateCaloriesPieChartAsync(DateTime.Today); // Immediate update
}

// Weight history window (change from 30 to 60 days)
await UpdateWeightLineChartAsync(DateTime.Today.AddDays(-60), DateTime.Today);
```

## Future Enhancements

### Planned Features
- **Export functionality** (PDF reports with charts)
- **Nutritional tracking** (macros, vitamins, minerals)
- **Exercise integration** with calorie burn tracking
- **Data persistence** to local files or database
- **Import/export** user data
- **Advanced charting** with zoom/pan capabilities

### Chart Improvements
- **Interactive tooltips** with detailed information
- **Trend line analysis** with statistical calculations
- **Multiple data series** on single chart
- **Chart animation** for smooth transitions
- **Print/export** chart images

## Demo Account

**Pre-configured demo account for testing:**
- **Username**: `demo`
- **Password**: `demo123`
- **Sample Data**: Includes pre-logged food entries, water intake, and weight history
- **Charts**: Shows realistic data distribution and trends

## Support & Development

### Building from Source
1. Clone the repository
2. Open in Visual Studio 2019+
3. Build and run (F5)
4. Charts will display immediately with sample data

### Performance Notes
- Charts render efficiently using GDI+ bitmap caching
- Database operations run on background threads
- UI updates are throttled to prevent excessive redraws
- Memory management includes proper image disposal

### Known Limitations
1. **In-memory storage** - data lost when application closes
2. **Single user session** - no multi-user support
3. **Basic food database** - limited initial food items
4. **No data export** - charts are view-only

---

**Built with ?? using Windows Forms and custom GDI+ charting**

*This implementation demonstrates advanced WinForms development with custom chart controls, thread-safe UI updates, and real-time data visualization without external dependencies.*