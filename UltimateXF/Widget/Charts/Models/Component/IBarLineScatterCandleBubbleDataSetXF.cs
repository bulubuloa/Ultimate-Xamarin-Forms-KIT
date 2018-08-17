using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public interface IBarLineScatterCandleBubbleDataSetXF<TEntry> : IDataSetXF<TEntry> where TEntry : BaseEntry
    {
        Color? IF_GetighLightColor();
    }
}
