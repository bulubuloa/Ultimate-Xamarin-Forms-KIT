using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.Formatters
{
    public class TextByIndexXAxisFormatter : IAxisValueFormatterXF
    {
        private List<string> Titles;
        
        public TextByIndexXAxisFormatter(List<string> _Titles)
        {
            Titles = _Titles;
        }

        public string GetFormattedValue(float _Value)
        {
            try
            {
                return Titles[(int)_Value];
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}