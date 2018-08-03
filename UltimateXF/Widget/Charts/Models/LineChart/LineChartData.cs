using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.LineChart
{
    public class LineChartData : BaseData<EntryChart,ILineDataSet> 
    {
        public LineChartData(List<ILineDataSet> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
            
        }
    }
}