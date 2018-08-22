using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.BubbleChart
{
    public class BubbleChartData : ChartDataXF<IBubbleDataSet,BubbleEntry>
    {
        public BubbleChartData(List<IBubbleDataSet> _DataSetItems) : base(_DataSetItems)
        {
        }
    }
}