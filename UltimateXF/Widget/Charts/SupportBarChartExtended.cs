using System;
using UltimateXF.Widget.Charts.Models.BarChart;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.Legend;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportBarChartExtended : SupportBarLineChartBase
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(BarChartData), typeof(SupportBarChartExtended), null);
        public BarChartData ChartData
        {
            get => (BarChartData)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }


        public SupportBarChartExtended()
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