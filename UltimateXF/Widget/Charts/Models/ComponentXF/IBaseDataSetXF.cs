using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.Formatters;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.ComponentXF
{
    public interface IBaseDataSetXF<TEntry> where TEntry : BaseEntry
    {
        List<TEntry> IF_GetValues();
        List<Color> IF_GetColors();
        List<Color> IF_GetValueColors();
        GradientColor IF_GetGradientColor();
        List<GradientColor> IF_GetGradientColors();
        string IF_GetLabel();
        bool? IF_GetHighlightEnabled();
        bool? IF_GetVisible();
        float? IF_GetValueTextSize();
        bool? IF_GetDrawIcons();
        bool? IF_GetDrawValues();
        IValueFormatterXF IF_GetValueFormatter();
    }
}