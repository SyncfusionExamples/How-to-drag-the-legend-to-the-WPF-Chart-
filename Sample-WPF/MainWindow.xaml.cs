using Syncfusion.UI.Xaml.Charts;
using System.Windows;
using System.Windows.Input;

namespace Sample_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragable = false;

        public MainWindow()
        {
            InitializeComponent();
        }

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

        private void SfChart_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragable = false;
        }

        private void Legend_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragable = true;
        }
    }
}