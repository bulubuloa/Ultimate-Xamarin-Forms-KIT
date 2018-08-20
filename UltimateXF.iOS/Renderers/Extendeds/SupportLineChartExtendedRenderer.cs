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
                foreach (var item in SupportChartView.ChartData.DataSets)
                {
                    var entryOriginal = item.IF_GetValues().Select(obj => new ChartDataEntry(obj.GetXPosition(),obj.GetYPosition()));
                    var dataSet = new LineChartDataSet(entryOriginal.ToArray(),item.IF_GetLabel());
                    OnIntializeDataSet(item, dataSet);
                    dataSetItems.Add(dataSet);
                }
                var data = new iOSCharts.LineChartData(dataSetItems.ToArray());
                OriginalChartView.Data = data;

                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }


        private void OnIntializeDataSet(ILineDataSetXF source, LineChartDataSet original)
        {
            OnSettingsLineRadarDataSet(source,original);

            if (source.IF_GetMode().HasValue)
                original.Mode = (SupportChart.GetDrawLineMode(source.IF_GetMode().Value));
            
            if (source.IF_GetCircleColors() != null && source.IF_GetCircleColors().Count > 0)
                original.CircleColors = source.IF_GetCircleColors().Select(item => item.ToUIColor()).ToArray();

            if (source.IF_GetCircleHoleColor().HasValue)
                original.CircleHoleColor = source.IF_GetCircleHoleColor().Value.ToUIColor();
            
            if (source.IF_GetCircleRadius().HasValue)
                original.CircleRadius = source.IF_GetCircleRadius().Value;

            if (source.IF_GetCircleHoleRadius().HasValue)
                original.CircleHoleRadius = source.IF_GetCircleHoleRadius().Value;

            if (source.IF_GetCubicIntensity().HasValue)
                original.CubicIntensity = source.IF_GetCubicIntensity().Value;

            if (source.IF_GetDrawCircles().HasValue)
                original.DrawCirclesEnabled = (source.IF_GetDrawCircles().Value);
            
            if (source.IF_GetDrawCircleHole().HasValue)
                original.DrawCircleHoleEnabled = (source.IF_GetDrawCircleHole().Value);
        }
    }
}