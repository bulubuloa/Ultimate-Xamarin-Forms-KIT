using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.BubbleChart
{
    public class BubbleChartData : BaseData<BubbleEntry, IBubbleDataSet>
    {
        public BubbleChartData(List<IBubbleDataSet> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
        }
    }
}