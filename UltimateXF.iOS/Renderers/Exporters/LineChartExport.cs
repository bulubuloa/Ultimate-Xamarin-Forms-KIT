using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class LineChartExport
    {
        public iOSCharts.LineChartData Export(LineChartData data)
        {
            var dataSetItems = new List<iOSCharts.LineChartDataSet>();

            foreach (var itemChild in data.IF_GetDataSet())
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new iOSCharts.ChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new iOSCharts.LineChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                if (itemChild.IF_GetDataColorScheme() != null)
                    dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                IntializeDataSet(itemChild, dataSet);
                dataSetItems.Add(dataSet);
            }

            var lineData = new iOSCharts.LineChartData(dataSetItems.ToArray());
            return lineData;
        }

        private void IntializeDataSet(ILineDataSet source, iOSCharts.LineChartDataSet original)
        {
            if (source.IF_GetDrawMode().HasValue)
                original.Mode = (SupportChart.GetDrawLineMode(source.IF_GetDrawMode().Value));

            if (source.IF_GetCircleRadius().HasValue)
                original.CircleRadius = source.IF_GetCircleRadius().Value;

            if (source.IF_GetCircleHoleRadius().HasValue)
                original.CircleHoleRadius = source.IF_GetCircleHoleRadius().Value;

            if (source.IF_GetDrawCircle().HasValue)
                original.DrawCirclesEnabled = (source.IF_GetDrawCircle().Value);

            if (source.IF_GetCircleColors().Count > 0)
                original.CircleColors = source.IF_GetCircleColors().Select(item => item.ToUIColor()).ToArray();

            if (source.IF_GetDrawFilled().HasValue)
                original.DrawFilledEnabled = (source.IF_GetDrawFilled().Value);

            if (source.IF_GetLineWidth().HasValue)
                original.LineWidth = source.IF_GetLineWidth().Value;
        }
    }
}