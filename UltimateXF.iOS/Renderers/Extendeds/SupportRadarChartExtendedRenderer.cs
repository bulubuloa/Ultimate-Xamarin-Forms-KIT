using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportRadarChartExtended), typeof(SupportRadarChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportRadarChartExtendedRenderer : SupportPieRadarChartBaseExtendedRenderer<SupportRadarChartExtended, RadarChartView>
    {
        public SupportRadarChartExtendedRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportRadarChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeOriginalChartSettings()
        {
            base.OnInitializeOriginalChartSettings();
            if (SupportChartView != null && OriginalChartView != null)
            {
                /*
                 * Properties could not set
                 */
                if (SupportChartView.WebLineWidth.HasValue)
                    OriginalChartView.WebLineWidth = (SupportChartView.WebLineWidth.Value);
                
                if (SupportChartView.InnerWebLineWidth.HasValue)
                    OriginalChartView.InnerWebLineWidth = SupportChartView.InnerWebLineWidth.Value;

                if (SupportChartView.WebColor.HasValue)
                    OriginalChartView.WebColor = (SupportChartView.WebColor.Value.ToUIColor());

                if (SupportChartView.WebColorInner.HasValue)
                    OriginalChartView.InnerWebColor = (SupportChartView.WebColorInner.Value.ToUIColor());

                if (SupportChartView.WebAlpha.HasValue)
                    OriginalChartView.WebAlpha = (SupportChartView.WebAlpha.Value);

                if (SupportChartView.DrawWeb.HasValue)
                    OriginalChartView.DrawWeb = (SupportChartView.DrawWeb.Value);

                if (SupportChartView.SkipWebLineCount.HasValue)
                    OriginalChartView.SkipWebLineCount = (SupportChartView.SkipWebLineCount.Value);
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                var dataSetItems = SupportChartView.ChartData.IF_GetDataSet();
                var listDataSetItems = new List<RadarChartDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new RadarChartDataEntry(item.GetValue()));
                    RadarChartDataSet dataSet = new RadarChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    if (itemChild.IF_GetDataColorScheme() != null)
                        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                    listDataSetItems.Add(dataSet);
                }

                var data = new RadarChartData(listDataSetItems.ToArray());

                OriginalChartView.Data = data;
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}
