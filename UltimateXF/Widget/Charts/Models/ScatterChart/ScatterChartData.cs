using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.ScatterChart
{
    public class ScatterChartData : BaseData<EntryChart, IScatterDataSet>
    {
        public ScatterChartData(List<IScatterDataSet> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
        }
    }
}