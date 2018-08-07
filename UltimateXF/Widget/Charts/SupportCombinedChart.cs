using System;
using UltimateXF.Widget.Charts.Models.CombinedChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportCombinedChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(CombinedChartData), typeof(SupportBarChart), null);
        public CombinedChartData ChartData
        {
            get => (CombinedChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportCombinedChart()
        {
        }
    }
}