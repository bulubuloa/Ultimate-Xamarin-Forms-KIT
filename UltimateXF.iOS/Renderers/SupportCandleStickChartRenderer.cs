using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.iOS.Renderers.Exporters;
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
        private CandleStickChartExport ChartExport;

        public SupportCandleStickChartRenderer()
        {
            ChartExport = new CandleStickChartExport();
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
                chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(supportChart.ChartData.TitleItems.ToArray());
                chartOriginal.Data = ChartExport.Export(supportChart.ChartData);
            }
        }
    }
}