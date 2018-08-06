using System;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportPieChart), typeof(SupportPieChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportPieChartRenderer : ViewRenderer<SupportPieChart, PieChartView>
    {
        private SupportPieChart supportChart;
        private PieChartView chartOriginal;

        public SupportPieChartRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportPieChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportPieChart)
                {
                    supportChart = Element as SupportPieChart;
                    chartOriginal = new PieChartView()
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
            if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
            {
                var data = supportChart.ChartData.IF_GetDataSet();

                var entryOriginal = data.IF_GetEntry().Select(item => new ChartDataEntry(item.GetPercent(),item.GetPercent()));
                PieChartDataSet lineDataSet = new PieChartDataSet(entryOriginal.ToArray(), data.IF_GetTitle());
                lineDataSet.SetColors(data.IF_GetEntry().Select(item => item.GetColorFill().ToUIColor()).ToArray(),1f);
                PieChartData lineData = new PieChartData(new PieChartDataSet[]{lineDataSet} );

                //lineData.SetValueTextSize(supportChart.ChartData.ValueDisplaySize);
                lineData.SetValueTextColor(supportChart.ChartData.ValueDisplayColor.ToUIColor());
                chartOriginal.EntryLabelColor = (supportChart.ChartData.TextDisplayColor.ToUIColor());
                //chartOriginal.SetEntryLabelTextSize(supportChart.ChartData.TextDisplaySize);

                //chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(data.IF_GetEntry().Select(item => item.GetText()).ToArray());
                chartOriginal.Data = lineData;
            }
        }
    }
}