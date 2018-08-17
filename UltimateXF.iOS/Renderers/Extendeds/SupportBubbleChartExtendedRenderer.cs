using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

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
                foreach (var item in SupportChartView.ChartData.DataSetItems)
                {
                    var entryOriginal = item.IF_GetEntry().Select(obj => new BubbleChartDataEntry(obj.GetXPosition(), obj.GetYPosition(), obj.GetSize()));
                    var dataSet = new BubbleChartDataSet(entryOriginal.ToArray(), item.IF_GetTitle());
                    if (item.IF_GetDataColorScheme() != null)
                    {
                        dataSet.SetColors(item.IF_GetDataColorScheme().Select(obj => obj.ToUIColor()).ToArray(),1f);
                    }
                    dataSetItems.Add(dataSet);
                }
                var data = new BubbleChartData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}