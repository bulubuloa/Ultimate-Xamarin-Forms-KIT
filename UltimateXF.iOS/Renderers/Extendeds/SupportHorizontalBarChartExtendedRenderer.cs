using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportHorizontalBarChartExtended), typeof(SupportHorizontalBarChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportHorizontalBarChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportHorizontalBarChartExtended, HorizontalBarChartView>
    {
        public SupportHorizontalBarChartExtendedRenderer()
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
                var dataSetItems = new List<BarChartDataSet>();

                foreach (var item in SupportChartView.ChartData.DataSets)
                {
                    var entryOriginal = item.IF_GetValues().Select(obj => new BarChartDataEntry(obj.GetXPosition(), obj.GetYPosition()));
                    var dataSet = new BarChartDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                    OnIntializeDataSet(item, dataSet);
                    dataSetItems.Add(dataSet);
                }
                var data = new BarChartData(dataSetItems.ToArray());
                OriginalChartView.Data = data;

                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }

        private void OnIntializeDataSet(UltimateXF.Widget.Charts.Models.BarChart.IBarDataSet source, BarChartDataSet original)
        {
            /*
             * Properties could not set
             * IF_GetStackSize
             * IF_GetEntryCountStacks
             */

            Export.OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetBarShadowColor().HasValue)
                original.BarShadowColor = source.IF_GetBarShadowColor().Value.ToUIColor();

            if (source.IF_GetBarBorderWidth().HasValue)
                original.BarBorderWidth = source.IF_GetBarBorderWidth().Value;

            if (source.IF_GetBarBorderColor().HasValue)
                original.BarBorderColor = source.IF_GetBarBorderColor().Value.ToUIColor();

            if (source.IF_GetHighLightAlpha().HasValue)
                original.HighlightAlpha = source.IF_GetHighLightAlpha().Value;

            if (source.IF_GetStackLabels() != null && source.IF_GetStackLabels().Count > 0)
                original.StackLabels = (source.IF_GetStackLabels().ToArray());
        }
    }
}