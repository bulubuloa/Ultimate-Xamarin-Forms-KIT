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

        protected override void OnInitializeOriginalChart()
        {
            base.OnInitializeOriginalChart();
            OriginalChartView = new PieChartView()
            {
                Frame = this.Frame
            };
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
                var data = SupportChartView.ChartData.IF_GetDataSet();

                var entryOriginal = data.IF_GetEntry().Select(item => new ChartDataEntry(item.GetPercent(), item.GetPercent()));
                PieChartDataSet dataSet = new PieChartDataSet(entryOriginal.ToArray(), data.IF_GetTitle());
                dataSet.SetColors(data.IF_GetDataColorScheme().Select(item => item.ToUIColor()).ToArray(), 1f);
                PieChartData chartData = new PieChartData(new PieChartDataSet[] { dataSet });

                OriginalChartView.Data = chartData;
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}