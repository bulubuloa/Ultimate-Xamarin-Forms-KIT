using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class LineScatterCandleRadarDataSetXF<TEntry> : BarLineScatterCandleBubbleDataSetXF<TEntry>,ILineScatterCandleRadarDataSetXF<TEntry> where TEntry : BaseEntry
    {
        /*
         * protected DashPathEffect mHighlightDashPathEffect = null;
         */

        private bool? _DrawVerticalHighlightIndicator;
        public bool? DrawVerticalHighlightIndicator
        {
            get => _DrawVerticalHighlightIndicator;
            set
            {
                _DrawVerticalHighlightIndicator = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawHorizontalHighlightIndicator;
        public bool? DrawHorizontalHighlightIndicator
        {
            get => _DrawHorizontalHighlightIndicator;
            set
            {
                _DrawHorizontalHighlightIndicator = value;
                OnPropertyChanged();
            }
        }

        private float? _HighlightLineWidth;
        public float? HighlightLineWidth
        {
            get => _HighlightLineWidth;
            set
            {
                _HighlightLineWidth = value;
                OnPropertyChanged();
            }
        }

        public LineScatterCandleRadarDataSetXF(List<TEntry> values, string label) : base(values, label)
        {
        }

        public bool? IF_GetDrawVerticalHighlightIndicator()
        {
            return DrawVerticalHighlightIndicator;
        }

        public bool? IF_GetDrawHorizontalHighlightIndicator()
        {
            return DrawHorizontalHighlightIndicator;
        }

        public float? IF_GetHighlightLineWidth()
        {
            return HighlightLineWidth;
        }
    }
}
