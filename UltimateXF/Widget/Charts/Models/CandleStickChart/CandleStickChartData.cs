using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public class CandleStickChartData : ChartDataXF<ICandleStickDataSet,CandleStickEntry>
    {
        public CandleStickChartData(List<ICandleStickDataSet> _DataSetItems) : base(_DataSetItems)
        {
        }
    }
}