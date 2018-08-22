using System;
using MikePhil.Charting.Data;
using MikePhil.Charting.Formatter;
using MikePhil.Charting.Util;
using UltimateXF.Widget.Charts.Models.Formatters;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class DataSetValueFormatterExport : Java.Lang.Object, IValueFormatter
    {
        private IDataSetValueFormatter IDataSetValueFormatter;

        public DataSetValueFormatterExport(IDataSetValueFormatter _IDataSetValueFormatter)
        {
            IDataSetValueFormatter = _IDataSetValueFormatter;
        }

        public string GetFormattedValue(float value, Entry entry, int dataSetIndex, ViewPortHandler viewPortHandler)
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