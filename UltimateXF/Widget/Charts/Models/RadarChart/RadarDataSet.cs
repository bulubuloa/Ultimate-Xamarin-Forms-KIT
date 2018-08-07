using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.RadarChart
{
    public class RadarDataSet : BaseDataSet<RadarEntry>, IRadarDataSet
    {
        public RadarDataSet(List<RadarEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }
    }
}
