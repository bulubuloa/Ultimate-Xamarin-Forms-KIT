using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportRadarChart), typeof(SupportRadarChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportRadarChartRenderer : ViewRenderer<SupportRadarChart, RadarChartView>
    {
        private SupportRadarChart supportChart;
        private RadarChartView chartOriginal;

        public SupportRadarChartRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportRadarChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportRadarChart)
                {
                    supportChart = Element as SupportRadarChart;
                    chartOriginal = new RadarChartView()
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

                var dataSetItems = supportChart.ChartData.DataSets;
                var listDataSetItems = new List<RadarChartDataSet>();

                //foreach (var itemChild in dataSetItems)
                //{
                //    var entryOriginal = itemChild.IF_GetEntry().Select(item => new RadarChartDataEntry(item.GetValue()));
                //    RadarChartDataSet dataSet = new RadarChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                //    if (itemChild.IF_GetDataColorScheme() != null)
                //        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                //    listDataSetItems.Add(dataSet);
                //}

                BubbleChartData data = new BubbleChartData(listDataSetItems.ToArray());
                //chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(supportChart.ChartData.TitleItems.ToArray());
                chartOriginal.Data = data;
            }
        }
    }
}