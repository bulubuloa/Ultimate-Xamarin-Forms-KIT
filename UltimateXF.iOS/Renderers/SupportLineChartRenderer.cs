using System;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
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
                        Frame = new CoreGraphics.CGRect(0, 0, 300, 400)
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
        }

        private void InitializeChart()
        {
            if (supportLineChart != null && supportLineChart.ChartData != null && lineChart != null)
            {
                var data = supportLineChart.ChartData;
                var dataSet = data.IF_GetDataSet().FirstOrDefault();

                var entryOriginal = dataSet.IF_GetEntry().Select(item => new iOSCharts.ChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                LineChartDataSet lineDataSet = new LineChartDataSet(entryOriginal.ToArray(), dataSet.IF_GetTitle());
                LineChartData lineData = new LineChartData(new LineChartDataSet[]{lineDataSet});
                lineChart.Data = lineData;
            }
        }
    }
}
