using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.LineChart
{
    public interface ILineDataSetXF<TEntry> : ILineRadarDataSetXF<TEntry>  where TEntry : BaseEntry
    {
        LineDataSetMode? IF_GetMode();
        List<Color> IF_GetCircleColors();
        Color? IF_GetCircleHoleColor();
        float? IF_GetCircleRadius();
        float? IF_GetCircleHoleRadius();
        float? IF_GetCubicIntensity();
        bool? IF_GetDrawCircles();
        bool? IF_GetDrawCircleHole();
    }
}