using System;
using UltimateXF.Widget.Charts.Models.PieChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportPieChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(PieChartData), typeof(SupportBarChart), null);
        public PieChartData ChartData
        {
            get => (PieChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportPieChart()
        {
        }
    }
}