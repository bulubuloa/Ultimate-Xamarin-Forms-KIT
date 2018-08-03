using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.BarChart
{
    public class BarChartData : BaseData<EntryChart,IBarDataSet> 
    {
        public BarChartData(List<IBarDataSet> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems,_TitleItems)
        {
            
        }
    }
}