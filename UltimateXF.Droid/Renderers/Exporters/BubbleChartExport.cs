using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class BubbleChartExport
    {
        public MikePhil.Charting.Data.BubbleData Export(BubbleChartData ChartData)
        {
            var dataSetItems = ChartData.DataSets;
            var listDataSetItems = new List<MikePhil.Charting.Data.BubbleDataSet>();

            //foreach (var itemChild in dataSetItems)
            //{
            //    var entryOriginal = itemChild.IF_GetEntry().Select(item => new MikePhil.Charting.Data.BubbleEntry(item.GetXPosition(), item.GetYPosition(), item.GetSize()));
            //    var dataSet = new MikePhil.Charting.Data.BubbleDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
            //    if (itemChild.IF_GetDataColorScheme() != null)
            //        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
            //    listDataSetItems.Add(dataSet);
            //}

            var data = new MikePhil.Charting.Data.BubbleData(listDataSetItems.ToArray());
            return data;
        }
    }
}