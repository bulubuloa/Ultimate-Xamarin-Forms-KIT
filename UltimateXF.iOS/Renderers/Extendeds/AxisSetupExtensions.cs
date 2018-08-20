using System;
using iOSCharts;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Extendeds
{
    public static class AxisSetupExtensions
    {
        public static void SetupConfigBase(this ChartComponentBase OriginalAxis, ConfigBase SupportXAxis)
        {
            /*
                    * Properties could not set
                    * TextColor           
                    * Typeface
                    * TextSize
             */
            if (SupportXAxis.Enabled.HasValue)
                OriginalAxis.Enabled = SupportXAxis.Enabled.Value;

            if (SupportXAxis.XOffset.HasValue)
                OriginalAxis.XOffset = SupportXAxis.XOffset.Value;

            if (SupportXAxis.YOffset.HasValue)
                OriginalAxis.YOffset = SupportXAxis.YOffset.Value;
        }

        public static void SetupAxisConfigBase(this ChartAxisBase OriginalAxis, AxisConfigBase SupportXAxis)
        {
            /*
                     * Properties could not set
                     * CustomAxisMin
                     * CustomAxisMax                     
            */
            if (SupportXAxis.DrawGridLines.HasValue)
                OriginalAxis.DrawGridLinesEnabled = SupportXAxis.DrawGridLines.Value;

            if (SupportXAxis.GridColor.HasValue)
                OriginalAxis.GridColor = SupportXAxis.GridColor.Value.ToUIColor();

            if (SupportXAxis.AxisLineWidth.HasValue)
                OriginalAxis.AxisLineWidth = SupportXAxis.AxisLineWidth.Value;

            if (SupportXAxis.GridLineWidth.HasValue)
                OriginalAxis.GridLineWidth = SupportXAxis.GridLineWidth.Value;

            if (SupportXAxis.AxisLineColor.HasValue)
                OriginalAxis.AxisLineColor = SupportXAxis.AxisLineColor.Value.ToUIColor();

            if (SupportXAxis.DrawLabels.HasValue)
                OriginalAxis.DrawLabelsEnabled = SupportXAxis.DrawLabels.Value;

            if (SupportXAxis.SpaceMin.HasValue)
                OriginalAxis.SpaceMin = SupportXAxis.SpaceMin.Value;

            if (SupportXAxis.SpaceMax.HasValue)
                OriginalAxis.SpaceMax = SupportXAxis.SpaceMax.Value;

            if (SupportXAxis.DrawAxisLine.HasValue)
                OriginalAxis.DrawAxisLineEnabled = SupportXAxis.DrawAxisLine.Value;

            if (SupportXAxis.CenterAxisLabels.HasValue)
                OriginalAxis.CenterAxisLabelsEnabled = SupportXAxis.CenterAxisLabels.Value;

            if (SupportXAxis.AxisMaximum.HasValue)
                OriginalAxis.AxisMaximum = SupportXAxis.AxisMaximum.Value;

            if (SupportXAxis.AxisMinimum.HasValue)
                OriginalAxis.AxisMinimum = SupportXAxis.AxisMinimum.Value;

            if (SupportXAxis.DrawGridLinesBehindData.HasValue)
                OriginalAxis.DrawGridLinesEnabled = SupportXAxis.DrawGridLinesBehindData.Value;

            if (SupportXAxis.DrawLimitLineBehindData.HasValue)
                OriginalAxis.DrawLimitLinesBehindDataEnabled = SupportXAxis.DrawLimitLineBehindData.Value;

            if (SupportXAxis.ForceLabels.HasValue)
                OriginalAxis.ForceLabelsEnabled = SupportXAxis.ForceLabels.Value;

            if (SupportXAxis.GranularityEnabled.HasValue)
                OriginalAxis.GranularityEnabled = SupportXAxis.GranularityEnabled.Value;

            if (SupportXAxis.Granularity.HasValue)
                OriginalAxis.Granularity = SupportXAxis.Granularity.Value;

            if (SupportXAxis.LabelCount.HasValue)
                OriginalAxis.LabelCount = SupportXAxis.LabelCount.Value;
        }

        public static void SetupXAxisConfig(this ChartXAxis OriginalAxis, XAxisConfig SupportXAxis)
        {
            if (SupportXAxis.LabelWidth.HasValue)
                OriginalAxis.LabelWidth = SupportXAxis.LabelWidth.Value;

            if (SupportXAxis.LabelHeight.HasValue)
                OriginalAxis.LabelHeight = SupportXAxis.LabelHeight.Value;

            if (SupportXAxis.LabelRotationAngle.HasValue)
                OriginalAxis.LabelRotationAngle = SupportXAxis.LabelRotationAngle.Value;
            
            if (SupportXAxis.AvoidFirstLastClipping.HasValue)
                OriginalAxis.AvoidFirstLastClippingEnabled = SupportXAxis.AvoidFirstLastClipping.Value;

            if (SupportXAxis.XAXISPosition.HasValue)
                OriginalAxis.LabelPosition = GetXAxisPosition(SupportXAxis.XAXISPosition.Value);
        }

        public static XAxisLabelPosition GetXAxisPosition(XAXISPosition mode)
        {
            switch (mode)
            {
                case XAXISPosition.BOTTOM:
                    return XAxisLabelPosition.Bottom;
                case XAXISPosition.TOP:
                    return XAxisLabelPosition.Top;
                case XAXISPosition.BOTTOM_INSIDE:
                    return XAxisLabelPosition.BottomInside;
                case XAXISPosition.TOP_INSIDE:
                    return XAxisLabelPosition.TopInside;
                case XAXISPosition.BOTH:
                    return XAxisLabelPosition.BothSided;
                default:
                    return XAxisLabelPosition.Top;
            }
        }

        public static void SetupYAxisConfig(this ChartYAxis OriginalAxis, YAxisConfig SupportAxis)
        {
            /*
                 * Properties could not set
                 * UseAutoScaleRestrictionMin
                 * UseAutoScaleRestrictionMax
                 * YAXISLabelPosition
                 * AxisDependency
            */
            if (SupportAxis.Inverted.HasValue)
                OriginalAxis.Inverted = SupportAxis.Inverted.Value;
            
            if (SupportAxis.DrawZeroLine.HasValue)
                OriginalAxis.DrawZeroLineEnabled = SupportAxis.DrawZeroLine.Value;
            
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
                OriginalAxis.DrawTopYLabelEntryEnabled = SupportAxis.DrawTopYLabelEntry.Value;

            if (SupportAxis.ZeroLineColor.HasValue)
                OriginalAxis.ZeroLineColor = SupportAxis.ZeroLineColor.Value.ToUIColor();

            //if (SupportAxis.YAXISLabelPosition.HasValue)
            //    OriginalAxis.ZeroLineColor = SupportAxis.YAXISLabelPosition.Value);

            //if (SupportAxis.AxisDependency.HasValue)
                //OriginalAxis.ZeroLineColor = SupportAxis.AxisDependency.Value;
        }
    }
}