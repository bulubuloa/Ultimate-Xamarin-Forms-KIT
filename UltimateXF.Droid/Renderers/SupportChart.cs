using System;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using MikePhil.Charting.Data;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models;

namespace UltimateXF.Droid.Renderers
{
    public class SupportChart
    {
        public static void OnSetFormatter(SupportChartView supportChart, BarLineChartBase chartOriginal)
        {
            chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(supportChart.XAxisLabels);
        }

        public static LineDataSet.Mode GetDrawLineMode(LineDataSetMode mode)
        {
            switch (mode)
            {
                case LineDataSetMode.CUBIC_BEZIER:
                    return LineDataSet.Mode.CubicBezier;
                case LineDataSetMode.CUBIC_HORIZONTAL:
                    return LineDataSet.Mode.HorizontalBezier;
                case LineDataSetMode.STEPPED:
                    return LineDataSet.Mode.Stepped;
                case LineDataSetMode.LINEAR:
                    return LineDataSet.Mode.Linear;
                default:
                    return LineDataSet.Mode.Linear;
            }
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

        public static void OnInitializeChart(SupportChartView supportChart, BarLineChartBase chartOriginal)
        {
            chartOriginal.XAxis.SetDrawGridLines(supportChart.IsShowXAxis);
            chartOriginal.XAxis.SetDrawAxisLine(supportChart.IsShowXAxisLine);
            chartOriginal.XAxis.SetDrawLabels(supportChart.IsShowXAxisValue);
            chartOriginal.XAxis.Position = GetXAxisPosition(supportChart.XAxisPosition);

            chartOriginal.AxisLeft.SetDrawGridLines(supportChart.IsShowLeftAxis);
            chartOriginal.AxisLeft.SetDrawAxisLine(supportChart.IsShowLeftAxisLine);
            chartOriginal.AxisLeft.SetDrawLabels(supportChart.IsShowLeftAxisValue);

            chartOriginal.AxisRight.SetDrawGridLines(supportChart.IsShowRightAxis);
            chartOriginal.AxisRight.SetDrawAxisLine(supportChart.IsShowRightAxisLine);
            chartOriginal.AxisRight.SetDrawLabels(supportChart.IsShowRightAxisValue);

            chartOriginal.Description.Text = supportChart.Description;

            chartOriginal.DragEnabled = supportChart.IsDragEnabled;
            chartOriginal.SetTouchEnabled(supportChart.IsTouchEnabled);
            chartOriginal.DoubleTapToZoomEnabled = supportChart.IsDoubleTapToZoomEnabled;
            chartOriginal.ScaleXEnabled = supportChart.IsScaleXEnabled;
            chartOriginal.ScaleYEnabled = supportChart.IsScaleYEnabled;

            OnSetFormatter(supportChart,chartOriginal);
        }

        public static void OnChartPropertyChanged(string propertyName, SupportChartView supportChart, BarLineChartBase chartOriginal)
        {
            if (propertyName.Equals(SupportChartView.IsShowXAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.SetDrawGridLines(supportChart.IsShowXAxis);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowXAxisLineProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.SetDrawAxisLine(supportChart.IsShowXAxisLine);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowLeftAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisLeft.SetDrawGridLines(supportChart.IsShowLeftAxis);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowRightAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisRight.SetDrawGridLines(supportChart.IsShowRightAxis);
                }
            }
            else if (propertyName.Equals(SupportChartView.DescriptionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.Description.Text = supportChart.Description;
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowLeftAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisLeft.SetDrawLabels(supportChart.IsShowLeftAxisValue);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowRightAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisRight.SetDrawLabels(supportChart.IsShowRightAxisValue);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowXAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.SetDrawLabels(supportChart.IsShowXAxisValue);
                }
            }
            else if (propertyName.Equals(SupportChartView.XAxisPositionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.Position = GetXAxisPosition(supportChart.XAxisPosition);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsDragEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.DragEnabled = supportChart.IsDragEnabled;
                }
            }
            else if (propertyName.Equals(SupportChartView.IsTouchEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.SetTouchEnabled(supportChart.IsTouchEnabled);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsDoubleTapToZoomEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.DoubleTapToZoomEnabled = supportChart.IsDoubleTapToZoomEnabled;
                }
            }
            else if (propertyName.Equals(SupportChartView.IsScaleXEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.ScaleXEnabled = supportChart.IsScaleXEnabled;
                }
            }
            else if (propertyName.Equals(SupportChartView.IsScaleYEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.ScaleYEnabled = supportChart.IsScaleYEnabled;
                }
            }
            else if (propertyName.Equals(SupportChartView.XAxisLabelsProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(supportChart.XAxisLabels);
                }
            }
        }
    }
}