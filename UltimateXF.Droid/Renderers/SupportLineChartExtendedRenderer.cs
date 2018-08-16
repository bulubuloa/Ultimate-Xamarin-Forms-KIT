using System;
using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers;
using UltimateXF.Droid.Renderers.Exporters;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportLineChartExtended), typeof(SupportLineChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportLineChartExtendedRenderer : ViewRenderer<SupportLineChartExtended, LineChart>
    {
        private SupportLineChartExtended supportChart;
        private LineChart originalChart;
        private LineChartExport ChartExport;

        public SupportLineChartExtendedRenderer(Context context) : base(context)
        {
            ChartExport = new LineChartExport();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportLineChartExtended> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportLineChartExtended)
                {
                    supportChart = Element as SupportLineChartExtended;
                    originalChart = new LineChart(this.Context);
                    originalChart.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
                    InitializeChart();
                    SetNativeControl(originalChart);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName.Equals(SupportLineChartExtended.ChartDataProperty.PropertyName))
            {
                InitializeChartData();
            }
            else if(e.PropertyName.Equals(SupportBarLineChartBase.AxisRightProperty.PropertyName))
            {
                SupportChartExtended.OnInitializeChartAxisRight(supportChart.AxisRight,originalChart);
            }
        }

        private void InitializeChart()
        {
            SupportChartExtended.OnInitializeChartBarLineBase(supportChart, originalChart);
            InitializeChartData();
        }

        private void InitializeChartData()
        {
            var data = supportChart.ChartData;
            originalChart.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(data.TitleItems);
            originalChart.Data = ChartExport.Export(data);
            originalChart.Invalidate();
        }
    }
}