using System;
using Foundation;
using iOSCharts;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class AxisValueFormatterExport : NSObject, IInterfaceChartAxisValueFormatter
    {
        private IAxisValueFormatterXF IAxisValueFormatterXF;

        public AxisValueFormatterExport(IAxisValueFormatterXF _IAxisValueFormatterXF)
        {
            IAxisValueFormatterXF = _IAxisValueFormatterXF;
        }

        public string Axis(double value, ChartAxisBase axis)
        {
            try
            {
                return IAxisValueFormatterXF.GetFormattedValue((float)value);
            }
            catch (Exception ex)
            {
                return "" + value;
            }
        }
    }
}