using System;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.BubbleChart
{
    public interface IBubbleDataSet : IBarLineScatterCandleBubbleDataSetXF<BubbleEntry>
    {
        float? IF_GetMaxSize();
        bool? IF_GetNormalizeSize();
        float? IF_GetHighlightCircleWidth();
    }
}