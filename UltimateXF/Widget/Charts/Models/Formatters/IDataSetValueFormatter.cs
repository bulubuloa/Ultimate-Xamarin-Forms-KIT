using System;
namespace UltimateXF.Widget.Charts.Models.Formatters
{
    public interface IDataSetValueFormatter
    {
        string GetFormattedValue(float value, int dataSetIndex);
    }
}