# How to achieve the draggable legend in WPF Chart (SfChart)?

This example demonstrates how to make it possible for end-users to move a chart's legend at runtime.

To change the position of legend at any arbitrary location inside the chart area, set the [DockPosition](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartLegend.html#Syncfusion_UI_Xaml_Charts_ChartLegend_DockPosition) as **Floating** with subscribing the necessary mouse events to change their X and Y legend offset as per follows.

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
```

## Output:

![Drag the legend in WPF Chart](https://user-images.githubusercontent.com/53489303/200731756-bf45c976-24c4-4697-a92b-969abc0b1020.gif)

KB article - [How to achieve the draggable legend in WPF Chart (SfChart)?](https://www.syncfusion.com/kb/11484/how-to-achieve-the-draggable-legend-in-wpf-chart-sfchart)

## See also

[How to set or modify the label of each legend](https://www.syncfusion.com/kb/4687/how-to-set-or-modify-the-label-of-the-each-legend)

[How to add multiple legend items in scroll viewer](https://www.syncfusion.com/kb/4846/how-to-add-multiple-legend-items-in-scroll-viewer)

[How to create custom legend items in WPF SfChart](https://www.syncfusion.com/kb/10675/how-to-create-custom-legenditems-in-wpf-sfchart)

[How to wrap the text in the WPF Chart legend](https://www.syncfusion.com/kb/10996/how-to-wrap-the-text-in-the-wpf-chart-legend)

[How to format the legend text in Chart WPF](https://www.syncfusion.com/kb/4691/how-to-format-the-legend-text)
