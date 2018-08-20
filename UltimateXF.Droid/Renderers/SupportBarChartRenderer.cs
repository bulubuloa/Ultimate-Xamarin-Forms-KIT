using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportBarChart), typeof(SupportBarChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportBarChartRenderer : ViewRenderer<SupportBarChart, BarChart>
    {
        private SupportBarChart supportChart;
        private BarChart chartOriginal;
        private BarChartExport ChartExport;

        public SupportBarChartRenderer(Context context) : base(context)
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
                    chartOriginal = new BarChart(this.Context);
                    chartOriginal.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
                    InitializeChart();
                    SetNativeControl(chartOriginal);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName.Equals(SupportLineChart.ChartDataProperty.PropertyName))
            {
                InitializeChart();
            }
            SupportChart.OnChartPropertyChanged(e.PropertyName,supportChart, chartOriginal);
        }

        private void InitializeChart()
        {
            if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
            {
                SupportChart.OnInitializeChart(supportChart,chartOriginal);
                var data = supportChart.ChartData;
                //chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(data.TitleItems);
                chartOriginal.Data = ChartExport.Export(data);
            }
        }
    }
}