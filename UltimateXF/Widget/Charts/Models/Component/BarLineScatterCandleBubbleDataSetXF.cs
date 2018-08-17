using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class BarLineScatterCandleBubbleDataSetXF<TEntry> : DataSetXF<TEntry>,IBarLineScatterCandleBubbleDataSetXF<TEntry> where TEntry : BaseEntry
    {
        private Color? _HighLightColor;
        public Color? HighLightColor
        {
            get => _HighLightColor;
            set
            {
                _HighLightColor = value;
                OnPropertyChanged();
            }
        }

        public BarLineScatterCandleBubbleDataSetXF(List<TEntry> values, string label) : base(values, label)
        {
        }

        public Color? IF_GetighLightColor()
        {
            return HighLightColor;
        }
    }
}