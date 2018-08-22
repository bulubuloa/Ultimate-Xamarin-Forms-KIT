using System;
namespace UltimateXF.Widget.Charts.Models.Formatters
{
    public class IntegerDataSetFormatter : IDataSetValueFormatter
    {
        public IntegerDataSetFormatter()
        {
        }

        public string GetFormattedValue(float value, int dataSetIndex)
        {
            return ""+(int)value;
        }
    }
}