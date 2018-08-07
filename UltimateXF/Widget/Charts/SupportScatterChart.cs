using System;
using UltimateXF.Widget.Charts.Models.ScatterChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportScatterChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(ScatterChartData), typeof(SupportBarChart), null);
        public ScatterChartData ChartData
        {
            get => (ScatterChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportScatterChart()
        {
        }
    }
}