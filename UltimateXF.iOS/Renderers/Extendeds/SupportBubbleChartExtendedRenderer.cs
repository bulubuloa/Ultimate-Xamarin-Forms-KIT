using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportBubbleChartExtended), typeof(SupportBubbleChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportBubbleChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBubbleChartExtended, BubbleChartView>
    {
        public SupportBubbleChartExtendedRenderer()
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
                var dataSetItems = new List<BubbleChartDataSet>();
                foreach (var item in SupportChartView.ChartData.DataSets)
                {
                    var entryOriginal = item.IF_GetValues().Select(obj => new BubbleChartDataEntry(obj.GetXPosition(), obj.GetYPosition(), obj.GetSize()));
                    var dataSet = new BubbleChartDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                    OnIntializeDataSet(item,dataSet);
                    dataSetItems.Add(dataSet);
                }
                var data = new BubbleChartData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }

        private void OnIntializeDataSet(UltimateXF.Widget.Charts.Models.BubbleChart.IBubbleDataSet source, BubbleChartDataSet original)
        {
            /*
             * Properties could not setting 
             * IF_GetMaxSize
             */
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetNormalizeSize().HasValue)
                original.NormalizeSizeEnabled = (source.IF_GetNormalizeSize().Value);

            if (source.IF_GetHighlightCircleWidth().HasValue)
                original.HighlightCircleWidth = (source.IF_GetHighlightCircleWidth().Value);
        }
    }
}