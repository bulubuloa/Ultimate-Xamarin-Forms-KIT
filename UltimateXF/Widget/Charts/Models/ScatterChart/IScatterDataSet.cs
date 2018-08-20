using System;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.ScatterChart
{
    public interface IScatterDataSet : ILineScatterCandleRadarDataSetXF<EntryChart>
    {
        float? IF_GetShapeSize();
        float? IF_GetScatterShapeHoleRadius();
        Color? IF_GetScatterShapeHoleColor();
    }
}