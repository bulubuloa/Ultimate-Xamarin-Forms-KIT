using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class CandleStickChartExport
    {
        public MikePhil.Charting.Data.CandleData Export(CandleStickChartData ChartData)
        {
            var dataSetItems = ChartData.DataSets;
            var listDataSetItems = new List<MikePhil.Charting.Data.CandleDataSet>();

            //foreach (var itemChild in dataSetItems)
            //{
            //    var entryOriginal = itemChild.IF_GetEntry().Select(item => new MikePhil.Charting.Data.CandleEntry(item.GetXPosition(), (float)item.GetHigh(), (float)item.GetLow(), (float)item.GetOpen(), (float)item.GetClose()));
            //    var dataSet = new MikePhil.Charting.Data.CandleDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
            //    dataSet.SetDrawValues(false);
            //    IntializeDataSet(itemChild, dataSet);
            //    listDataSetItems.Add(dataSet);
            //}

            var data = new MikePhil.Charting.Data.CandleData(listDataSetItems.ToArray());
            return data;
        }

        private Android.Graphics.Paint.Style ConvertPaintStyle(PaintStyleEnum source)
        {
            switch (source)
            {
                case PaintStyleEnum.STROKE:
                    return Android.Graphics.Paint.Style.Stroke;
                default:
                    return Android.Graphics.Paint.Style.Fill;
            }
        }

        private void IntializeDataSet(ICandleStickDataSet source, MikePhil.Charting.Data.CandleDataSet original)
        {
            //if (source.IF_GetDecreasingColor().HasValue)
            //    original.DecreasingColor = source.IF_GetDecreasingColor().Value.ToAndroid();

            //if (source.IF_GetIncreasingColor().HasValue)
            //    original.IncreasingColor = source.IF_GetIncreasingColor().Value.ToAndroid();

            //if (source.IF_GetHighLightColor().HasValue)
            //    original.HighLightColor = source.IF_GetHighLightColor().Value.ToAndroid();

            //if (source.IF_GetShadowWidth().HasValue)
            //    original.ShadowWidth = source.IF_GetShadowWidth().Value;

            //if (source.IF_GetShowCandleBar().HasValue)
            //    original.ShowCandleBar = source.IF_GetShowCandleBar().Value;

            //if (source.IF_GetBarSpace().HasValue)
            //    original.BarSpace = source.IF_GetBarSpace().Value;

            //if (source.IF_GetShadowColorSameAsCandle().HasValue)
            //    original.ShadowColorSameAsCandle = source.IF_GetShadowColorSameAsCandle().Value;

            //if (source.IF_GetIncreasingPaintStyle().HasValue)
            //    original.IncreasingPaintStyle = ConvertPaintStyle(source.IF_GetIncreasingPaintStyle().Value);

            //if (source.IF_GetDecreasingPaintStyle().HasValue)
            //    original.DecreasingPaintStyle = ConvertPaintStyle(source.IF_GetDecreasingPaintStyle().Value);

            //if (source.IF_GetNeutralColor().HasValue)
            //    original.NeutralColor = source.IF_GetNeutralColor().Value.ToAndroid();

            //if (source.IF_GetShadowColor().HasValue)
                //original.ShadowColor = source.IF_GetShadowColor().Value.ToAndroid();
        }
    }
}
