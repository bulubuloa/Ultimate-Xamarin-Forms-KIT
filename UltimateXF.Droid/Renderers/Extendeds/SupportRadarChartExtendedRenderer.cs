using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportRadarChartExtended), typeof(SupportRadarChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportRadarChartExtendedRenderer : SupportPieRadarChartBaseExtendedRenderer<SupportRadarChartExtended, RadarChart>
    {
        public SupportRadarChartExtendedRenderer(Context context) : base(context)
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

        protected override void OnInitializeOriginalChart()
        {
            base.OnInitializeOriginalChart();
            OriginalChartView = new RadarChart(this.Context);
            OriginalChartView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
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
                    OriginalChartView.WebLineWidthInner = SupportChartView.InnerWebLineWidth.Value;

                if (SupportChartView.WebColor.HasValue)
                    OriginalChartView.WebColor = (SupportChartView.WebColor.Value.ToAndroid());

                if (SupportChartView.WebColorInner.HasValue)
                    OriginalChartView.WebColorInner = (SupportChartView.WebColorInner.Value.ToAndroid());

                if (SupportChartView.WebAlpha.HasValue)
                    OriginalChartView.WebAlpha = (SupportChartView.WebAlpha.Value);

                if (SupportChartView.DrawWeb.HasValue)
                    OriginalChartView.SetDrawWeb(SupportChartView.DrawWeb.Value);

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
                var listDataSetItems = new List<RadarDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetEntry().Select(item => new RadarEntry(item.GetValue()));
                    RadarDataSet dataSet = new RadarDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());
                    if (itemChild.IF_GetDataColorScheme() != null)
                        dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
                    listDataSetItems.Add(dataSet);
                }

                RadarData data = new RadarData(listDataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
        }
    }
}