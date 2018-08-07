using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.ScatterChart;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class ScatterChartExport
    {
        public iOSCharts.ScatterChartData Export(ScatterChartData supportChart)
        {
            var dataSetItems = supportChart.IF_GetDataSet();
            var listDataSetItems = new List<iOSCharts.ScatterChartDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.ChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new iOSCharts.ScatterChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                listDataSetItems.Add(dataSet);
            }
            var data = new iOSCharts.ScatterChartData(listDataSetItems.ToArray());
            return data;
        }
    }
}