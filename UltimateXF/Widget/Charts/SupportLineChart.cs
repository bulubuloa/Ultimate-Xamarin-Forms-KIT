using System;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportLineChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(LineChartData), typeof(SupportLineChart), null);
        public LineChartData ChartData
        {
            get => (LineChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportLineChart()
        {
        }
    }
}