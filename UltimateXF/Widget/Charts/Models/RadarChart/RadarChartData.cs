using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.RadarChart
{
    public class RadarChartData : ChartDataXF<IRadarDataSet,RadarEntry>
    {
        public RadarChartData(List<IRadarDataSet> _DataSetItems) : base(_DataSetItems)
        {
        }
    }
}