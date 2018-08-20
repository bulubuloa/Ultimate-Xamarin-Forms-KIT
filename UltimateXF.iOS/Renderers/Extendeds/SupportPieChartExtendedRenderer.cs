using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportPieChartExtended), typeof(SupportPieChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportPieChartExtendedRenderer : SupportPieRadarChartBaseExtendedRenderer<SupportPieChartExtended, PieChartView>
    {
        public SupportPieChartExtendedRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportPieChartExtended.ChartData)))
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
                 * DrawRoundedSlices
                 * AbsoluteAngles
                 * DrawAngles
                 */
                if (SupportChartView.DrawEntryLabels.HasValue)
                    OriginalChartView.DrawEntryLabelsEnabled = (SupportChartView.DrawEntryLabels.Value);

                if (SupportChartView.DrawHole.HasValue)
                    OriginalChartView.DrawHoleEnabled = SupportChartView.DrawHole.Value;

                if (SupportChartView.DrawSlicesUnderHole.HasValue)
                    OriginalChartView.DrawSlicesUnderHoleEnabled = (SupportChartView.DrawSlicesUnderHole.Value);

                if (SupportChartView.UsePercentValues.HasValue)
                    OriginalChartView.UsePercentValuesEnabled = (SupportChartView.UsePercentValues.Value);

                OriginalChartView.CenterText = (SupportChartView.CenterText);

                if (SupportChartView.HoleRadiusPercent.HasValue)
                    OriginalChartView.HoleRadiusPercent = (SupportChartView.HoleRadiusPercent.Value);

                if (SupportChartView.TransparentCircleRadiusPercent.HasValue)
                    OriginalChartView.TransparentCircleRadiusPercent = (SupportChartView.TransparentCircleRadiusPercent.Value);

                if (SupportChartView.CenterTextRadiusPercent.HasValue)
                    OriginalChartView.CenterTextRadiusPercent = (SupportChartView.CenterTextRadiusPercent.Value);

                if (SupportChartView.MaxAngle.HasValue)
                    OriginalChartView.MaxAngle = (SupportChartView.MaxAngle.Value);

                if (SupportChartView.DrawCenterText.HasValue)
                    OriginalChartView.DrawCenterTextEnabled = (SupportChartView.DrawCenterText.Value);
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                var data = SupportChartView.ChartData.DataSets;
                var dataSetItems = new List<PieChartDataSet>();
                foreach (var item in data)
                {
                    var entryOriginal = item.IF_GetValues().Select(obj => new ChartDataEntry(obj.GetPercent(), obj.GetPercent()));
                    PieChartDataSet dataSet = new PieChartDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                }

                PieChartData chartData = new PieChartData(dataSetItems.ToArray());

                OriginalChartView.Data = chartData;
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}