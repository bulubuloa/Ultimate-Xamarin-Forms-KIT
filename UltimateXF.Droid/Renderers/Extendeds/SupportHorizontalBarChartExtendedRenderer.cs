using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportHorizontalBarChartExtended), typeof(SupportHorizontalBarChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportHorizontalBarChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportHorizontalBarChartExtended, HorizontalBarChart>
    {
        public SupportHorizontalBarChartExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportBarChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                var dataSetItems = new List<MikePhil.Charting.Data.BarDataSet>();
                foreach (var item in SupportChartView.ChartData.DataSetItems)
                {
                    var entryOriginal = item.IF_GetEntry().Select(obj => new MikePhil.Charting.Data.BarEntry(obj.GetXPosition(), obj.GetYPosition()));
                    var dataSet = new MikePhil.Charting.Data.BarDataSet(entryOriginal.ToArray(), item.IF_GetTitle());
                    if (item.IF_GetDataColorScheme() != null)
                        dataSet.SetColors(item.IF_GetDataColorScheme().Select(obj => obj.ToAndroid().ToArgb()).ToArray());
                    dataSet.SetDrawValues(item.IF_GetDrawValue());
                    dataSetItems.Add(dataSet);
                }

                var data = new MikePhil.Charting.Data.BarData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
        }
    }
}