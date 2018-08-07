using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class BubbleChartExport
    {
        public iOSCharts.BubbleChartData Export(BubbleChartData supportChart)
        {
            var dataSetItems = supportChart.IF_GetDataSet();
            var listDataSetItems = new List<iOSCharts.BubbleChartDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.BubbleChartDataEntry(item.GetXPosition(), item.GetYPosition(), item.GetSize()));
                var dataSet = new iOSCharts.BubbleChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                if (itemChild.IF_GetDataColorScheme() != null)
                    dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                listDataSetItems.Add(dataSet);
            }
            var data = new iOSCharts.BubbleChartData(listDataSetItems.ToArray());
            return data;
        }
    }
}