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

[assembly: ExportRenderer(typeof(SupportBubbleChartExtended), typeof(SupportBubbleChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportBubbleChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBubbleChartExtended, BubbleChart>
    {
        public SupportBubbleChartExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportBubbleChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                var dataSetItems = new List<MikePhil.Charting.Data.BubbleDataSet>();
                foreach (var item in SupportChartView.ChartData.DataSetItems)
                {
                    var entryOriginal = item.IF_GetEntry().Select(obj => new MikePhil.Charting.Data.BubbleEntry(obj.GetXPosition(), obj.GetYPosition(),obj.GetSize()));
                    var dataSet = new MikePhil.Charting.Data.BubbleDataSet(entryOriginal.ToArray(), item.IF_GetTitle());
                    if (item.IF_GetDataColorScheme() != null)
                    {
                        dataSet.SetColors(item.IF_GetDataColorScheme().Select(obj => obj.ToAndroid().ToArgb()).ToArray());
                    }
                    dataSetItems.Add(dataSet);
                }
                var data = new MikePhil.Charting.Data.BubbleData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
        }
    }
}