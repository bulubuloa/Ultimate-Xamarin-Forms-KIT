using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.LineChart;
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
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new ChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                    var dataSet = new LineChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    if (itemChild.IF_GetDataColorScheme() != null)
                        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                    IntializeDataSet(itemChild, dataSet);
                    dataSetItems.Add(dataSet);
                }

                var lineData = new iOSCharts.LineChartData(dataSetItems.ToArray());
                lineChart.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(data.TitleItems.ToArray());
                lineChart.Data = lineData;
            }
        }

        private void IntializeDataSet(ILineDataSet source, LineChartDataSet original)
        {
            if (source.IF_GetDrawMode().HasValue)
                original.Mode = (SupportChart.GetDrawLineMode(source.IF_GetDrawMode().Value));

            if (source.IF_GetCircleRadius().HasValue)
                original.CircleRadius = source.IF_GetCircleRadius().Value;

            if (source.IF_GetCircleHoleRadius().HasValue)
                original.CircleHoleRadius = source.IF_GetCircleHoleRadius().Value;

            if (source.IF_GetDrawCircle().HasValue)
                original.DrawCirclesEnabled = (source.IF_GetDrawCircle().Value);

            if (source.IF_GetCircleColors().Count > 0)
                original.CircleColors = source.IF_GetCircleColors().Select(item => item.ToUIColor()).ToArray();

            if (source.IF_GetDrawFilled().HasValue)
                original.DrawFilledEnabled = (source.IF_GetDrawFilled().Value);

            if (source.IF_GetLineWidth().HasValue)
                original.LineWidth = source.IF_GetLineWidth().Value;
        }
    }
}