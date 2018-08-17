using System;
using Android.Content;
using MikePhil.Charting.Charts;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportPieRadarChartBaseExtendedRenderer<TSupportView, TOriginalChart> : SupportChartExtendedRenderer<TSupportView, TOriginalChart>
        where TSupportView : SupportPieRadarChartBase where TOriginalChart : PieRadarChartBase
    {
        
        public SupportPieRadarChartBaseExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnInitializeOriginalChartSettings()
        {
            base.OnInitializeOriginalChartSettings();
            if (SupportChartView != null && OriginalChartView != null)
            {
                /*
                 * Properties could not set
                 * RawRotationAngle
                 */
                if (SupportChartView.RotateEnabled.HasValue)
                    OriginalChartView.RotationEnabled = SupportChartView.RotateEnabled.Value;

                if (SupportChartView.RotationAngle.HasValue)
                    OriginalChartView.RotationAngle = SupportChartView.RotationAngle.Value;

                //if (SupportChartView.RotateEnabled.HasValue)
                    //OriginalChartView.RawRotationAngle = SupportChartView.RotateEnabled.Value;
            }
        }
    }
}