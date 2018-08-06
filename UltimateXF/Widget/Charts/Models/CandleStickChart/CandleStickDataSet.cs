using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public class CandleStickDataSet : BaseDataSet<CandleStickEntry>, ICandleStickDataSet
    {
        public CandleStickDataSet(List<CandleStickEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }
    }
}