using System;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportCandleStickChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(CandleStickChartData), typeof(SupportBarChart), null);
        public CandleStickChartData ChartData
        {
            get => (CandleStickChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportCandleStickChart()
        {
        }
    }
}