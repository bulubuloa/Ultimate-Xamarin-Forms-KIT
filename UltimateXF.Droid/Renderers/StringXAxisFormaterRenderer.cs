using System;
using System.Collections.Generic;
using MikePhil.Charting.Components;
using MikePhil.Charting.Formatter;

namespace UltimateXF.Droid.Renderers
{
    public class StringXAxisFormaterRenderer : Java.Lang.Object, IAxisValueFormatter
    {
        private List<string> customLabels;

        public StringXAxisFormaterRenderer(List<string> _customLabels)
        {
            customLabels = _customLabels;
        }

        public string GetFormattedValue(float value, AxisBase axis)
        {
            try
            {
                return customLabels[(int)value];
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}