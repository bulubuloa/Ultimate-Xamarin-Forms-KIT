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

[assembly: ExportRenderer(typeof(SupportBarChart), typeof(SupportBarChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportBarChartRenderer : ViewRenderer<SupportBarChart, BarChartView>
    {
        private SupportBarChart supportChart;
        private BarChartView chartOriginal;

        public SupportBarChartRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportBarChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportBarChart)
                {
                    supportChart = Element as SupportBarChart;
                    chartOriginal = new BarChartView()
                    {
                        Frame = this.Frame
                    };
                    InitializeChart();
                    SetNativeControl(chartOriginal);
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
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.DrawGridLinesEnabled = (supportChart.IsShowXAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisLineProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.DrawAxisLineEnabled = (supportChart.IsShowXAxisLine);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowLeftAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.LeftAxis.DrawGridLinesEnabled = (supportChart.IsShowLeftAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowRightAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.RightAxis.DrawGridLinesEnabled = (supportChart.IsShowRightAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.DescriptionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.ChartDescription.Text = supportChart.Description;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowLeftAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.LeftAxis.DrawLabelsEnabled = (supportChart.IsShowLeftAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowRightAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.RightAxis.DrawLabelsEnabled = (supportChart.IsShowRightAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.DrawLabelsEnabled = (supportChart.IsShowXAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.XAxisPositionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.LabelPosition = GetXAxisPosition(supportChart.XAxisPosition);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsDragEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.DragEnabled = supportChart.IsDragEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsTouchEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.MultipleTouchEnabled = (supportChart.IsTouchEnabled);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsDoubleTapToZoomEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.DoubleTapToZoomEnabled = supportChart.IsDoubleTapToZoomEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsScaleXEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.ScaleXEnabled = supportChart.IsScaleXEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsScaleYEnabledProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.ScaleYEnabled = supportChart.IsScaleYEnabled;
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
            if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
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

                var data = supportChart.ChartData;
                var dataSetItems = new List<BarChartDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.BarChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                    BarChartDataSet lineDataSet = new BarChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    lineDataSet.SetColor(itemChild.IF_GetDataColor().ToUIColor());
                    lineDataSet.DrawValuesEnabled = (itemChild.IF_GetDrawValue());
                    dataSetItems.Add(lineDataSet);
                }

                BarChartData lineData = new BarChartData(dataSetItems.ToArray());
                chartOriginal.Data = lineData;
            }
        }
    }
}