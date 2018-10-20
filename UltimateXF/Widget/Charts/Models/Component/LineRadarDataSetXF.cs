using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class LineRadarDataSetXF<TEntry> : LineScatterCandleRadarDataSetXF<TEntry>,ILineRadarDataSetXF<TEntry> where TEntry : BaseEntry
    {
        /*
         * protected Drawable mFillDrawable;
         */

        private Color? _FillColor;
        public Color? FillColor
        {
            get => _FillColor;
            set
            {
                _FillColor = value;
                OnPropertyChanged();
            }
        }

        private float? _FillAlpha;
        public float? FillAlpha
        {
            get => _FillAlpha;
            set
            {
                _FillAlpha = value;
                OnPropertyChanged();
            }
        }

        private float? _LineWidth;
        public float? LineWidth
        {
            get => _LineWidth;
            set
            {
                _LineWidth = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawFilled;
        public bool? DrawFilled
        {
            get => _DrawFilled;
            set
            {
                _DrawFilled = value;
                OnPropertyChanged();
            }
        }

        public LineRadarDataSetXF(List<TEntry> values, string label) : base(values, label)
        {
        }

        public Color? IF_GetFillColor()
        {
            return FillColor;
        }

        public float? IF_GetFillAlpha()
        {
            return FillAlpha;
        }

        public float? IF_GetLineWidth()
        {
            return LineWidth;
        }

        public bool? IF_GetDrawFilled()
        {
            return DrawFilled;
        }
    }
}