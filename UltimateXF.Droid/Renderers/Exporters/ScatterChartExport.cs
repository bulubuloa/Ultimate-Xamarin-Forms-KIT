using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.ScatterChart;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class ScatterChartExport
    {
        public MikePhil.Charting.Data.ScatterData Export(ScatterChartData ChartData)
        {
            var dataSetItems = ChartData.IF_GetDataSet();
            var listDataSetItems = new List<MikePhil.Charting.Data.ScatterDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new MikePhil.Charting.Data.Entry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new MikePhil.Charting.Data.ScatterDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                listDataSetItems.Add(dataSet);
            }
            var data = new MikePhil.Charting.Data.ScatterData(listDataSetItems.ToArray());
            return data;
        }
    }
}