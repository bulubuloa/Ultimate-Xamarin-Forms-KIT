using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.ScatterChart
{
    public class ScatterDataSet : BaseDataSet<EntryChart>, IScatterDataSet
    {
        public ScatterDataSet(List<EntryChart> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }
    }
}