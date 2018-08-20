using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportBarChartExtended), typeof(SupportBarChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportBarChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBarChartExtended, BarChart>
    {
        public SupportBarChartExtendedRenderer(Context context) : base(context)
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
                var dataSetItems = new List<BarDataSet>();
                foreach (var item in SupportChartView.ChartData.DataSets)
                {
                    var entryOriginal = item.IF_GetValues().Select(obj => new BarEntry(obj.GetXPosition(), obj.GetYPosition()));
                    var dataSet = new BarDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                    OnIntializeDataSet(item,dataSet);
                    dataSetItems.Add(dataSet);
                }

                var data = new BarData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
        }

        private void OnIntializeDataSet(UltimateXF.Widget.Charts.Models.BarChart.IBarDataSet source, BarDataSet original)
        {
            /*
             * Properties could not set
             * IF_GetStackSize
             * IF_GetEntryCountStacks
             */
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetBarShadowColor().HasValue)
                original.BarShadowColor = source.IF_GetBarShadowColor().Value.ToAndroid();

            if (source.IF_GetBarBorderWidth().HasValue)
                original.BarBorderWidth = source.IF_GetBarBorderWidth().Value;

            if (source.IF_GetBarBorderColor().HasValue)
                original.BarBorderColor = source.IF_GetBarBorderColor().Value.ToAndroid();

            if (source.IF_GetHighLightAlpha().HasValue)
                original.HighLightAlpha = source.IF_GetHighLightAlpha().Value;

            if (source.IF_GetStackLabels()!=null && source.IF_GetStackLabels().Count > 0)
                original.SetStackLabels(source.IF_GetStackLabels().ToArray());
        }
    }
}