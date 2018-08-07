using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.iOS.Renderers.Exporters;
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
        private ScatterChartExport ChartExport;

        public SupportScatterChartRenderer()
        {
            ChartExport = new ScatterChartExport();
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