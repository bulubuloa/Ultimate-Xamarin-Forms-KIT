using System;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.BarChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportBarChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(BarChartData), typeof(SupportBarChart), null);
        public BarChartData ChartData
        {
            get => (BarChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportBarChart()
        {
        }
    }
}