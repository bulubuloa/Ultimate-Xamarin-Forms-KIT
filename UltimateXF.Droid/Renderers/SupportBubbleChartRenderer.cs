using System;
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

[assembly: ExportRenderer(typeof(SupportBubbleChart), typeof(SupportBubbleChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportBubbleChartRenderer : ViewRenderer<SupportBubbleChart, BubbleChart>
    {
        private SupportBubbleChart supportChart;
        private BubbleChart chartOriginal;

        public SupportBubbleChartRenderer(Context context) : base(context)
        {
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
                var dataSetItems = supportChart.ChartData.IF_GetDataSet();
                var listDataSetItems = new List<BubbleDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new BubbleEntry(item.GetXPosition(), item.GetYPosition(),item.GetSize()));
                    BubbleDataSet dataSet = new BubbleDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    if (itemChild.IF_GetDataColorScheme() != null)
                        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
                    listDataSetItems.Add(dataSet);
                }
                
                BubbleData data = new BubbleData(listDataSetItems.ToArray());
                chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(supportChart.ChartData.TitleItems);
                chartOriginal.Data = data;
            }
        }
    }
}