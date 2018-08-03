using System.Collections.Generic;
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
            SupportChart.OnChartPropertyChanged(e.PropertyName, supportLineChart, lineChart);
        }

        private void InitializeChart()
        {
            if (supportLineChart != null && supportLineChart.ChartData != null && lineChart != null)
            {
                SupportChart.OnInitializeChart(supportLineChart,lineChart);


                var data = supportLineChart.ChartData;
                var dataSetItems = new List<LineChartDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.ChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                    LineChartDataSet lineDataSet = new LineChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    lineDataSet.SetColor(itemChild.IF_GetDataColor().ToUIColor());
                    lineDataSet.Mode = (SupportChart.GetDrawLineMode(itemChild.IF_GetDrawMode()));
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