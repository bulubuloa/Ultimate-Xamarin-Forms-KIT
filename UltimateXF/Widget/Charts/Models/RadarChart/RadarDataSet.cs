using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.RadarChart
{
    public class RadarDataSet : LineRadarDataSetXF<RadarEntry>, IRadarDataSet
    {
        private bool? _DrawHighlightCircleEnabled;
        public bool? DrawHighlightCircleEnabled
        {
            get => _DrawHighlightCircleEnabled;
            set
            {
                _DrawHighlightCircleEnabled = value;
                OnPropertyChanged();
            }
        }

        private Color? _HighlightCircleFillColor;
        public Color? HighlightCircleFillColor
        {
            get => _HighlightCircleFillColor;
            set
            {
                _HighlightCircleFillColor = value;
                OnPropertyChanged();
            }
        }

        private Color? _HighlightCircleStrokeColor;
        public Color? HighlightCircleStrokeColor
        {
            get => _HighlightCircleStrokeColor;
            set
            {
                _HighlightCircleStrokeColor = value;
                OnPropertyChanged();
            }
        }

        private int? _HighlightCircleStrokeAlpha;
        public int? HighlightCircleStrokeAlpha
        {
            get => _HighlightCircleStrokeAlpha;
            set
            {
                _HighlightCircleStrokeAlpha = value;
                OnPropertyChanged();
            }
        }

        private float? _HighlightCircleInnerRadius;
        public float? HighlightCircleInnerRadius
        {
            get => _HighlightCircleInnerRadius;
            set
            {
                _HighlightCircleInnerRadius = value;
                OnPropertyChanged();
            }
        }

        private float? _HighlightCircleOuterRadius;
        public float? HighlightCircleOuterRadius
        {
            get => _HighlightCircleOuterRadius;
            set
            {
                _HighlightCircleOuterRadius = value;
                OnPropertyChanged();
            }
        }

        private float? _HighlightCircleStrokeWidth;
        public float? HighlightCircleStrokeWidth
        {
            get => _HighlightCircleStrokeWidth;
            set
            {
                _HighlightCircleStrokeWidth = value;
                OnPropertyChanged();
            }
        }

        public RadarDataSet(List<RadarEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }

        public bool? IF_GetDrawHighlightCircleEnabled()
        {
            return DrawHighlightCircleEnabled;
        }

        public Color? IF_GetHighlightCircleFillColor()
        {
            return HighlightCircleFillColor;
        }

        public Color? IF_GetHighlightCircleStrokeColor()
        {
            return HighlightCircleStrokeColor;
        }

        public int? IF_GetHighlightCircleStrokeAlpha()
        {
            return HighlightCircleStrokeAlpha;
        }

        public float? IF_GetHighlightCircleInnerRadius()
        {
            return HighlightCircleInnerRadius;
        }

        public float? IF_GetHighlightCircleOuterRadius()
        {
            return HighlightCircleOuterRadius;
        }

        public float? IF_GetHighlightCircleStrokeWidth()
        {
            return HighlightCircleStrokeWidth;
        }
    }
}
