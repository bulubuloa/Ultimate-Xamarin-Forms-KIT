using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportBarChartExtended), typeof(SupportBarChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportBarChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBarChartExtended, BarChartView>
    {
        public SupportBarChartExtendedRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportBarChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeOriginalChart()
        {
            base.OnInitializeOriginalChart();
            OriginalChartView = new BarChartView()
            {
                Frame = this.Frame
            };
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                var dataSetItems = new List<BarChartDataSet>();

                foreach (var item in SupportChartView.ChartData.DataSetItems)
                {
                    var entryOriginal = item.IF_GetEntry().Select(obj => new BarChartDataEntry(obj.GetXPosition(), obj.GetYPosition()));
                    var dataSet = new BarChartDataSet(entryOriginal.ToArray(), item.IF_GetTitle());
                    if (item.IF_GetDataColorScheme() != null)
                        dataSet.SetColors(item.IF_GetDataColorScheme().Select(obj => obj.ToUIColor()).ToArray(), 1f);
                    dataSet.DrawValuesEnabled = (item.IF_GetDrawValue());
                    dataSetItems.Add(dataSet);
                }
                var data = new BarChartData(dataSetItems.ToArray());
                OriginalChartView.Data = data;

                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}