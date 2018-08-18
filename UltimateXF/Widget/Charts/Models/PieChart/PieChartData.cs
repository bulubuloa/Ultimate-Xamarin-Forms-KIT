using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.PieChart
{
    public class PieChartData : ChartDataXF<IPieDataSet, PieEntry>
    {
        public PieChartData(IPieDataSet dataSet, List<string> _Titles) : base(dataSet, _Titles)
        {
        }
    }
}