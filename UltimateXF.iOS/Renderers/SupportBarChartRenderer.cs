using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers;
using UltimateXF.iOS.Renderers.Exporters;
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
        private BarChartExport ChartExport;

        public SupportBarChartRenderer()
        {
            ChartExport = new BarChartExport();
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
                SupportChart.OnInitializeChart(supportChart, chartOriginal);
                chartOriginal.XAxis.ValueFormatter = new ChartIndexAxisValueFormatter(supportChart.ChartData.TitleItems.ToArray());
                chartOriginal.Data = ChartExport.Export(supportChart.ChartData);
            }
        }
    }
}