using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.iOS.Renderers.Exporters;
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
        private BubbleChartExport ChartExport;

        public SupportBubbleChartRenderer()
        {
            ChartExport = new BubbleChartExport();
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
                chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(supportChart.ChartData.TitleItems.ToArray());
                chartOriginal.Data = ChartExport.Export(supportChart.ChartData);
            }
        }
    }
}