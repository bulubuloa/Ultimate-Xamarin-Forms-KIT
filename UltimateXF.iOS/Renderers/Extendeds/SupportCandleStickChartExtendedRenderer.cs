using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportCandleStickChartExtended), typeof(SupportCandleStickChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportCandleStickChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportCandleStickChartExtended, CandleStickChartView>
    {
        public SupportCandleStickChartExtendedRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportCandleStickChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                var dataSetItems = SupportChartView.ChartData.DataSets;
                var listDataSetItems = new List<CandleChartDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetValues().Select(item => new CandleChartDataEntry(item.GetXPosition(), item.GetHigh(), item.GetLow(), item.GetOpen(), item.GetClose()));
                    CandleChartDataSet dataSet = new CandleChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetLabel());
                    OnIntializeDataSet(itemChild, dataSet);
                    listDataSetItems.Add(dataSet);
                }

                CandleChartData data = new CandleChartData(listDataSetItems.ToArray());
                OriginalChartView.Data = data;

                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }

        private bool ConvertPaintStyle(PaintStyle source)
        {
            switch (source)
            {
                case PaintStyle.STROKE:
                    return false;
                default:
                    return true;
            }
        }

        private void OnIntializeDataSet(ICandleStickDataSet source, CandleChartDataSet original)
        {
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetShadowWidth().HasValue)
                original.ShadowWidth = source.IF_GetShadowWidth().Value;

            if (source.IF_GetShowCandleBar().HasValue)
                original.ShowCandleBar = source.IF_GetShowCandleBar().Value;

            if (source.IF_GetBarSpace().HasValue)
                original.BarSpace = source.IF_GetBarSpace().Value;

            if (source.IF_GetShadowColorSameAsCandle().HasValue)
                original.ShadowColorSameAsCandle = source.IF_GetShadowColorSameAsCandle().Value;

            if (source.IF_GetIncreasingPaintStyle().HasValue)
                original.IncreasingFilled = ConvertPaintStyle(source.IF_GetIncreasingPaintStyle().Value);

            if (source.IF_GetDecreasingPaintStyle().HasValue)
                original.DecreasingFilled = ConvertPaintStyle(source.IF_GetDecreasingPaintStyle().Value);

            if (source.IF_GetNeutralColor().HasValue)
                original.NeutralColor = source.IF_GetNeutralColor().Value.ToUIColor();

            if (source.IF_GetDecreasingColor().HasValue)
                original.DecreasingColor = source.IF_GetDecreasingColor().Value.ToUIColor();

            if (source.IF_GetIncreasingColor().HasValue)
                original.IncreasingColor = source.IF_GetIncreasingColor().Value.ToUIColor();

            if (source.IF_GetShadowColor().HasValue)
                original.ShadowColor = source.IF_GetShadowColor().Value.ToUIColor();
        }
    }
}