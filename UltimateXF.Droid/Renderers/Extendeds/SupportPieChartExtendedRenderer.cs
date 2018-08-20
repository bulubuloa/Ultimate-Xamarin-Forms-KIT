using System;
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

[assembly: ExportRenderer(typeof(SupportPieChartExtended), typeof(SupportPieChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportPieChartExtendedRenderer : SupportPieRadarChartBaseExtendedRenderer<SupportPieChartExtended, PieChart>
    {
        public SupportPieChartExtendedRenderer(Context context) : base(context)
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
                    OriginalChartView.SetDrawEntryLabels(SupportChartView.DrawEntryLabels.Value);

                if (SupportChartView.DrawHole.HasValue)
                    OriginalChartView.DrawHoleEnabled = SupportChartView.DrawHole.Value;

                if (SupportChartView.DrawSlicesUnderHole.HasValue)
                    OriginalChartView.SetDrawSlicesUnderHole(SupportChartView.DrawSlicesUnderHole.Value);

                if (SupportChartView.UsePercentValues.HasValue)
                    OriginalChartView.SetUsePercentValues(SupportChartView.UsePercentValues.Value);

                OriginalChartView.CenterText = (SupportChartView.CenterText);

                if (SupportChartView.HoleRadiusPercent.HasValue)
                    OriginalChartView.HoleRadius = (SupportChartView.HoleRadiusPercent.Value);

                if (SupportChartView.TransparentCircleRadiusPercent.HasValue)
                    OriginalChartView.TransparentCircleRadius = (SupportChartView.TransparentCircleRadiusPercent.Value);

                if (SupportChartView.CenterTextRadiusPercent.HasValue)
                    OriginalChartView.CenterTextRadiusPercent = (SupportChartView.CenterTextRadiusPercent.Value);

                if (SupportChartView.MaxAngle.HasValue)
                    OriginalChartView.MaxAngle = (SupportChartView.MaxAngle.Value);

                if (SupportChartView.DrawCenterText.HasValue)
                    OriginalChartView.SetDrawCenterText(SupportChartView.DrawCenterText.Value);
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                //var dataSupport = SupportChartView.ChartData.IF_GetDataSet();

                //var entryOriginal = dataSupport.IF_GetEntry().Select(item => new PieEntry(item.GetPercent(), item.GetText()));
                //PieDataSet dataSet = new PieDataSet(entryOriginal.ToArray(), dataSupport.IF_GetTitle());
                //dataSet.SetColors(dataSupport.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
                //var data = new PieData(dataSet);

                //OriginalChartView.Data = data;
                //OriginalChartView.Invalidate();
            }
        }
    }
}