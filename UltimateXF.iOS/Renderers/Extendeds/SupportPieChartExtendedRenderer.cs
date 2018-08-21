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
                var dataSupport = SupportChartView.ChartData;
                var dataSetSource = dataSupport.DataSets.FirstOrDefault();

                if (dataSetSource != null)
                {
                    var entryOriginal = dataSetSource.IF_GetValues().Select(item => new PieChartDataEntry(item.GetPercent(), item.GetText()));
                    PieChartDataSet dataSet = new PieChartDataSet(entryOriginal.ToArray(), dataSetSource.IF_GetLabel());
                    OnIntializeDataSet(dataSetSource, dataSet);
                    PieChartData chartData = new PieChartData(new PieChartDataSet[]{dataSet});

                    OriginalChartView.Data = chartData;
                }
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }

        private void OnIntializeDataSet(Widget.Charts.Models.PieChart.IPieDataSet source, PieChartDataSet original)
        {
            /*
             * Properies could not net
             * IF_GetUsingSliceColorAsValueLineColor
             */
            Export.OnSettingsBaseDataSet(source, original);

            if (source.IF_GetSliceSpace().HasValue)
                original.SliceSpace = (source.IF_GetSliceSpace().Value);

            if (source.IF_GetAutomaticallyDisableSliceSpacing().HasValue)
                original.AutomaticallyDisableSliceSpacing = (source.IF_GetAutomaticallyDisableSliceSpacing().Value);

            if (source.IF_GetShift().HasValue)
                original.SelectionShift = (source.IF_GetShift().Value);

            if (source.IF_GetValueLineColor().HasValue)
                original.ValueLineColor = (source.IF_GetValueLineColor().Value.ToUIColor());

            if (source.IF_GetValueLineWidth().HasValue)
                original.ValueLineWidth = (source.IF_GetValueLineWidth().Value);

            if (source.IF_GetValueLinePart1OffsetPercentage().HasValue)
                original.ValueLinePart1OffsetPercentage = (source.IF_GetValueLinePart1OffsetPercentage().Value);

            if (source.IF_GetValueLinePart1Length().HasValue)
                original.ValueLinePart1Length = (source.IF_GetValueLinePart1Length().Value);

            if (source.IF_GetValueLinePart2Length().HasValue)
                original.ValueLinePart2Length = (source.IF_GetValueLinePart2Length().Value);

            if (source.IF_GetValueLineVariableLength().HasValue)
                original.ValueLineVariableLength = (source.IF_GetValueLineVariableLength().Value);

            if (source.IF_GetXValuePosition().HasValue)
                original.XValuePosition = source.IF_GetXValuePosition().Value == Widget.Charts.Models.PieChart.ValuePosition.INSIDE_SLICE ? PieChartValuePosition.InsideSlice : PieChartValuePosition.OutsideSlice;

            if (source.IF_GetYValuePosition().HasValue)
                original.YValuePosition = source.IF_GetYValuePosition().Value == Widget.Charts.Models.PieChart.ValuePosition.INSIDE_SLICE ? PieChartValuePosition.InsideSlice : PieChartValuePosition.OutsideSlice;
        }
    }
}