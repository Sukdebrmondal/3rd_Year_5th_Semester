using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Diet_tracking_weight_tracking.DTOs;

namespace Diet_tracking_weight_tracking.Services
{
    /// <summary>
    /// Simple chart implementations using GDI+ drawing
    /// Provides pie chart and line chart functionality without external dependencies
    /// </summary>
    public static class SimpleChartHelpers
    {
    /// <summary>
        /// Draw a circular pie chart on a PictureBox control
  /// </summary>
    /// <param name="pictureBox">PictureBox to draw on</param>
    /// <param name="data">Data with Food and Calories properties</param>
        /// <param name="title">Chart title</param>
        public static void DrawPieChart(PictureBox pictureBox, List<GroupedCaloriesDto> data, string title)
        {
    if (pictureBox == null) return;

            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.Clear(Color.White);

     if (data == null || !data.Any())
         {
       DrawNoDataMessage(graphics, pictureBox.ClientRectangle, "No calorie data");
          pictureBox.Image = bitmap;
 return;
         }

             // Draw title
   using (var titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
     using (var titleBrush = new SolidBrush(Color.FromArgb(33, 37, 41)))
        {
      var titleSize = graphics.MeasureString(title, titleFont);
    var titleX = (pictureBox.Width - titleSize.Width) / 2;
    graphics.DrawString(title, titleFont, titleBrush, titleX, 10);
     }

                // Calculate chart area - FORCE CIRCULAR by using minimum dimension
    var availableWidth = pictureBox.Width - 140; // Leave space for legend
             var availableHeight = pictureBox.Height - 80; // Leave space for title and padding
  var chartSize = Math.Min(availableWidth, availableHeight);
     
      // Center the circular chart
                var chartX = 40 + (availableWidth - chartSize) / 2;
      var chartY = 40 + (availableHeight - chartSize) / 2;
     var chartRect = new Rectangle(chartX, chartY, chartSize, chartSize);
        
                // Legend positioned to the right of the circular chart
   var legendRect = new Rectangle(chartRect.Right + 15, chartRect.Y, 120, chartRect.Height);

        var totalCalories = data.Sum(d => d.Calories);
    if (totalCalories == 0) return;

       // Enhanced color palette
         Color[] colors = {
Color.FromArgb(239, 83, 80),   // Red
         Color.FromArgb(30, 136, 229),  // Blue
        Color.FromArgb(255, 202, 40),  // Yellow
     Color.FromArgb(67, 160, 71),   // Green
         Color.FromArgb(156, 39, 176),  // Purple
       Color.FromArgb(255, 112, 67),  // Orange
          Color.FromArgb(121, 85, 72),   // Brown
      Color.FromArgb(96, 125, 139)   // Blue Grey
      };

         // Draw pie slices in perfect circle
           float startAngle = 0;
           var legendY = legendRect.Y;
          using (var legendFont = new Font("Segoe UI", 9))
{
               for (int i = 0; i < data.Count; i++)
      {
            var item = data[i];
         var sweepAngle = (float)(item.Calories * 360.0 / totalCalories);
       var color = colors[i % colors.Length];

    // Draw pie slice
  using (var brush = new SolidBrush(color))
     {
                 graphics.FillPie(brush, chartRect, startAngle, sweepAngle);
      }

            // Draw slice border
           using (var pen = new Pen(Color.White, 2))
   {
          graphics.DrawPie(pen, chartRect, startAngle, sweepAngle);
     }

              // Draw percentage label outside the pie
       if (sweepAngle > 10) // Only show labels for slices > 10 degrees
     {
  var percentage = (double)item.Calories / totalCalories * 100;
         var labelAngle = (startAngle + sweepAngle / 2) * Math.PI / 180;
             var labelRadius = chartSize / 2 + 20; // Outside the pie
   var labelX = chartRect.X + chartRect.Width / 2 + (float)(labelRadius * Math.Cos(labelAngle));
        var labelY = chartRect.Y + chartRect.Height / 2 + (float)(labelRadius * Math.Sin(labelAngle));

        using (var labelBrush = new SolidBrush(Color.Black))
        using (var labelFont = new Font("Segoe UI", 8, FontStyle.Bold))
        {
          var labelText = $"{percentage:F1}%";
  var labelSize = graphics.MeasureString(labelText, labelFont);
       
  // Draw background for better readability
      var labelBg = new RectangleF(labelX - labelSize.Width / 2 - 2, 
         labelY - labelSize.Height / 2 - 2,
        labelSize.Width + 4, labelSize.Height + 4);
       graphics.FillRectangle(Brushes.White, labelBg);
         graphics.DrawRectangle(Pens.LightGray, Rectangle.Round(labelBg));
                 
                    graphics.DrawString(labelText, labelFont, labelBrush, 
 labelX - labelSize.Width / 2, labelY - labelSize.Height / 2);
    }
     }

        // Draw improved legend
  var legendItemRect = new Rectangle(legendRect.X, legendY, 15, 15);
              using (var brush = new SolidBrush(color))
              {
     graphics.FillRectangle(brush, legendItemRect);
        }
              graphics.DrawRectangle(Pens.Black, legendItemRect);

      var legendText = $"{item.Food}";
               var legendSubText = $"{item.Calories} cal ({item.Percentage:F1}%)";
             
  using (var boldFont = new Font("Segoe UI", 9, FontStyle.Bold))
        using (var regularFont = new Font("Segoe UI", 8))
      {
  graphics.DrawString(legendText, boldFont, Brushes.Black, 
             legendRect.X + 20, legendY - 2);
     graphics.DrawString(legendSubText, regularFont, Brushes.Gray, 
 legendRect.X + 20, legendY + 12);
  }

        legendY += 30;
     startAngle += sweepAngle;
            }
       }
            }

   pictureBox.Image?.Dispose();
        pictureBox.Image = bitmap;
        }

   /// <summary>
        /// Draw a line chart on a PictureBox control
        /// </summary>
        /// <param name="pictureBox">PictureBox to draw on</param>
        /// <param name="data">Weight data with Timestamp and WeightKg properties</param>
        /// <param name="title">Chart title</param>
        public static void DrawLineChart(PictureBox pictureBox, List<WeightChartDto> data, string title)
    {
        if (pictureBox == null) return;

            var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
     using (var graphics = Graphics.FromImage(bitmap))
   {
         graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.Clear(Color.White);

                if (data == null || !data.Any())
                {
      DrawNoDataMessage(graphics, pictureBox.ClientRectangle, "No weight data");
          pictureBox.Image = bitmap;
       return;
                }

                // Draw title
     using (var titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
    using (var titleBrush = new SolidBrush(Color.FromArgb(33, 37, 41)))
           {
         var titleSize = graphics.MeasureString(title, titleFont);
          var titleX = (pictureBox.Width - titleSize.Width) / 2;
        graphics.DrawString(title, titleFont, titleBrush, titleX, 10);
      }

 // Calculate chart area
        var margin = 50;
      var chartRect = new Rectangle(margin, 40, pictureBox.Width - margin * 2, pictureBox.Height - 80);

        // Calculate data ranges
      var minDate = data.Min(d => d.Timestamp);
       var maxDate = data.Max(d => d.Timestamp);
      var minWeight = data.Min(d => d.WeightKg);
   var maxWeight = data.Max(d => d.WeightKg);
      var weightRange = maxWeight - minWeight;
    var weightPadding = Math.Max(1.0, weightRange * 0.1);

  minWeight -= weightPadding;
     maxWeight += weightPadding;

         // Draw grid and axes
        using (var gridPen = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dot })
             using (var axisPen = new Pen(Color.Black, 2))
          {
     // Draw Y-axis
      graphics.DrawLine(axisPen, chartRect.Left, chartRect.Top, chartRect.Left, chartRect.Bottom);
          
      // Draw X-axis
          graphics.DrawLine(axisPen, chartRect.Left, chartRect.Bottom, chartRect.Right, chartRect.Bottom);

      // Draw horizontal grid lines and Y-axis labels
     using (var labelFont = new Font("Segoe UI", 8))
 {
                  for (int i = 0; i <= 5; i++)
     {
            var weight = minWeight + (maxWeight - minWeight) * i / 5;
           var y = chartRect.Bottom - (int)((weight - minWeight) / (maxWeight - minWeight) * chartRect.Height);

      graphics.DrawLine(gridPen, chartRect.Left, y, chartRect.Right, y);
   graphics.DrawString($"{weight:F1}", labelFont, Brushes.Black, 5, y - 8);
      }

       // Draw vertical grid lines and X-axis labels
       var daySpan = (maxDate - minDate).TotalDays;
    var labelCount = Math.Min(5, data.Count);
     
           for (int i = 0; i <= labelCount; i++)
      {
         var date = minDate.AddDays(daySpan * i / labelCount);
     var x = chartRect.Left + (int)(chartRect.Width * i / (double)labelCount);

     graphics.DrawLine(gridPen, x, chartRect.Top, x, chartRect.Bottom);
                
        var dateStr = date.ToString("MMM dd");
        var labelSize = graphics.MeasureString(dateStr, labelFont);
     graphics.DrawString(dateStr, labelFont, Brushes.Black, 
      x - labelSize.Width / 2, chartRect.Bottom + 5);
      }
                 }
   }

      // Draw data points and line
                if (data.Count > 1)
                {
        var points = new List<PointF>();
    
        foreach (var item in data)
      {
           var x = chartRect.Left + (float)((item.Timestamp - minDate).TotalDays / (maxDate - minDate).TotalDays * chartRect.Width);
        var y = chartRect.Bottom - (float)((item.WeightKg - minWeight) / (maxWeight - minWeight) * chartRect.Height);
          points.Add(new PointF(x, y));
           }

 // Draw line
    using (var linePen = new Pen(Color.FromArgb(0, 123, 255), 3))
 {
  for (int i = 0; i < points.Count - 1; i++)
     {
               graphics.DrawLine(linePen, points[i], points[i + 1]);
  }
        }

        // Draw data points
       using (var pointBrush = new SolidBrush(Color.FromArgb(0, 123, 255)))
    using (var pointPen = new Pen(Color.White, 2))
   {
    foreach (var point in points)
        {
          var pointRect = new RectangleF(point.X - 4, point.Y - 4, 8, 8);
              graphics.FillEllipse(pointBrush, pointRect);
    graphics.DrawEllipse(pointPen, pointRect);
                     }
             }
    }

     // Draw axis labels
      using (var labelFont = new Font("Segoe UI", 10, FontStyle.Bold))
    {
      graphics.DrawString("Date", labelFont, Brushes.Black, 
    chartRect.Left + chartRect.Width / 2 - 15, pictureBox.Height - 20);

      // Rotate and draw Y-axis label
 var yLabelX = 15;
   var yLabelY = chartRect.Top + chartRect.Height / 2;
        graphics.TranslateTransform(yLabelX, yLabelY);
     graphics.RotateTransform(-90);
       graphics.DrawString("Weight (kg)", labelFont, Brushes.Black, -30, -8);
      graphics.ResetTransform();
    }
   }

            pictureBox.Image?.Dispose();
      pictureBox.Image = bitmap;
 }

        /// <summary>
        /// Draw a "no data" message
      /// </summary>
   private static void DrawNoDataMessage(Graphics graphics, Rectangle bounds, string message)
     {
     using (var font = new Font("Segoe UI", 11, FontStyle.Italic))
using (var brush = new SolidBrush(Color.Gray))
            {
      var size = graphics.MeasureString(message, font);
     var x = (bounds.Width - size.Width) / 2;
                var y = (bounds.Height - size.Height) / 2;
            graphics.DrawString(message, font, brush, x, y);
            }
 }
 }

    /// <summary>
    /// Helper class for Quick Add button layout and management
    /// </summary>
    public static class QuickAddLayoutHelpers
    {
        private static readonly Color QuickAddButtonColor = Color.FromArgb(34, 139, 34);
   private static readonly Size QuickAddButtonSize = new Size(110, 60);

        /// <summary>
/// Create and configure a FlowLayoutPanel for Quick Add buttons
        /// </summary>
        public static FlowLayoutPanel CreateQuickAddFlowPanel()
        {
  return new FlowLayoutPanel
            {
       Name = "flowQuickAdd",
        FlowDirection = FlowDirection.LeftToRight,
      WrapContents = true,
                AutoScroll = true,
  Dock = DockStyle.Fill,
    Padding = new Padding(8),
     Margin = new Padding(0),
      BackColor = Color.Transparent,
      AutoScrollMinSize = new Size(0, 0)
};
    }

        /// <summary>
        /// Create a Quick Add button for a food item
        /// </summary>
        public static Button CreateQuickAddButton(object foodItem, string displayName, int calories, EventHandler clickHandler)
        {
    var btn = new Button
            {
                Text = $"{displayName}\n{calories} cal",
                Tag = foodItem,
       Size = QuickAddButtonSize,
        Margin = new Padding(6),
            FlatStyle = FlatStyle.Flat,
 BackColor = QuickAddButtonColor,
        ForeColor = Color.White,
        Font = new Font("Segoe UI", 9, FontStyle.Bold),
         TextAlign = ContentAlignment.MiddleCenter,
        UseVisualStyleBackColor = false
      };
        
        btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 160, 46);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 120, 28);
      
  if (clickHandler != null)
        btn.Click += clickHandler;

    return btn;
        }
    }
}