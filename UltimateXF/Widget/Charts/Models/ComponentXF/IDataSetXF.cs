using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.ComponentXF;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public interface IDataSetXF<TEntry> : IBaseDataSetXF<TEntry> where TEntry : BaseEntry
    {
        float? IF_GetYMax();
        float? IF_GetYMin();
        float? IF_GetXMax();
        float? IF_GetXMin();
    }
}