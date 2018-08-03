using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Components;
using MikePhil.Charting.Data;
using UltimateXF.Droid.Renderers;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportBarChart), typeof(SupportBarChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportBarChartRenderer : ViewRenderer<SupportBarChart, BarChart>
    {
        private SupportBarChart supportChart;
        private BarChart chartOriginal;

        public SupportBarChartRenderer(Context context) : base(context)
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
                    chartOriginal = new BarChart(this.Context);
                    chartOriginal.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
                    InitializeChart();
                    SetNativeControl(chartOriginal);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName.Equals(SupportLineChart.ChartDataProperty.PropertyName))
            {
                InitializeChart();
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisProperty.PropertyName))
            {
                if(chartOriginal!=null && supportChart!=null)
                {
                    chartOriginal.XAxis.SetDrawGridLines(supportChart.IsShowXAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisLineProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.SetDrawAxisLine(supportChart.IsShowXAxisLine);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowLeftAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisLeft.SetDrawGridLines(supportChart.IsShowLeftAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowRightAxisProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisRight.SetDrawGridLines(supportChart.IsShowRightAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.DescriptionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.Description.Text = supportChart.Description;
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowLeftAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisLeft.SetDrawLabels(supportChart.IsShowLeftAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowRightAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.AxisRight.SetDrawLabels(supportChart.IsShowRightAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.IsShowXAxisValueProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.SetDrawLabels(supportChart.IsShowXAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportChartView.XAxisPositionProperty.PropertyName))
            {
                if (chartOriginal != null && supportChart != null)
                {
                    chartOriginal.XAxis.Position = GetXAxisPosition(supportChart.XAxisPosition);
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
                    chartOriginal.SetTouchEnabled(supportChart.IsTouchEnabled);
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

        private LineDataSet.Mode GetDrawLineMode(LineDataSetMode mode)
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

        private XAxis.XAxisPosition GetXAxisPosition(XAXISPosition mode)
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

        private void InitializeChart()
        {
            if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
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

                var data = supportChart.ChartData;
                var dataSetItems = new List<BarDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select (item => new MikePhil.Charting.Data.BarEntry(item.GetXPosition(), item.GetYPosition()));
                    BarDataSet lineDataSet = new BarDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    lineDataSet.Color = itemChild.IF_GetDataColor().ToAndroid();
                    lineDataSet.SetDrawValues(itemChild.IF_GetDrawValue());
                    dataSetItems.Add(lineDataSet);
                }

                BarData lineData = new BarData(dataSetItems.ToArray());
                chartOriginal.Data = lineData;

            }
        }
    }
}