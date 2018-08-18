using System;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.PieChart
{
    public interface IPieDataSet : IDataSetXF<PieEntry>
    {
        float? IF_GetSliceSpace();
        bool? IF_GetAutomaticallyDisableSliceSpacing();
        float? IF_GetShift();
        ValuePosition? IF_GetXValuePosition();
        ValuePosition? IF_GetYValuePosition();
        bool? IF_GetUsingSliceColorAsValueLineColor();
        int? IF_GetValueLineColor();
        float? IF_GetValueLineWidth();
        float? IF_GetValueLinePart1OffsetPercentage();
        float? IF_GetValueLinePart1Length();
        float? IF_GetValueLinePart2Length();
        bool? IF_GetValueLineVariableLength();
    }
}