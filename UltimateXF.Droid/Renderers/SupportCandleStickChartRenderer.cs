using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportCandleStickChart), typeof(SupportCandleStickChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportCandleStickChartRenderer : ViewRenderer<SupportCandleStickChart, CandleStickChart>
    {
        private SupportCandleStickChart supportChart;
        private CandleStickChart chartOriginal;
        private CandleStickChartExport ChartExport;

        public SupportCandleStickChartRenderer(Context context) : base(context)
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
                    chartOriginal = new CandleStickChart(this.Context);
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
                //chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(supportChart.ChartData.TitleItems);
                chartOriginal.Data = ChartExport.Export(supportChart.ChartData);
            }
        }
    }
}