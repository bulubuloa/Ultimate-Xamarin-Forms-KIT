using System;
using System.Collections.Generic;
using System.Linq;
using iOSCharts;
using UltimateXF.Widget;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class CandleStickChartExport
    {
        public iOSCharts.CandleChartData Export(CandleStickChartData supportChart)
        {
            var dataSetItems = supportChart.IF_GetDataSet();
            var listDataSetItems = new List<CandleChartDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new CandleChartDataEntry(item.GetXPosition(), item.GetHigh(), item.GetLow(), item.GetOpen(), item.GetClose()));
                CandleChartDataSet dataSet = new CandleChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                IntializeDataSet(itemChild, dataSet);
                listDataSetItems.Add(dataSet);
            }

            CandleChartData data = new CandleChartData(listDataSetItems.ToArray());
            return data;
        }

        private bool ConvertPaintStyle(PaintStyleEnum source)
        {
            switch (source)
            {
                case PaintStyleEnum.STROKE:
                    return false;
                default:
                    return true;
            }
        }

        private void IntializeDataSet(ICandleStickDataSet source, CandleChartDataSet original)
        {
            if (source.IF_GetDecreasingColor().HasValue)
                original.DecreasingColor = source.IF_GetDecreasingColor().Value.ToUIColor();

            if (source.IF_GetIncreasingColor().HasValue)
                original.IncreasingColor = source.IF_GetIncreasingColor().Value.ToUIColor();

            if (source.IF_GetHighLightColor().HasValue)
                original.HighlightColor = source.IF_GetHighLightColor().Value.ToUIColor();

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

            if (source.IF_GetShadowColor().HasValue)
                original.ShadowColor = source.IF_GetShadowColor().Value.ToUIColor();
        }
    }
}