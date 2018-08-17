using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportLineChartExtended), typeof(SupportLineChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportLineChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportLineChartExtended,LineChartView>
    {
        public SupportLineChartExtendedRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportLineChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if(OriginalChartView!=null && SupportChartView!=null && SupportChartView.ChartData!=null)
            {
                var dataSetItems = new List<LineChartDataSet>();
                foreach (var item in SupportChartView.ChartData.DataSetItems)
                {
                    var entryOriginal = item.IF_GetEntry().Select(obj => new ChartDataEntry(obj.GetXPosition(),obj.GetYPosition()));
                    var dataSet = new LineChartDataSet(entryOriginal.ToArray(),item.IF_GetTitle());
                    if(item.IF_GetDataColorScheme()!=null)
                    {
                        dataSet.SetColors(item.IF_GetDataColorScheme().Select(obj => obj.ToUIColor()).ToArray(), 1f);
                    }
                    IntializeDataSet(item, dataSet);
                    dataSetItems.Add(dataSet);
                }
                var data = new iOSCharts.LineChartData(dataSetItems.ToArray());
                OriginalChartView.Data = data;

                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }

        private void IntializeDataSet(ILineDataSet source, LineChartDataSet original)
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