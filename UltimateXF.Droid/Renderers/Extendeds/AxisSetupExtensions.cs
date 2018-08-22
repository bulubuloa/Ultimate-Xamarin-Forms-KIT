using System;
using MikePhil.Charting.Components;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Extendeds
{
    public static class AxisSetupExtensions
    {
        public static void SetupConfigBase(this ComponentBase OriginalAxis, ConfigBase SupportXAxis)
        {
            /*
                    * Properties could not set
                    * Typeface
             */
            if (SupportXAxis.Enabled.HasValue)
                OriginalAxis.Enabled = SupportXAxis.Enabled.Value;

            if (SupportXAxis.XOffset.HasValue)
                OriginalAxis.XOffset = SupportXAxis.XOffset.Value;

            if (SupportXAxis.YOffset.HasValue)
                OriginalAxis.YOffset = SupportXAxis.YOffset.Value;

            if (SupportXAxis.TextSize.HasValue)
                OriginalAxis.TextSize = SupportXAxis.TextSize.Value;

            if (SupportXAxis.TextColor.HasValue)
                OriginalAxis.TextColor = SupportXAxis.TextColor.Value.ToAndroid();

            if (!string.IsNullOrEmpty(SupportXAxis.FontFamily))
            {
                OriginalAxis.Typeface = SpecAndroid.CreateTypeface(UltimateXFSettup.Context, SupportXAxis.FontFamily);
            }
        }

        public static void SetupAxisConfigBase(this AxisBase OriginalAxis, AxisConfigBase SupportXAxis)
        {
            /*
                     * Properties could not set
                     * DrawGridLinesBehindData
                     * ForceLabels
                     * CustomAxisMin
                     * CustomAxisMax                     
            */
            if (SupportXAxis.DrawGridLines.HasValue)
                OriginalAxis.SetDrawGridLines(SupportXAxis.DrawGridLines.Value);

            if (SupportXAxis.GridColor.HasValue)
                OriginalAxis.GridColor = SupportXAxis.GridColor.Value.ToAndroid();

            if (SupportXAxis.AxisLineWidth.HasValue)
                OriginalAxis.AxisLineWidth = SupportXAxis.AxisLineWidth.Value;

            if (SupportXAxis.GridLineWidth.HasValue)
                OriginalAxis.GridLineWidth = SupportXAxis.GridLineWidth.Value;

            if (SupportXAxis.AxisLineColor.HasValue)
                OriginalAxis.AxisLineColor = SupportXAxis.AxisLineColor.Value.ToAndroid();

            if (SupportXAxis.DrawLabels.HasValue)
                OriginalAxis.SetDrawLabels(SupportXAxis.DrawLabels.Value);

            if (SupportXAxis.SpaceMin.HasValue)
                OriginalAxis.SpaceMin = SupportXAxis.SpaceMin.Value;

            if (SupportXAxis.SpaceMax.HasValue)
                OriginalAxis.SpaceMax = SupportXAxis.SpaceMax.Value;

            if (SupportXAxis.DrawAxisLine.HasValue)
                OriginalAxis.SetDrawAxisLine(SupportXAxis.DrawAxisLine.Value);

            if (SupportXAxis.CenterAxisLabels.HasValue)
                OriginalAxis.SetCenterAxisLabels(SupportXAxis.CenterAxisLabels.Value);

            if (SupportXAxis.AxisMaximum.HasValue)
                OriginalAxis.AxisMaximum = SupportXAxis.AxisMaximum.Value;

            if (SupportXAxis.AxisMinimum.HasValue)
                OriginalAxis.AxisMinimum = SupportXAxis.AxisMinimum.Value;

            if (SupportXAxis.DrawLimitLineBehindData.HasValue)
                OriginalAxis.SetDrawLimitLinesBehindData(SupportXAxis.DrawLimitLineBehindData.Value);

            if (SupportXAxis.GranularityEnabled.HasValue)
                OriginalAxis.GranularityEnabled = SupportXAxis.GranularityEnabled.Value;

            if (SupportXAxis.Granularity.HasValue)
                OriginalAxis.Granularity = SupportXAxis.Granularity.Value;

            if (SupportXAxis.LabelCount.HasValue)
                OriginalAxis.LabelCount = SupportXAxis.LabelCount.Value;
        }

        public static void SetupXAxisConfig(this XAxis OriginalAxis, XAxisConfig SupportXAxis)
        {
            if (SupportXAxis.LabelWidth.HasValue)
                OriginalAxis.MLabelWidth = SupportXAxis.LabelWidth.Value;

            if (SupportXAxis.LabelHeight.HasValue)
                OriginalAxis.MLabelHeight = SupportXAxis.LabelHeight.Value;

            if (SupportXAxis.LabelRotationAngle.HasValue)
                OriginalAxis.LabelRotationAngle = SupportXAxis.LabelRotationAngle.Value;

            if (SupportXAxis.AvoidFirstLastClipping.HasValue)
                OriginalAxis.SetAvoidFirstLastClipping(SupportXAxis.AvoidFirstLastClipping.Value);

            if (SupportXAxis.XAXISPosition.HasValue)
                OriginalAxis.Position = GetXAxisPosition(SupportXAxis.XAXISPosition.Value);
        }

        public static XAxis.XAxisPosition GetXAxisPosition(XAXISPosition mode)
        {
            switch (mode)
            {
                case XAXISPosition.BOTTOM:
                    return XAxis.XAxisPosition.Bottom;
                case XAXISPosition.TOP:
                    return XAxis.XAxisPosition.Top;
                case XAXISPosition.BOTTOM_INSIDE:
                    return XAxis.XAxisPosition.BottomInside;
                case XAXISPosition.TOP_INSIDE:
                    return XAxis.XAxisPosition.TopInside;
                case XAXISPosition.BOTH:
                    return XAxis.XAxisPosition.BothSided;
                default:
                    return XAxis.XAxisPosition.Top;
            }
        }

        public static YAxis.YAxisLabelPosition GetYAxisLabelPosition(YAXISLabelPosition mode)
        {
            switch (mode)
            {
                case YAXISLabelPosition.INSIDE_CHART:
                    return YAxis.YAxisLabelPosition.InsideChart;
                case YAXISLabelPosition.OUTSIDE_CHART:
                    return YAxis.YAxisLabelPosition.OutsideChart;
                default:
                    return YAxis.YAxisLabelPosition.InsideChart;
            }
        }


        public static void SetupYAxisConfig(this YAxis OriginalAxis, YAxisConfig SupportAxis)
        {
            /*
                 * Properties could not set
                 * UseAutoScaleRestrictionMin
                 * UseAutoScaleRestrictionMax
                 * AxisDependency
            */
            if (SupportAxis.Inverted.HasValue)
                OriginalAxis.Inverted = SupportAxis.Inverted.Value;

            if (SupportAxis.DrawZeroLine.HasValue)
                OriginalAxis.SetDrawZeroLine(SupportAxis.DrawZeroLine.Value);

            if (SupportAxis.SpacePercentTop.HasValue)
                OriginalAxis.SpaceTop = SupportAxis.SpacePercentTop.Value;

            if (SupportAxis.SpacePercentBottom.HasValue)
                OriginalAxis.SpaceBottom = SupportAxis.SpacePercentBottom.Value;

            if (SupportAxis.MinWidth.HasValue)
                OriginalAxis.MinWidth = SupportAxis.MinWidth.Value;

            if (SupportAxis.MaxWidth.HasValue)
                OriginalAxis.MaxWidth = SupportAxis.MaxWidth.Value;

            if (SupportAxis.ZeroLineWidth.HasValue)
                OriginalAxis.ZeroLineWidth = SupportAxis.ZeroLineWidth.Value;

            if (SupportAxis.DrawTopYLabelEntry.HasValue)
                OriginalAxis.SetDrawTopYLabelEntry(SupportAxis.DrawTopYLabelEntry.Value);

            if (SupportAxis.ZeroLineColor.HasValue)
                OriginalAxis.ZeroLineColor = SupportAxis.ZeroLineColor.Value.ToAndroid();

            if (SupportAxis.YAXISLabelPosition.HasValue)
                OriginalAxis.SetPosition(GetYAxisLabelPosition(SupportAxis.YAXISLabelPosition.Value));
        }
    }
}