using System;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportBubbleChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(BubbleChartData), typeof(SupportBarChart), null);
        public BubbleChartData ChartData
        {
            get => (BubbleChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportBubbleChart()
        {
        }
    }
}