using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.BubbleChart
{
    public class BubbleDataSet : BaseDataSet<BubbleEntry>, IBubbleDataSet
    {
        public BubbleDataSet(List<BubbleEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }
    }
}