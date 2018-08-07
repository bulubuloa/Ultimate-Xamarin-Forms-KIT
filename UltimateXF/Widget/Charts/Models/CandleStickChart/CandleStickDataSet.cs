using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public class CandleStickDataSet : BaseDataSet<CandleStickEntry>, ICandleStickDataSet
    {
        public Color DecreasingColor { set; private get; }
        public Color IncreasingColor { set; private get; }
        public Color HighLightColor { set; private get; }

        public CandleStickDataSet(List<CandleStickEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
            DecreasingColor = Color.Red;
            IncreasingColor = Color.Green;
            HighLightColor = Color.Gray;
        }

        public Color IF_GetDecreasingColor()
        {
            return DecreasingColor;
        }

        public Color IF_GetHighLightColor()
        {
            return IncreasingColor;
        }

        public Color IF_GetIncreasingColor()
        {
            return HighLightColor;
        }
    }
}