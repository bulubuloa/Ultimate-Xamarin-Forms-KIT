using System;
using UltimateXF.Widget.Charts.Models.RadarChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{   
    [Obsolete("This class is deprecated, please use new chart Extended instead.")]
    public class SupportRadarChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(RadarChartData), typeof(SupportBarChart), null);
        public RadarChartData ChartData
        {
            get => (RadarChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportRadarChart()
        {
        }
    }
}