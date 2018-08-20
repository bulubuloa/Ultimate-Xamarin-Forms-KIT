using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportBubbleChart), typeof(SupportBubbleChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportBubbleChartRenderer : ViewRenderer<SupportBubbleChart, BubbleChart>
    {
        private SupportBubbleChart supportChart;
        private BubbleChart chartOriginal;
        private BubbleChartExport ChartExport;

        public SupportBubbleChartRenderer(Context context) : base(context)
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
                    chartOriginal = new BubbleChart(this.Context);
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