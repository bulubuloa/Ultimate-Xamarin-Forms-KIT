using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportScatterChart), typeof(SupportScatterChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportScatterChartRenderer : ViewRenderer<SupportScatterChart, ScatterChart>
    {
        private SupportScatterChart supportChart;
        private ScatterChart chartOriginal;
        private ScatterChartExport ChartExport;

        public SupportScatterChartRenderer(Context context) : base(context)
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
                    chartOriginal = new ScatterChart(this.Context);
                    chartOriginal.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
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
                chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(supportChart.ChartData.TitleItems);
                chartOriginal.Data = ChartExport.Export(supportChart.ChartData);
            }
        }
    }
}