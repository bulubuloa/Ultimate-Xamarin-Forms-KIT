using System;
using Foundation;
using iOSCharts;
using UltimateXF.Widget.Charts.Models.Formatters;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class DataSetValueFormatterExport : NSObject, IInterfaceChartValueFormatter
    {
        private IDataSetValueFormatter IDataSetValueFormatter;

        public DataSetValueFormatterExport(IDataSetValueFormatter _IDataSetValueFormatter)
        {
            IDataSetValueFormatter = _IDataSetValueFormatter;
        }

        public string Entry(double value, ChartDataEntry entry, nint dataSetIndex, ChartViewPortHandler viewPortHandler)
        {
            try
            {
                return IDataSetValueFormatter.GetFormattedValue((float)value, (int)dataSetIndex);
            }
            catch (Exception ex)
            {
                return "" + value;
            }
        }
    }
}