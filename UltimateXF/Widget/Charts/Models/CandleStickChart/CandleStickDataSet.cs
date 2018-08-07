using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public class CandleStickDataSet : BaseDataSet<CandleStickEntry>, ICandleStickDataSet
    {
        public Color? DecreasingColor { set; private get; }
        public Color? IncreasingColor { set; private get; }
        public Color? HighLightColor { set; private get; }
        public float? ShadowWidth { set; private get; }
        public bool? ShowCandleBar { set; private get; }
        public float? BarSpace { set; private get; }
        public bool? ShadowColorSameAsCandle { set; private get; }
        public PaintStyleEnum? IncreasingPaintStyle { set; private get; }
        public PaintStyleEnum? DecreasingPaintStyle { set; private get; }
        public Color? NeutralColor { set; private get; }
        public Color? ShadowColor { set; private get; }

        public CandleStickDataSet(List<CandleStickEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
            DecreasingColor = Color.Red;
            IncreasingColor = Color.Green;
            HighLightColor = Color.FromRgb(142, 201, 25);
            IncreasingPaintStyle = PaintStyleEnum.STROKE;
            DecreasingPaintStyle = PaintStyleEnum.STROKE;
        }

        public Color? IF_GetDecreasingColor()
        {
            return DecreasingColor;
        }

        public Color? IF_GetHighLightColor()
        {
            return IncreasingColor;
        }

        public Color? IF_GetIncreasingColor()
        {
            return HighLightColor;
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

        public PaintStyleEnum? IF_GetIncreasingPaintStyle()
        {
            return IncreasingPaintStyle;
        }

        public PaintStyleEnum? IF_GetDecreasingPaintStyle()
        {
            return DecreasingPaintStyle;
        }

        public Color? IF_GetNeutralColor()
        {
            return NeutralColor;
        }

        public Color? IF_GetShadowColor()
        {
            return ShadowColor;
        }
    }
}