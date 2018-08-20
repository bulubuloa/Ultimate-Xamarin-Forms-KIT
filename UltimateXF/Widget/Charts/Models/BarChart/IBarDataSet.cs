using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.BarChart
{
    public interface IBarDataSet : IBarLineScatterCandleBubbleDataSetXF<EntryChart>
    {
        int? IF_GetStackSize();
        Color? IF_GetBarShadowColor();
        float? IF_GetBarBorderWidth();
        Color? IF_GetBarBorderColor();
        int? IF_GetHighLightAlpha();
        int? IF_GetEntryCountStacks();
        List<string> IF_GetStackLabels();
    }
}