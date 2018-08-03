using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.BarChart
{
    public class BarDataSet : BaseDataSet<EntryChart>, IBarDataSet
    {
        public BarDataSet(List<EntryChart> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
            
        }
    }
}