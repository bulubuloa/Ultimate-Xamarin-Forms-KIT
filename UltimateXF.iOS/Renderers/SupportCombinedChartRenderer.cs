using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.iOS.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportCombinedChart), typeof(SupportCombinedChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportCombinedChartRenderer : ViewRenderer<SupportCombinedChart, CombinedChartView>
    {
        private SupportCombinedChart supportChart;
        private CombinedChartView chartOriginal;

        private LineChartExport lineChartExport;
        private ScatterChartExport scatterChartExport;
        private CandleStickChartExport candleStickChartExport;
        private BarChartExport barChartExport;
        private BubbleChartExport bubbleChartExport;

        public SupportCombinedChartRenderer()
        {
            lineChartExport = new LineChartExport();
            scatterChartExport = new ScatterChartExport();
            candleStickChartExport = new CandleStickChartExport();
            barChartExport = new BarChartExport();
            bubbleChartExport = new BubbleChartExport();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportCombinedChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportCombinedChart)
                {
                    supportChart = Element as SupportCombinedChart;
                    chartOriginal = new CombinedChartView()
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
                SupportChart.OnInitializeChart(supportChart,chartOriginal);

                var data = supportChart.ChartData;

                var CombinChartData = new CombinedChartData();
                CombinChartData.LineData = lineChartExport.Export(data.GetLineData());
                CombinChartData.BarData = barChartExport.Export(data.GetBarData());
                CombinChartData.BubbleData = bubbleChartExport.Export(data.GetBubbleData());
                CombinChartData.CandleData = candleStickChartExport.Export(data.GetCandleData());
                CombinChartData.ScatterData = scatterChartExport.Export(data.GetScatterData());
                chartOriginal.Data = CombinChartData;
            }
        }
    }
}