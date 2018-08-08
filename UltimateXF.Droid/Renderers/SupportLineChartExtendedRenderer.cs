using System;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Widget.Charts;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers
{
    public class SupportLineChartExtendedRenderer : ViewRenderer<SupportLineChartExtended, LineChart>
    {
        private SupportLineChartExtended supportLineChart;
        private LineChart lineChart;

        protected SupportLineChartExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportLineChartExtended> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportLineChartExtended)
                {
                    supportLineChart = Element as SupportLineChartExtended;
                    lineChart = new LineChart(this.Context);
                    lineChart.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
                    InitializeChart();
                    SetNativeControl(lineChart);
                }
            }
        }

        private void InitializeChart()
        {
            if (supportLineChart != null && supportLineChart.ChartData != null && lineChart != null)
            {
                SupportChart.OnInitializeChart(supportLineChart, lineChart);
                var data = supportLineChart.ChartData;
                lineChart.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(data.TitleItems);
                lineChart.Data = ChartExport.Export(data);
            }
        }
    }
}
