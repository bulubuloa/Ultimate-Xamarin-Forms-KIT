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

[assembly: ExportRenderer(typeof(SupportLineChart), typeof(SupportLineChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportLineChartRenderer : ViewRenderer<SupportLineChart, LineChart>
    {
        private SupportLineChart supportLineChart;
        private LineChart lineChart;

        public SupportLineChartRenderer(Context context) : base(context)
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
                    lineChart = new LineChart(this.Context);
                    lineChart.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
                    InitializeChart();
                    SetNativeControl(lineChart);
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
            else if (e.PropertyName.Equals(SupportLineChart.IsShowXAxisProperty.PropertyName))
            {
                if(lineChart!=null && supportLineChart!=null)
                {
                    lineChart.XAxis.SetDrawGridLines(supportLineChart.IsShowXAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsShowXAxisLineProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.XAxis.SetDrawAxisLine(supportLineChart.IsShowXAxisLine);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsShowLeftAxisProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.AxisLeft.SetDrawGridLines(supportLineChart.IsShowLeftAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsShowRightAxisProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.AxisRight.SetDrawGridLines(supportLineChart.IsShowRightAxis);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.DescriptionProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.Description.Text = supportLineChart.Description;
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsShowLeftAxisValueProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.AxisLeft.SetDrawLabels(supportLineChart.IsShowLeftAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsShowRightAxisValueProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.AxisRight.SetDrawLabels(supportLineChart.IsShowRightAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsShowXAxisValueProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.XAxis.SetDrawLabels(supportLineChart.IsShowXAxisValue);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.XAxisPositionProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.XAxis.Position = GetXAxisPosition(supportLineChart.XAxisPosition);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsDragEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.DragEnabled = supportLineChart.IsDragEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsTouchEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.SetTouchEnabled(supportLineChart.IsTouchEnabled);
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsDoubleTapToZoomEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.DoubleTapToZoomEnabled = supportLineChart.IsDoubleTapToZoomEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsScaleXEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.ScaleXEnabled = supportLineChart.IsScaleXEnabled;
                }
            }
            else if (e.PropertyName.Equals(SupportLineChart.IsScaleYEnabledProperty.PropertyName))
            {
                if (lineChart != null && supportLineChart != null)
                {
                    lineChart.ScaleYEnabled = supportLineChart.IsScaleYEnabled;
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
            if (supportLineChart != null && supportLineChart.ChartData != null && lineChart != null)
            {
                lineChart.XAxis.SetDrawGridLines(supportLineChart.IsShowXAxis);
                lineChart.XAxis.SetDrawAxisLine(supportLineChart.IsShowXAxisLine);
                lineChart.XAxis.SetDrawLabels(supportLineChart.IsShowXAxisValue);
                lineChart.XAxis.Position = GetXAxisPosition(supportLineChart.XAxisPosition);

                lineChart.AxisLeft.SetDrawGridLines(supportLineChart.IsShowLeftAxis);
                lineChart.AxisLeft.SetDrawAxisLine(supportLineChart.IsShowLeftAxisLine);
                lineChart.AxisLeft.SetDrawLabels(supportLineChart.IsShowLeftAxisValue);

                lineChart.AxisRight.SetDrawGridLines(supportLineChart.IsShowRightAxis);
                lineChart.AxisRight.SetDrawAxisLine(supportLineChart.IsShowRightAxisLine);
                lineChart.AxisRight.SetDrawLabels(supportLineChart.IsShowRightAxisValue);

                lineChart.Description.Text = supportLineChart.Description;

                lineChart.DragEnabled = supportLineChart.IsDragEnabled;
                lineChart.SetTouchEnabled(supportLineChart.IsTouchEnabled);
                lineChart.DoubleTapToZoomEnabled = supportLineChart.IsDoubleTapToZoomEnabled;
                lineChart.ScaleXEnabled = supportLineChart.IsScaleXEnabled;
                lineChart.ScaleYEnabled = supportLineChart.IsScaleYEnabled;

                var data = supportLineChart.ChartData;
                var dataSetItems = new List<LineDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select (item => new MikePhil.Charting.Data.Entry(item.GetXPosition(), item.GetYPosition()));
                    LineDataSet lineDataSet = new LineDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    lineDataSet.Color = itemChild.IF_GetDataColor().ToAndroid();
                    lineDataSet.SetMode(GetDrawLineMode(itemChild.IF_GetDrawMode()));
                    lineDataSet.CircleRadius = itemChild.IF_GetCircleRadius();
                    lineDataSet.CircleHoleRadius = itemChild.IF_GetCircleHoleRadius();
                    lineDataSet.SetDrawCircles(itemChild.IF_GetDrawCircle());
                    lineDataSet.SetDrawValues(itemChild.IF_GetDrawValue());

                    var arrColor = itemChild.IF_GetCircleColors().Select(item => item.ToAndroid());
                    lineDataSet.SetCircleColor(itemChild.IF_GetCircleColor().ToAndroid());
                    dataSetItems.Add(lineDataSet);
                }

                LineData lineData = new LineData(dataSetItems.ToArray());
                lineChart.Data = lineData;

            }
        }
    }
}