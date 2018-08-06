using System;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportScatterChart), typeof(SupportScatterChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportScatterChartRenderer : ViewRenderer<SupportScatterChart, ScatterChartView>
    {
        private SupportScatterChart supportChart;
        private ScatterChartView chartOriginal;

        public SupportScatterChartRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportScatterChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportScatterChart)
                {
                    supportChart = Element as SupportScatterChart;
                    chartOriginal = new ScatterChartView()
                    {
                        Frame = this.Frame
                    };
                    InitializeChart();
                    SetNativeControl(chartOriginal);
                }
            }
        }

        private void InitializeChart()
        {
            //if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
            //{
            //    var dataSetItems = supportChart.ChartData.IF_GetDataSet();
            //    var listDataSetItems = new List<CandleChartDataSet>();

            //    foreach (var itemChild in dataSetItems)
            //    {
            //        var entryOriginal = itemChild.IF_GetEntry().Select(item => new CandleChartDataEntry(item.GetXPosition(), item.GetHigh(), item.GetLow(), item.GetOpen(), item.GetClose())));
            //        CandleChartDataSet dataSet = new CandleChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
            //        listDataSetItems.Add(dataSet);
            //    }

            //    CandleChartData data = new CandleChartData(listDataSetItems.ToArray());
            //    chartOriginal.Data = data;
            //}
        }
    }
}