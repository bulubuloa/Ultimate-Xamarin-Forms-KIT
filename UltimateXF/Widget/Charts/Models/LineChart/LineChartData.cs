using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.LineChart
{
    public class LineChartData : ChartDataXF<ILineDataSetXF,EntryChart> 
    {
        public LineChartData(List<ILineDataSetXF> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
            
        }
    }
}