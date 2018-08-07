using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using UltimateXF.Droid.Renderers;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportCombinedChart), typeof(SupportCombinedChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportCombinedChartRenderer : ViewRenderer<SupportCombinedChart, CombinedChart>
    {
        private SupportCombinedChart supportChart;
        private CombinedChart chartOriginal;

        private LineChartExport lineChartExport;
        private ScatterChartExport scatterChartExport;
        private CandleStickChartExport candleStickChartExport;
        private BarChartExport barChartExport;
        private BubbleChartExport bubbleChartExport;

        public SupportCombinedChartRenderer(Context context) : base(context)
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
                    chartOriginal = new CombinedChart(this.Context);
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
                var data = supportChart.ChartData;

                var CombinChartData = new CombinedData();
                CombinChartData.SetData(lineChartExport.Export(data.GetLineData()));
                CombinChartData.SetData(barChartExport.Export(data.GetBarData()));
                CombinChartData.SetData(bubbleChartExport.Export(data.GetBubbleData()));
                CombinChartData.SetData(candleStickChartExport.Export(data.GetCandleData()));
                CombinChartData.SetData(scatterChartExport.Export(data.GetScatterData()));
                chartOriginal.Data = CombinChartData;
            }
        }
    }
}