using System;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers
{
    public class SupportChartExtended
    {
        public static void OnInitializeChartAxisRight(YAxisConfig yAxis, BarLineChartBase chartOriginal)
        {
            if (yAxis.Inverted.HasValue)
                chartOriginal.AxisRight.Inverted = yAxis.Inverted.Value;

            if (yAxis.DrawZeroLine.HasValue)
                chartOriginal.AxisRight.SetDrawZeroLine(yAxis.DrawZeroLine.Value);

            if (yAxis.SpacePercentTop.HasValue)
                chartOriginal.AxisRight.SpaceTop = yAxis.SpacePercentTop.Value;

            if (yAxis.SpacePercentBottom.HasValue)
                chartOriginal.AxisRight.SpaceBottom = yAxis.SpacePercentBottom.Value;

            if (yAxis.MinWidth.HasValue)
                chartOriginal.AxisRight.MinWidth = yAxis.MinWidth.Value;

            if (yAxis.MaxWidth.HasValue)
                chartOriginal.AxisRight.MaxWidth = yAxis.MaxWidth.Value;

            if (yAxis.ZeroLineColor.HasValue)
                chartOriginal.AxisRight.ZeroLineColor = yAxis.ZeroLineColor.Value.ToAndroid();

            if (yAxis.ZeroLineWidth.HasValue)
                chartOriginal.AxisRight.ZeroLineWidth = yAxis.ZeroLineWidth.Value;

            if (yAxis.DrawTopYLabelEntry.HasValue)
                chartOriginal.AxisRight.SetDrawTopYLabelEntry(yAxis.DrawTopYLabelEntry.Value);
        }

        public static void OnInitializeChartAxisLeft(YAxisConfig yAxis, BarLineChartBase chartOriginal)
        {
            if (yAxis.Inverted.HasValue)
                chartOriginal.AxisLeft.Inverted = yAxis.Inverted.Value;

            if (yAxis.DrawZeroLine.HasValue)
                chartOriginal.AxisLeft.SetDrawZeroLine(yAxis.DrawZeroLine.Value);

            if (yAxis.SpacePercentTop.HasValue)
                chartOriginal.AxisLeft.SpaceTop = yAxis.SpacePercentTop.Value;

            if (yAxis.SpacePercentBottom.HasValue)
                chartOriginal.AxisLeft.SpaceBottom = yAxis.SpacePercentBottom.Value;

            if (yAxis.MinWidth.HasValue)
                chartOriginal.AxisLeft.MinWidth = yAxis.MinWidth.Value;

            if (yAxis.MaxWidth.HasValue)
                chartOriginal.AxisLeft.MaxWidth = yAxis.MaxWidth.Value;

            if (yAxis.ZeroLineColor.HasValue)
                chartOriginal.AxisLeft.ZeroLineColor = yAxis.ZeroLineColor.Value.ToAndroid();

            if (yAxis.ZeroLineWidth.HasValue)
                chartOriginal.AxisLeft.ZeroLineWidth = yAxis.ZeroLineWidth.Value;

            if (yAxis.DrawTopYLabelEntry.HasValue)
                chartOriginal.AxisLeft.SetDrawTopYLabelEntry(yAxis.DrawTopYLabelEntry.Value);
        }

        public static void OnInitializeChartBarLineBase(SupportBarLineChartBase supportChart, BarLineChartBase chartOriginal)
        {
            OnInitializeChartBase(supportChart, chartOriginal);

            if (supportChart.MaxVisibleCount.HasValue)
                chartOriginal.SetMaxVisibleValueCount(supportChart.MaxVisibleCount.Value);

            if (supportChart.ClipValuesToContent.HasValue)
                chartOriginal.SetClipValuesToContent(supportChart.ClipValuesToContent.Value);

            if (supportChart.DrawBorders.HasValue)
                chartOriginal.SetDrawBorders(supportChart.DrawBorders.Value);

            if (supportChart.DrawGridBackground.HasValue)
                chartOriginal.SetDrawGridBackground(supportChart.DrawGridBackground.Value);

            if (supportChart.ScaleYEnabled.HasValue)
                chartOriginal.ScaleYEnabled = (supportChart.ScaleYEnabled.Value);

            if (supportChart.ScaleXEnabled.HasValue)
                chartOriginal.ScaleXEnabled = (supportChart.ScaleXEnabled.Value);

            if (supportChart.DragXEnabled.HasValue && supportChart.DragYEnabled.HasValue)
                chartOriginal.DragEnabled = supportChart.DragXEnabled.Value && supportChart.DragYEnabled.Value;

            if (supportChart.HighlightPerDragEnabled.HasValue)
                chartOriginal.HighlightPerDragEnabled = (supportChart.HighlightPerDragEnabled.Value);

            if (supportChart.DoubleTapToZoomEnabled.HasValue)
                chartOriginal.DoubleTapToZoomEnabled = (supportChart.DoubleTapToZoomEnabled.Value);

            if (supportChart.PinchZoomEnabled.HasValue)
                chartOriginal.SetPinchZoom(supportChart.PinchZoomEnabled.Value);

            if (supportChart.AutoScaleMinMaxEnabled.HasValue)
                chartOriginal.AutoScaleMinMaxEnabled = (supportChart.AutoScaleMinMaxEnabled.Value);

            //left axis
            OnInitializeChartAxisLeft(supportChart.AxisLeft, chartOriginal);

            //right axis
            OnInitializeChartAxisRight(supportChart.AxisRight,chartOriginal);
        }

        public static void OnInitializeChartBase(SupportBaseChart supportChart, Chart chartOriginal)
        {
            if (supportChart.LogEnabled.HasValue)
                chartOriginal.LogEnabled = supportChart.LogEnabled.Value;
            
            if (supportChart.ExtraLeftOffset.HasValue)
                chartOriginal.ExtraLeftOffset = supportChart.ExtraLeftOffset.Value;
            
            if (supportChart.ExtraBottomOffset.HasValue)
                chartOriginal.ExtraBottomOffset = supportChart.ExtraBottomOffset.Value;
            
            if (supportChart.ExtraRightOffset.HasValue)
                chartOriginal.ExtraRightOffset = supportChart.ExtraRightOffset.Value;
            
            if (supportChart.ExtraTopOffset.HasValue)
                chartOriginal.ExtraTopOffset = supportChart.ExtraTopOffset.Value;
            
            if (supportChart.DragDecelerationFrictionCoef.HasValue)
                chartOriginal.DragDecelerationFrictionCoef = supportChart.DragDecelerationFrictionCoef.Value;
            
            if (supportChart.DragDecelerationEnabled.HasValue)
                chartOriginal.DragDecelerationEnabled = supportChart.DragDecelerationEnabled.Value;
            
            if (supportChart.HighLightPerTapEnabled.HasValue)
                chartOriginal.HighlightPerTapEnabled = supportChart.HighLightPerTapEnabled.Value;
            
            chartOriginal.Description.Text = supportChart.DescriptionChart.Text;

            if (supportChart.XAxis.LabelWidth.HasValue)
                chartOriginal.XAxis.MLabelWidth = supportChart.XAxis.LabelWidth.Value;
            
            if (supportChart.XAxis.LabelHeight.HasValue)
                chartOriginal.XAxis.MLabelHeight = supportChart.XAxis.LabelHeight.Value;
            
            if (supportChart.XAxis.LabelRotationAngle.HasValue)
                chartOriginal.XAxis.LabelRotationAngle = supportChart.XAxis.LabelRotationAngle.Value;
            
            if (supportChart.XAxis.AvoidFirstLastClipping.HasValue)
                chartOriginal.XAxis.SetAvoidFirstLastClipping(supportChart.XAxis.AvoidFirstLastClipping.Value);
            
            if (supportChart.XAxis.XAXISPosition.HasValue)
                chartOriginal.XAxis.Position = GetXAxisPosition(supportChart.XAxis.XAXISPosition.Value);
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
    }
}
