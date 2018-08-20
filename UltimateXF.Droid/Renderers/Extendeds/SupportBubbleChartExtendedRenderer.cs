using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

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
                foreach (var item in SupportChartView.ChartData.DataSets)
                {
                    var entryOriginal = item.IF_GetValues().Select(obj => new MikePhil.Charting.Data.BubbleEntry(obj.GetXPosition(), obj.GetYPosition(),obj.GetSize()));
                    var dataSet = new MikePhil.Charting.Data.BubbleDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                    OnIntializeDataSet(item, dataSet);
                    dataSetItems.Add(dataSet);
                }
                var data = new MikePhil.Charting.Data.BubbleData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
        }

        private void OnIntializeDataSet(UltimateXF.Widget.Charts.Models.BubbleChart.IBubbleDataSet source, MikePhil.Charting.Data.BubbleDataSet original)
        {
            /*
             * Properties could not setting 
             * IF_GetMaxSize
             */
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetNormalizeSize().HasValue)
                original.SetNormalizeSizeEnabled(source.IF_GetNormalizeSize().Value);
            
            if (source.IF_GetHighlightCircleWidth().HasValue)
                original.HighlightCircleWidth = (source.IF_GetHighlightCircleWidth().Value);
        }
    }
}