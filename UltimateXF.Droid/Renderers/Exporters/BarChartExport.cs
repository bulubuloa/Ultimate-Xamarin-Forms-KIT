using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.BarChart;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class BarChartExport
    {
        public MikePhil.Charting.Data.BarData Export(BarChartData ChartData)
        {
            var dataSetItems = new List<MikePhil.Charting.Data.BarDataSet>();

            foreach (var itemChild in ChartData.IF_GetDataSet())
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new MikePhil.Charting.Data.BarEntry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new MikePhil.Charting.Data.BarDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                if (itemChild.IF_GetDataColorScheme() != null)
                    dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
                dataSet.SetDrawValues(itemChild.IF_GetDrawValue());
                dataSetItems.Add(dataSet);
            }
            var lineData = new MikePhil.Charting.Data.BarData(dataSetItems.ToArray());
            return lineData;
        }
    }
}