using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.ScatterChart
{
    public class ScatterChartData : ChartDataXF<IScatterDataSet,EntryChart>
    {
        public ScatterChartData(List<IScatterDataSet> _DataSetItems) : base(_DataSetItems)
        {
        }
    }
}