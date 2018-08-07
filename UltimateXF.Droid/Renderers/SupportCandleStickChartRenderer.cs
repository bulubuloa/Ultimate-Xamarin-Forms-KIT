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

[assembly: ExportRenderer(typeof(SupportCandleStickChart), typeof(SupportCandleStickChartRenderer))]
namespace UltimateXF.Droid.Renderers
{
    public class SupportCandleStickChartRenderer : ViewRenderer<SupportCandleStickChart, CandleStickChart>
    {
        private SupportCandleStickChart supportChart;
        private CandleStickChart chartOriginal;

        public SupportCandleStickChartRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportCandleStickChart> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportCandleStickChart)
                {
                    supportChart = Element as SupportCandleStickChart;
                    chartOriginal = new CandleStickChart(this.Context);
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
                var listDataSetItems = new List<CandleDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new CandleEntry(item.GetXPosition(),item.GetHigh(),item.GetLow(),item.GetOpen(),item.GetClose()));
                    CandleDataSet dataSet = new CandleDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle())
                    {
                        DecreasingColor = itemChild.IF_GetDecreasingColor().ToAndroid(),
                        IncreasingColor = itemChild.IF_GetIncreasingColor().ToAndroid(),
                        HighLightColor = itemChild.IF_GetHighLightColor().ToAndroid(),
                    };
                    dataSet.SetDrawValues(false);
                    dataSet.ShadowColorSameAsCandle = true;


                    listDataSetItems.Add(dataSet);
                }

                CandleData data = new CandleData(listDataSetItems.ToArray());
                chartOriginal.XAxis.ValueFormatter = new StringXAxisFormaterRenderer(supportChart.ChartData.TitleItems);
                chartOriginal.Data = data;
            }
        }
    }
}