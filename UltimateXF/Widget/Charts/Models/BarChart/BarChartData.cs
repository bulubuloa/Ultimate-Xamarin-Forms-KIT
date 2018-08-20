using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.BarChart
{
    public class BarChartData : ChartDataXF<IBarDataSet,EntryChart> 
    {
        public BarChartData(List<IBarDataSet> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems,_TitleItems)
        {
            
        }
    }
}