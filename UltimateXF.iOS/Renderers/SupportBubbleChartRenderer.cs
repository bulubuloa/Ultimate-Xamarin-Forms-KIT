using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportBubbleChart), typeof(SupportBubbleChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportBubbleChartRenderer : ViewRenderer<SupportBubbleChart, BubbleChartView>
    {
        private SupportBubbleChart supportChart;
        private BubbleChartView chartOriginal;

        public SupportBubbleChartRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportBubbleChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportBubbleChart)
                {
                    supportChart = Element as SupportBubbleChart;
                    chartOriginal = new BubbleChartView()
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
                var listDataSetItems = new List<BubbleChartDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new BubbleChartDataEntry(item.GetXPosition(), item.GetYPosition(), item.GetSize()));
                    BubbleChartDataSet dataSet = new BubbleChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    listDataSetItems.Add(dataSet);
                }

                BubbleChartData data = new BubbleChartData(listDataSetItems.ToArray());
                chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(supportChart.ChartData.TitleItems.ToArray());
                chartOriginal.Data = data;
            }
        }
    }
}