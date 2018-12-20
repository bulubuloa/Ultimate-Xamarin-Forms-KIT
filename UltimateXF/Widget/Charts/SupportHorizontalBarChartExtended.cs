using System;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.Legend;

namespace UltimateXF.Widget.Charts
{
    public class SupportHorizontalBarChartExtended : SupportBarChartExtended
    {
        public SupportHorizontalBarChartExtended()
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