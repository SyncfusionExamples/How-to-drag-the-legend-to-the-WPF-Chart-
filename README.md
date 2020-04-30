# How-to-drag-the-legend-to-the-WPF-Chart-

This example demonstrates how to achieve the draggable chart legend in WPF. Please refer KB links for more details,

[How to drag the legend to the WPF Chart (SfChart)](https://www.syncfusion.com/kb/11484/?utm_medium=listing&utm_source=github-examples)

To change the position of legend at any arbitrary location inside the chart area, set the DockPosition as Floating with subscribing the necessary mouse events to change their X and Y legend offset as per follows.

 
**[XAML]**
```
<chart:SfChart x:Name="sfChart" MouseMove="SfChart_MouseMove" 
                        MouseLeftButtonUp= "SfChart_MouseLeftButtonUp">
            <chart:SfChart.Legend>
                <chart:ChartLegend  x:Name="legend" DockPosition="Floating"
                                   MouseLeftButtonDown="Legend_MouseLeftButtonDown"
                                   OffsetX="200"/>
            </chart:SfChart.Legend>
            …
</chart:SfChart> 
```

**[C#]**
```

private bool isDragable = false;
private void SfChart_MouseMove(object sender, MouseEventArgs e)
{
     var chart = sender as SfChart;
     if (isDragable)
     {
          var position = e.GetPosition(chart);
          ChartLegend legend = chart.Legend as ChartLegend;
          legend.OffsetX = position.X - (chart.SeriesClipRect.Left + legend.DesiredSize.Width / 2);
          legend.OffsetY = position.Y - (chart.SeriesClipRect.Top + legend.DesiredSize.Height / 2);

          if ((chart.Legend as ChartLegend).IsMouseOver)
          {
              if (Mouse.OverrideCursor == null)
                  Mouse.OverrideCursor = Cursors.Hand;
          }
     }
}

private void SfChart_MouseLeftButtonUP(object sender, MouseButtonEventArgs e)
{
            isDragable = false;
}

private void Legend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
{
            isDragable = true;
}
``




