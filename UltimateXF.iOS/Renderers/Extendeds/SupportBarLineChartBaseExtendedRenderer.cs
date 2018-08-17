using System;
using iOSCharts;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportBarLineChartBaseExtendedRenderer<TSupportView,TOriginalChart> : SupportChartExtendedRenderer<TSupportView, TOriginalChart>
        where TSupportView : SupportBarLineChartBase where TOriginalChart : BarLineChartViewBase
    {
        public SupportBarLineChartBaseExtendedRenderer()
        {
        }

        protected override void OnInitializeOriginalChartSettings()
        {
            base.OnInitializeOriginalChartSettings();
            if (SupportChartView != null && OriginalChartView != null)
            {
                /*
                 * Properties could not set
                 */
                if (SupportChartView.AutoScaleMinMaxEnabled.HasValue)
                    OriginalChartView.AutoScaleMinMaxEnabled = SupportChartView.AutoScaleMinMaxEnabled.Value;

                if (SupportChartView.PinchZoomEnabled.HasValue)
                    OriginalChartView.PinchZoomEnabled = SupportChartView.PinchZoomEnabled.Value;

                if (SupportChartView.DoubleTapToZoomEnabled.HasValue)
                    OriginalChartView.DoubleTapToZoomEnabled = SupportChartView.DoubleTapToZoomEnabled.Value;

                if (SupportChartView.DragXEnabled.HasValue)
                    OriginalChartView.DragEnabled = SupportChartView.DragXEnabled.Value;

                if (SupportChartView.DragYEnabled.HasValue)
                    OriginalChartView.DragEnabled = SupportChartView.DragYEnabled.Value;

                if (SupportChartView.ScaleXEnabled.HasValue)
                    OriginalChartView.ScaleXEnabled = SupportChartView.ScaleXEnabled.Value;

                if (SupportChartView.ScaleYEnabled.HasValue)
                    OriginalChartView.ScaleYEnabled = SupportChartView.ScaleYEnabled.Value;

                if (SupportChartView.DrawGridBackground.HasValue)
                    OriginalChartView.DrawGridBackgroundEnabled = SupportChartView.DrawGridBackground.Value;

                if (SupportChartView.DrawBorders.HasValue)
                    OriginalChartView.DrawBordersEnabled = SupportChartView.DrawBorders.Value;

                if (SupportChartView.ClipValuesToContent.HasValue)
                    OriginalChartView.ClipValuesToContentEnabled = SupportChartView.ClipValuesToContent.Value;

                if (SupportChartView.MaxVisibleCount.HasValue)
                    OriginalChartView.MaxVisibleCount = SupportChartView.MaxVisibleCount.Value;

                if (SupportChartView.AxisLeft != null)
                {
                    var SupportAxisLeft = SupportChartView.AxisLeft;
                    var OriginalLeftAxis = OriginalChartView.LeftAxis;

                    OriginalLeftAxis.SetupConfigBase(SupportAxisLeft);
                    OriginalLeftAxis.SetupAxisConfigBase(SupportAxisLeft);
                    OriginalLeftAxis.SetupYAxisConfig(SupportAxisLeft);
                }

                if (SupportChartView.AxisRight != null)
                {
                    var SupportAxisRight = SupportChartView.AxisLeft;
                    var OriginalRightAxis = OriginalChartView.RightAxis;

                    OriginalRightAxis.SetupConfigBase(SupportAxisRight);
                    OriginalRightAxis.SetupAxisConfigBase(SupportAxisRight);
                    OriginalRightAxis.SetupYAxisConfig(SupportAxisRight);
                }
            }
        }
    }
}