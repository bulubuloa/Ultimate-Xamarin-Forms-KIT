using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public interface ILineRadarDataSetXF<TEntry> : ILineScatterCandleRadarDataSetXF<TEntry> where TEntry : BaseEntry
    {
        Color? IF_GetFillColor();
        int? IF_GetFillAlpha();
        float? IF_GetLineWidth();
        bool? IF_GetDrawFilled();
    }
}