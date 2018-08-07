using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public interface ICandleStickDataSet : IBaseDataSet<CandleStickEntry>
    {
        Color? IF_GetDecreasingColor();
        Color? IF_GetIncreasingColor();
        Color? IF_GetHighLightColor();
        float? IF_GetShadowWidth();
        bool? IF_GetShowCandleBar();
        float? IF_GetBarSpace();
        bool? IF_GetShadowColorSameAsCandle();
        PaintStyleEnum? IF_GetIncreasingPaintStyle();
        PaintStyleEnum? IF_GetDecreasingPaintStyle();
        Color? IF_GetNeutralColor();
        Color? IF_GetShadowColor();
    }
}