using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.iOS.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportLineChart), typeof(SupportLineChartRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportLineChartRenderer : ViewRenderer<SupportLineChart, LineChartView>
    {
        private SupportLineChart supportChart;
        private LineChartView chartOriginal;
        private LineChartExport ChartExport;

        public SupportLineChartRenderer()
        {
            ChartExport = new LineChartExport();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportLineChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportLineChart)
                {
                    supportChart = Element as SupportLineChart;
                    chartOriginal = new LineChartView()
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
                chartOriginal.Data = ChartExport.Export(supportChart.ChartData);;
            }
        }
    }
}