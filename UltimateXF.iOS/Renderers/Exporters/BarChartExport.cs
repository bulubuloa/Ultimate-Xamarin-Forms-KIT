using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.BarChart;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class BarChartExport
    {
        public iOSCharts.BarChartData Export(BarChartData ChartData)
        {
            var dataSetItems = new List<iOSCharts.BarChartDataSet>();

            foreach (var itemChild in ChartData .IF_GetDataSet())
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.BarChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new iOSCharts.BarChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                if (itemChild.IF_GetDataColorScheme() != null)
                    dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                dataSet.DrawValuesEnabled = (itemChild.IF_GetDrawValue());
                dataSetItems.Add(dataSet);
            }
            var lineData = new iOSCharts.BarChartData(dataSetItems.ToArray());
            return lineData;
        }
    }
}