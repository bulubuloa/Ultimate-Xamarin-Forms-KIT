using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportCandleStickChart), typeof(SupportCandleStickChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportCandleStickChartRenderer : ViewRenderer<SupportCandleStickChart, CandleStickChartView>
    {
        private SupportCandleStickChart supportChart;
        private CandleStickChartView chartOriginal;

        public SupportCandleStickChartRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportCandleStickChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportCandleStickChart)
                {
                    supportChart = Element as SupportCandleStickChart;
                    chartOriginal = new CandleStickChartView()
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
            SupportChart.OnChartPropertyChanged(e.PropertyName, supportChart, chartOriginal);
        }

        private void InitializeChart()
        {
            if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
            {
                SupportChart.OnInitializeChart(supportChart, chartOriginal);

                var dataSetItems = supportChart.ChartData.IF_GetDataSet();
                var listDataSetItems = new List<CandleChartDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new CandleChartDataEntry(item.GetXPosition(), item.GetHigh(), item.GetLow(), item.GetOpen(), item.GetClose()));
                    CandleChartDataSet dataSet = new CandleChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle())
                    {
                        DecreasingColor = itemChild.IF_GetDecreasingColor().ToUIColor(),
                        IncreasingColor = itemChild.IF_GetIncreasingColor().ToUIColor(),
                        HighlightColor = itemChild.IF_GetHighLightColor().ToUIColor(),
                    };

                    listDataSetItems.Add(dataSet);
                }

                CandleChartData data = new CandleChartData(listDataSetItems.ToArray());
                chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(supportChart.ChartData.TitleItems.ToArray());
                chartOriginal.Data = data;
            }
        }
    }
}