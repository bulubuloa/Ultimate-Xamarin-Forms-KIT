using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using UltimateXF.Droid.Renderers;
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

        public SupportBarChartRenderer(Context context) : base(context)
        {
            
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
                var dataSetItems = new List<BarDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select (item => new MikePhil.Charting.Data.BarEntry(item.GetXPosition(), item.GetYPosition()));
                    BarDataSet lineDataSet = new BarDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    lineDataSet.Color = itemChild.IF_GetDataColor().ToAndroid();
                    lineDataSet.SetDrawValues(itemChild.IF_GetDrawValue());
                    dataSetItems.Add(lineDataSet);
                }

                BarData lineData = new BarData(dataSetItems.ToArray());
                chartOriginal.Data = lineData;

            }
        }
    }
}