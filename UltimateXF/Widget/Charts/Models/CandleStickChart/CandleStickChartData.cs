using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public class CandleStickChartData : BaseData<CandleStickEntry, ICandleStickDataSet>
    {
        public CandleStickChartData(List<ICandleStickDataSet> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
        }
    }
}