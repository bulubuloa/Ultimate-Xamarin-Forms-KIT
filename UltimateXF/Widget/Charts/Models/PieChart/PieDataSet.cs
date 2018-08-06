using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.PieChart
{
    public class PieDataSet : BaseDataSet<PieEntry>, IPieDataSet
    {
        public PieDataSet(List<PieEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }
    }
}