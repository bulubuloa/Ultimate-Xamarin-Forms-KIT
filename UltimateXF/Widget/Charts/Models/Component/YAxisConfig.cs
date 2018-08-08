using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public class YAxisConfig
    {
        public YAXISLabelPosition? YAXISLabelPosition { set; get; }
        public bool? Inverted;
        public bool? DrawZeroLine;
        public float? SpacePercentTop;
        public float? SpacePercentBottom;
        public float? MinWidth;
        public float? MaxWidth;
        public Color? ZeroLineColor;
        public float? ZeroLineWidth;
        public bool? DrawTopYLabelEntry;
        public bool? UseAutoScaleRestrictionMin;
        public bool? UseAutoScaleRestrictionMax;
        public AXISDependency? AxisDependency;
    }
}