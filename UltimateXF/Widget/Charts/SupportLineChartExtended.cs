using System;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.Legend;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportLineChartExtended : SupportBarLineChartBase
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(LineChartData), typeof(SupportLineChartExtended), null);
        public LineChartData ChartData
        {
            get => (LineChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public SupportLineChartExtended()
        {
            AxisLeft = new YAxisConfig();
            AxisRight = new YAxisConfig();
            XAxis = new XAxisConfig();
            DescriptionChart = new ChartDescription();
            AnimationX = new AnimatorXF();
            AnimationY = new AnimatorXF();
            Legend = new LegendXF();
        }
    }
}