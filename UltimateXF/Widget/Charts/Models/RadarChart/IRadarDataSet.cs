using System;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.RadarChart
{
    public interface IRadarDataSet : ILineRadarDataSetXF<RadarEntry>
    {
        bool? IF_GetDrawHighlightCircleEnabled();
        Color? IF_GetHighlightCircleFillColor();
        Color? IF_GetHighlightCircleStrokeColor();
        int? IF_GetHighlightCircleStrokeAlpha();
        float? IF_GetHighlightCircleInnerRadius();
        float? IF_GetHighlightCircleOuterRadius();
        float? IF_GetHighlightCircleStrokeWidth();
    }
}