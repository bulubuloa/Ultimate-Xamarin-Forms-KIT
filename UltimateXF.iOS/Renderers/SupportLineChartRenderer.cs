using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportLineChart), typeof(SupportLineChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportLineChartRenderer : ViewRenderer<SupportLineChart, LineChartView>
    {
        private SupportLineChart supportLineChart;
        private LineChartView lineChart;

        public SupportLineChartRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportLineChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportLineChart)
                {
                    supportLineChart = Element as SupportLineChart;
                    lineChart = new LineChartView()
                    {
                        Frame = this.Frame
                    };
                    InitializeChart();
                    SetNativeControl(lineChart);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(SupportLineChart.ChartDataProperty.PropertyName))
            {
                InitializeChart();
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.XAxis.DrawGridLinesEnabled = (supportLineChart.IsShowXAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisLineProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.XAxis.DrawAxisLineEnabled = (supportLineChart.IsShowXAxisLine);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowLeftAxisProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.LeftAxis.DrawGridLinesEnabled = (supportLineChart.IsShowLeftAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowRightAxisProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.RightAxis.DrawGridLinesEnabled = (supportLineChart.IsShowRightAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.DescriptionProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.ChartDescription.Text = supportLineChart.Description;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowLeftAxisValueProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.LeftAxis.DrawLabelsEnabled = (supportLineChart.IsShowLeftAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowRightAxisValueProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.RightAxis.DrawLabelsEnabled = (supportLineChart.IsShowRightAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisValueProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.XAxis.DrawLabelsEnabled = (supportLineChart.IsShowXAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.XAxisPositionProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.XAxis.LabelPosition = GetXAxisPosition(supportLineChart.XAxisPosition);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsDragEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.DragEnabled = supportLineChart.IsDragEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsTouchEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.MultipleTouchEnabled = (supportLineChart.IsTouchEnabled);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsDoubleTapToZoomEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.DoubleTapToZoomEnabled = supportLineChart.IsDoubleTapToZoomEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsScaleXEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.ScaleXEnabled = supportLineChart.IsScaleXEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsScaleYEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.ScaleYEnabled = supportLineChart.IsScaleYEnabled;
                }
            }
        }

        private LineChartMode GetDrawLineMode(LineDataSetMode mode)
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

        private XAxisLabelPosition GetXAxisPosition(XAXISPosition mode)
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

        private void InitializeChart()
        {
            if (supportLineChart != null && supportLineChart.ChartData != null && lineChart != null)
            {
                lineChart.XAxis.DrawGridLinesEnabled = (supportLineChart.IsShowXAxis);
                lineChart.XAxis.DrawAxisLineEnabled = (supportLineChart.IsShowXAxisLine);
                lineChart.XAxis.DrawLabelsEnabled = (supportLineChart.IsShowXAxisValue);
                lineChart.XAxis.LabelPosition = GetXAxisPosition(supportLineChart.XAxisPosition);

                lineChart.LeftAxis.DrawGridLinesEnabled = (supportLineChart.IsShowLeftAxis);
                lineChart.LeftAxis.DrawAxisLineEnabled = (supportLineChart.IsShowLeftAxisLine);
                lineChart.LeftAxis.DrawLabelsEnabled = (supportLineChart.IsShowLeftAxisValue);

                lineChart.RightAxis.DrawGridLinesEnabled = (supportLineChart.IsShowRightAxis);
                lineChart.RightAxis.DrawAxisLineEnabled = (supportLineChart.IsShowRightAxisLine);
                lineChart.RightAxis.DrawLabelsEnabled = (supportLineChart.IsShowRightAxisValue);

                lineChart.ChartDescription.Text = supportLineChart.Description;

                lineChart.DragEnabled = supportLineChart.IsDragEnabled;
                lineChart.MultipleTouchEnabled = (supportLineChart.IsTouchEnabled);
                lineChart.DoubleTapToZoomEnabled = supportLineChart.IsDoubleTapToZoomEnabled;
                lineChart.ScaleXEnabled = supportLineChart.IsScaleXEnabled;
                lineChart.ScaleYEnabled = supportLineChart.IsScaleYEnabled;

                var data = supportLineChart.ChartData;
                var dataSetItems = new List<LineChartDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.ChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                    LineChartDataSet lineDataSet = new LineChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    lineDataSet.SetColor(itemChild.IF_GetDataColor().ToUIColor());
                    lineDataSet.Mode = (GetDrawLineMode(itemChild.IF_GetDrawMode()));
                    lineDataSet.CircleRadius = itemChild.IF_GetCircleRadius();
                    lineDataSet.CircleHoleRadius = itemChild.IF_GetCircleHoleRadius();
                    lineDataSet.DrawCirclesEnabled = (itemChild.IF_GetDrawCircle());
                    lineDataSet.DrawValuesEnabled = (itemChild.IF_GetDrawValue());

                    var arrColor = itemChild.IF_GetCircleColors().Select(item => item.ToUIColor());
                    lineDataSet.SetCircleColor(itemChild.IF_GetCircleColor().ToUIColor());
                    dataSetItems.Add(lineDataSet);
                }

                LineChartData lineData = new LineChartData(dataSetItems.ToArray());
                lineChart.Data = lineData;
            }
        }
    }
}