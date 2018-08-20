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

[assembly: ExportRenderer(typeof(SupportRadarChart), typeof(SupportRadarChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportRadarChartRenderer : ViewRenderer<SupportRadarChart, RadarChart>
    {
        private SupportRadarChart supportChart;
        private RadarChart chartOriginal;

        public SupportRadarChartRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportRadarChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportRadarChart)
                {
                    supportChart = Element as SupportRadarChart;
                    chartOriginal = new RadarChart(this.Context);
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
            SupportChart.OnChartPropertyChanged(e.PropertyName,supportChart, chartOriginal);
        }

        private void InitializeChart()
        {
            if (supportChart != null && supportChart.ChartData != null && chartOriginal != null)
            {
                SupportChart.OnInitializeChart(supportChart, chartOriginal);

                var dataSetItems = supportChart.ChartData.DataSets;
                var listDataSetItems = new List<RadarDataSet>();

                //foreach (var itemChild in dataSetItems)
                //{
                //    var entryOriginal = itemChild.IF_GetEntry().Select(item => new RadarEntry(item.GetValue()));
                //    RadarDataSet dataSet = new RadarDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                //    if (itemChild.IF_GetDataColorScheme() != null)
                //        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
                //    listDataSetItems.Add(dataSet);
                //}

                RadarData data = new RadarData(listDataSetItems.ToArray());
                //chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(supportChart.ChartData.TitleItems);
                chartOriginal.Data = data;
            }
        }
    }
}