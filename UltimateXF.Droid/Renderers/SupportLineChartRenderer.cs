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

[assembly: ExportRenderer(typeof(SupportLineChart), typeof(SupportLineChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportLineChartRenderer : ViewRenderer<SupportLineChart, LineChart>
    {
        private SupportLineChart supportLineChart;
        private LineChart lineChart;

        public SupportLineChartRenderer(Context context) : base(context)
        {
            
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
                var dataSetItems = new List<LineDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select (item => new MikePhil.Charting.Data.Entry(item.GetXPosition(), item.GetYPosition()));
                    LineDataSet lineDataSet = new LineDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    if (itemChild.IF_GetDataColorScheme() != null)
                        lineDataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
                    
                    lineDataSet.SetMode(SupportChart.GetDrawLineMode(itemChild.IF_GetDrawMode()));
                    lineDataSet.CircleRadius = itemChild.IF_GetCircleRadius();
                    lineDataSet.CircleHoleRadius = itemChild.IF_GetCircleHoleRadius();
                    lineDataSet.SetDrawCircles(itemChild.IF_GetDrawCircle());
                    lineDataSet.SetDrawValues(itemChild.IF_GetDrawValue());

                    var arrColor = itemChild.IF_GetCircleColors().Select(item => item.ToAndroid());
                    lineDataSet.SetCircleColor(itemChild.IF_GetCircleColor().ToAndroid());
                    dataSetItems.Add(lineDataSet);
                }

                LineData lineData = new LineData(dataSetItems.ToArray());
                lineChart.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(data.TitleItems);
                lineChart.Data = lineData;
            }
        }
    }
}