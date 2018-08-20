using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportLineChart), typeof(SupportLineChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportLineChartRenderer : ViewRenderer<SupportLineChart, LineChart>
    {
        private SupportLineChart supportLineChart;
        private LineChart lineChart;
        private LineChartExport ChartExport;

        public SupportLineChartRenderer(Context context) : base(context)
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
                    supportLineChart = Element as SupportLineChart;
                    lineChart = new LineChart(this.Context);
                    lineChart.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
                    InitializeChart();
                    SetNativeControl(lineChart);
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
            SupportChart.OnChartPropertyChanged(e.PropertyName, supportLineChart, lineChart);
        }

        private void InitializeChart()
        {
            if (supportLineChart != null && supportLineChart.ChartData != null && lineChart != null)
            {
                SupportChart.OnInitializeChart(supportLineChart,lineChart);
                var data = supportLineChart.ChartData;
                //lineChart.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(data.TitleItems);
                lineChart.Data = ChartExport.Export(data);
            }
        }
    }
}