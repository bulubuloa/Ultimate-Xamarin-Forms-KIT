using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.RadarChart
{
    public class RadarChartData : BaseData<RadarEntry, IRadarDataSet>
    {
        public RadarChartData(List<IRadarDataSet> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
        }
    }
}