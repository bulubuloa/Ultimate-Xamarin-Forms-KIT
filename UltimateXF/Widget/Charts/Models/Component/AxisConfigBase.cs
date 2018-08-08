using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class AxisConfigBase : ConfigBase
    {
        public bool? DrawGridLines;
        public Color? GridColor;
        public float? AxisLineWidth;
        public float? GridLineWidth;
        public Color? AxisLineColor;
        public bool? DrawLabels;
        public float? SpaceMin;
        public float? SpaceMax;
        public bool? DrawAxisLine;
        public bool? CenterAxisLabels;
        public float? AxisMaximum;
        public float? AxisMinimum;
        public bool? DrawGridLinesBehindData;
        public bool? DrawLimitLineBehindData;
        public float? Granularity;
        public int? LabelCount;
        public bool? ForceLabels;
        public bool? CustomAxisMin;
        public bool? CustomAxisMax;
        public bool? GranularityEnabled;

        public AxisConfigBase()
        {
            
        }
    }
}