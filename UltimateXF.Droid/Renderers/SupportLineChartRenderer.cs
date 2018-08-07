using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using UltimateXF.Droid.Renderers;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.LineChart;
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
                var dataSetItems = new List<MikePhil.Charting.Data.LineDataSet>();

                foreach (var itemChild in data.IF_GetDataSet())
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select (item => new MikePhil.Charting.Data.Entry(item.GetXPosition(), item.GetYPosition()));
                    var dataSet = new MikePhil.Charting.Data.LineDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());

                    if (itemChild.IF_GetDataColorScheme() != null)
                        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());

                    IntializeDataSet(itemChild,dataSet);
                    dataSetItems.Add(dataSet);
                }

                LineData lineData = new LineData(dataSetItems.ToArray());
                lineChart.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(data.TitleItems);
                lineChart.Data = lineData;
            }
        }

        private void IntializeDataSet(ILineDataSet source, MikePhil.Charting.Data.LineDataSet original)
        {
            if (source.IF_GetDrawMode().HasValue)
                original.SetMode(SupportChart.GetDrawLineMode(source.IF_GetDrawMode().Value));

            if (source.IF_GetCircleRadius().HasValue)
                original.CircleRadius = source.IF_GetCircleRadius().Value;

            if (source.IF_GetCircleHoleRadius().HasValue)
                original.CircleHoleRadius = source.IF_GetCircleHoleRadius().Value;

            if (source.IF_GetDrawCircle().HasValue)
                original.SetDrawCircles(source.IF_GetDrawCircle().Value);

            if (source.IF_GetCircleColors().Count > 0)
                original.SetCircleColors(source.IF_GetCircleColors().Select(item => item.ToAndroid().ToArgb()).ToArray());

            if (source.IF_GetDrawFilled().HasValue)
                original.SetDrawFilled(source.IF_GetDrawFilled().Value);

            if (source.IF_GetLineWidth().HasValue)
                original.LineWidth = source.IF_GetLineWidth().Value;
        }
    }
}