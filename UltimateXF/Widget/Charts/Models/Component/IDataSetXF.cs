using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public interface IDataSetXF<TEntry> where TEntry : BaseEntry
    {
        List<TEntry> IF_GetValues();
        float? IF_GetYMax();
        float? IF_GetYMin();
        float? IF_GetXMax();
        float? IF_GetXMin();
    }
}