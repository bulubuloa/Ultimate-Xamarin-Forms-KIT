using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
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
            SupportChart.OnChartPropertyChanged(e.PropertyName,supportChart,chartOriginal);
        }

        private void InitializeChart()
        {
            if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
            {
                SupportChart.OnInitializeChart(supportChart,chartOriginal);

                var data = supportChart.ChartData;
                var dataSetItems = new List<BarChartDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.BarChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                    BarChartDataSet lineDataSet = new BarChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    if (itemChild.IF_GetDataColorScheme() != null)
                        lineDataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                    lineDataSet.DrawValuesEnabled = (itemChild.IF_GetDrawValue());
                    dataSetItems.Add(lineDataSet);
                }

                BarChartData lineData = new BarChartData(dataSetItems.ToArray());
                chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(data.TitleItems.ToArray());
                chartOriginal.Data = lineData;
            }
        }
    }
}