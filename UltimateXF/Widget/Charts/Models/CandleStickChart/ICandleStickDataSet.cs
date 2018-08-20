using System;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public interface ICandleStickDataSet : ILineScatterCandleRadarDataSetXF<CandleStickEntry>
    {
        float? IF_GetShadowWidth();
        bool? IF_GetShowCandleBar();
        float? IF_GetBarSpace();
        bool? IF_GetShadowColorSameAsCandle();
        PaintStyle? IF_GetIncreasingPaintStyle();
        PaintStyle? IF_GetDecreasingPaintStyle();
        Color? IF_GetNeutralColor();
        Color? IF_GetIncreasingColor();
        Color? IF_GetDecreasingColor();
        Color? IF_GetShadowColor();
    }
}