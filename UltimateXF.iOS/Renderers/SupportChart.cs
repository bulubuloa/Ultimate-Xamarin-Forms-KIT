using System;
using iOSCharts;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models;

namespace UltimateXF.iOS.Renderers
{
    public class SupportChart
    {
        //public static void OnSetFormatter(SupportChartView supportChart, BarLineChartViewBase chartOriginal)
        //{
        //    chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(supportChart.XAxisLabels.ToArray());
        //}

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

        public static LineChartMode GetDrawLineMode(LineDataSetMode mode)
        {
            switch (mode)
            {
                case LineDataSetMode.CUBIC_BEZIER:
                    return LineChartMode.CubicBezier;
                case LineDataSetMode.CUBIC_HORIZONTAL:
                    return LineChartMode.HorizontalBezier;
                case LineDataSetMode.STEPPED:
                    return LineChartMode.Stepped;
                case LineDataSetMode.LINEAR:
                    return LineChartMode.Linear;
                default:
                    return LineChartMode.Linear;
            }
        }

        public static void OnInitializeChart(SupportChartView supportChart, BarLineChartViewBase chartOriginal)
        {
            chartOriginal.XAxis.DrawGridLinesEnabled = (supportChart.IsShowXAxis);
            chartOriginal.XAxis.DrawAxisLineEnabled = (supportChart.IsShowXAxisLine);
            chartOriginal.XAxis.DrawLabelsEnabled = (supportChart.IsShowXAxisValue);
            chartOriginal.XAxis.LabelPosition = GetXAxisPosition(supportChart.XAxisPosition);

            chartOriginal.LeftAxis.DrawGridLinesEnabled = (supportChart.IsShowLeftAxis);
            chartOriginal.LeftAxis.DrawAxisLineEnabled = (supportChart.IsShowLeftAxisLine);
            chartOriginal.LeftAxis.DrawLabelsEnabled = (supportChart.IsShowLeftAxisValue);

            chartOriginal.RightAxis.DrawGridLinesEnabled = (supportChart.IsShowRightAxis);
            chartOriginal.RightAxis.DrawAxisLineEnabled = (supportChart.IsShowRightAxisLine);
            chartOriginal.RightAxis.DrawLabelsEnabled = (supportChart.IsShowRightAxisValue);

            chartOriginal.ChartDescription.Text = supportChart.Description;

            chartOriginal.DragEnabled = supportChart.IsDragEnabled;
            chartOriginal.MultipleTouchEnabled = (supportChart.IsTouchEnabled);
            chartOriginal.DoubleTapToZoomEnabled = supportChart.IsDoubleTapToZoomEnabled;
            chartOriginal.ScaleXEnabled = supportChart.IsScaleXEnabled;
            chartOriginal.ScaleYEnabled = supportChart.IsScaleYEnabled;
            //OnSetFormatter(supportChart,chartOriginal);
        }

        public static void OnChartPropertyChanged(string propertyName,SupportChartView supportChart, BarLineChartViewBase chartOriginal)
        {
            if (propertyName.Equals(SupportChartView.IsShowXAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.DrawGridLinesEnabled = (supportChart.IsShowXAxis);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowXAxisLineProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.DrawAxisLineEnabled = (supportChart.IsShowXAxisLine);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowLeftAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.LeftAxis.DrawGridLinesEnabled = (supportChart.IsShowLeftAxis);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowRightAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.RightAxis.DrawGridLinesEnabled = (supportChart.IsShowRightAxis);
                }
            }
            else if (propertyName.Equals(SupportChartView.DescriptionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.ChartDescription.Text = supportChart.Description;
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowLeftAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.LeftAxis.DrawLabelsEnabled = (supportChart.IsShowLeftAxisValue);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowRightAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.RightAxis.DrawLabelsEnabled = (supportChart.IsShowRightAxisValue);
                }
            }
            else if (propertyName.Equals(SupportChartView.IsShowXAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.DrawLabelsEnabled = (supportChart.IsShowXAxisValue);
                }
            }
            else if (propertyName.Equals(SupportChartView.XAxisPositionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.LabelPosition = GetXAxisPosition(supportChart.XAxisPosition);
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
                    chartOriginal.MultipleTouchEnabled = (supportChart.IsTouchEnabled);
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
        }
    }
}