using System;
namespace UltimateXF.Widget.Charts.Models.Component
{
    public interface ILineScatterCandleRadarDataSetXF<TEntry> : IBarLineScatterCandleBubbleDataSetXF<TEntry>  where TEntry : BaseEntry
    {
        bool? IF_GetDrawVerticalHighlightIndicator();
        bool? IF_GetDrawHorizontalHighlightIndicator();
        float? IF_GetHighlightLineWidth();
    }
}