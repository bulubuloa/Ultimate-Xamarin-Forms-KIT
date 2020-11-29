using System;
using MikePhil.Charting.Data;
using MikePhil.Charting.Formatter;
using MikePhil.Charting.Util;
using UltimateXF.Widget.Charts.Models.Formatters;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class DataSetValueFormatterExport : ValueFormatter
    {
        private IDataSetValueFormatter IDataSetValueFormatter;

        public DataSetValueFormatterExport(IDataSetValueFormatter _IDataSetValueFormatter)
        {
            IDataSetValueFormatter = _IDataSetValueFormatter;
        }

        public override string GetFormattedValue(float value)
        {
            try
            {
                return IDataSetValueFormatter.GetFormattedValue(value, 0);
            }
            catch (Exception ex)
            {
                return "" + value;
            }
        }

        [Obsolete]
        public override string GetFormattedValue(float value, Entry entry, int dataSetIndex, ViewPortHandler viewPortHandler)
        {
            try
            {
                return IDataSetValueFormatter.GetFormattedValue(value,dataSetIndex);
            }
            catch (Exception ex)
            {
                return "" + value;
            }
        }
    }
}