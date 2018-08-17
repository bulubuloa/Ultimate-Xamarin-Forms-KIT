using System;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportBubbleChartExtended : SupportBarLineChartBase
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(BubbleChartData), typeof(SupportBubbleChartExtended), null);
        public BubbleChartData ChartData
        {
            get => (BubbleChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportBubbleChartExtended()
        {
        }
    }
}