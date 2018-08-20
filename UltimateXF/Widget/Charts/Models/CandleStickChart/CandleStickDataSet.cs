using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public enum PaintStyle
    {
        FILL,
        FILL_AND_STROKE,
        STROKE
    }

        
    public class CandleStickDataSet : LineScatterCandleRadarDataSetXF<CandleStickEntry>, ICandleStickDataSet
    {
        private float? _ShadowWidth;
        public float? ShadowWidth
        {
            get => _ShadowWidth;
            set
            {
                _ShadowWidth = value;
                OnPropertyChanged();
            }
        }

        private bool? _ShowCandleBar;
        public bool? ShowCandleBar
        {
            get => _ShowCandleBar;
            set
            {
                _ShowCandleBar = value;
                OnPropertyChanged();
            }
        }

        private float? _BarSpace;
        public float? BarSpace
        {
            get => _BarSpace;
            set
            {
                _BarSpace = value;
                OnPropertyChanged();
            }
        }

        private bool? _ShadowColorSameAsCandle;
        public bool? ShadowColorSameAsCandle
        {
            get => _ShadowColorSameAsCandle;
            set
            {
                _ShadowColorSameAsCandle = value;
                OnPropertyChanged();
            }
        }

        private PaintStyle? _IncreasingPaintStyle;
        public PaintStyle? IncreasingPaintStyle
        {
            get => _IncreasingPaintStyle;
            set
            {
                _IncreasingPaintStyle = value;
                OnPropertyChanged();
            }
        }

        private PaintStyle? _DecreasingPaintStyle;
        public PaintStyle? DecreasingPaintStyle
        {
            get => _DecreasingPaintStyle;
            set
            {
                _DecreasingPaintStyle = value;
                OnPropertyChanged();
            }
        }

        private Color? _NeutralColor;
        public Color? NeutralColor
        {
            get => _NeutralColor;
            set
            {
                _NeutralColor = value;
                OnPropertyChanged();
            }
        }

        private Color? _IncreasingColor;
        public Color? IncreasingColor
        {
            get => _IncreasingColor;
            set
            {
                _IncreasingColor = value;
                OnPropertyChanged();
            }
        }

        private Color? _DecreasingColor;
        public Color? DecreasingColor
        {
            get => _DecreasingColor;
            set
            {
                _DecreasingColor = value;
                OnPropertyChanged();
            }
        }

        private Color? _ShadowColor;
        public Color? ShadowColor
        {
            get => _ShadowColor;
            set
            {
                _ShadowColor = value;
                OnPropertyChanged();
            }
        }

        public CandleStickDataSet(List<CandleStickEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
            
        }

        public float? IF_GetShadowWidth()
        {
            return ShadowWidth;
        }

        public bool? IF_GetShowCandleBar()
        {
            return ShowCandleBar;
        }

        public float? IF_GetBarSpace()
        {
            return BarSpace;
        }

        public bool? IF_GetShadowColorSameAsCandle()
        {
            return ShadowColorSameAsCandle;
        }

        public PaintStyle? IF_GetIncreasingPaintStyle()
        {
            return IncreasingPaintStyle;
        }

        public PaintStyle? IF_GetDecreasingPaintStyle()
        {
            return DecreasingPaintStyle;
        }

        public Color? IF_GetNeutralColor()
        {
            return NeutralColor;
        }

        public Color? IF_GetIncreasingColor()
        {
            return IncreasingColor;
        }

        public Color? IF_GetDecreasingColor()
        {
            return DecreasingColor;
        }

        public Color? IF_GetShadowColor()
        {
            return ShadowColor;
        }
    }
}