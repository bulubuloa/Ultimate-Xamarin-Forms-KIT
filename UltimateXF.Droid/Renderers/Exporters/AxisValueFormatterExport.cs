using System;
using MikePhil.Charting.Components;
using MikePhil.Charting.Formatter;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class AxisValueFormatterExport : ValueFormatter
    {
        private IAxisValueFormatterXF IAxisValueFormatterXF;

        public AxisValueFormatterExport(IAxisValueFormatterXF _IAxisValueFormatterXF)
        {
            IAxisValueFormatterXF = _IAxisValueFormatterXF;
        }

        [Obsolete]
        public override string GetFormattedValue(float value, AxisBase axis)
        {
            try
            {
                return IAxisValueFormatterXF.GetFormattedValue(value);
            }
            catch (Exception ex)
            {
                return "" + value;
            }
        }

        public override string GetFormattedValue(float value)
        {
            try
            {
                return IAxisValueFormatterXF.GetFormattedValue(value);
            }
            catch (Exception ex)
            {
                return "" + value;
            }
        }

        //public string GetFormattedValue(float value, AxisBase axis)
        //{
        //    try
        //    {
        //        return IAxisValueFormatterXF.GetFormattedValue(value);
        //    }
        //    catch (Exception ex)
        //    {
        //        return "" + value;
        //    }
        //}
    }
}