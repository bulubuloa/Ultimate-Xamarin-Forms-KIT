using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.PieChart
{
    public class PieChartData : BaseDataSingleSet<PieEntry, IPieDataSet>
    {
        public Color ValueDisplayColor { set; get; }
        public float ValueDisplaySize { set; get; }

        public Color TextDisplayColor { set; get; }
        public float TextDisplaySize { set; get; }


        public PieChartData(IPieDataSet _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
        }
    }
}