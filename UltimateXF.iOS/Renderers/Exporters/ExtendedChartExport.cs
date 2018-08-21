using System;
using System.Collections.Generic;
using System.Linq;
using iOSCharts;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.ComponentXF;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms.Platform.iOS;

namespace UltimateXF.iOS.Renderers.Exporters
{
    public class ExtendedChartExport
    {
        /*
         * EXPORT FOR BUBBLE
         */
        public BubbleChartData ExportBubbleData(Widget.Charts.Models.BubbleChart.BubbleChartData bubbleChartData)
        {
            var dataSetItems = new List<BubbleChartDataSet>();
            foreach (var item in bubbleChartData.DataSets)
            {
                var entryOriginal = item.IF_GetValues().Select(obj => new BubbleChartDataEntry(obj.GetXPosition(), obj.GetYPosition(), obj.GetSize()));
                var dataSet = new BubbleChartDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                OnIntializeDataSetBubble(item, dataSet);
                dataSetItems.Add(dataSet);
            }
            var data = new BubbleChartData(dataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetBubble(UltimateXF.Widget.Charts.Models.BubbleChart.IBubbleDataSet source, BubbleChartDataSet original)
        {
            /*
             * Properties could not setting 
             * IF_GetMaxSize
             */
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetNormalizeSize().HasValue)
                original.NormalizeSizeEnabled = (source.IF_GetNormalizeSize().Value);

            if (source.IF_GetHighlightCircleWidth().HasValue)
                original.HighlightCircleWidth = (source.IF_GetHighlightCircleWidth().Value);
        }


        /*
         * EXPORT FOR LINE
         */
        public iOSCharts.LineChartData ExportLineData(Widget.Charts.Models.LineChart.LineChartData bubbleChartData)
        {
            var dataSetItems = new List<LineChartDataSet>();
            foreach (var item in bubbleChartData.DataSets)
            {
                var entryOriginal = item.IF_GetValues().Select(obj => new ChartDataEntry(obj.GetXPosition(), obj.GetYPosition()));
                var dataSet = new LineChartDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                OnIntializeDataSetLine(item, dataSet);
                dataSetItems.Add(dataSet);
            }
            var data = new iOSCharts.LineChartData(dataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetLine(ILineDataSetXF source, LineChartDataSet original)
        {
            OnSettingsLineRadarDataSet(source, original);

            if (source.IF_GetMode().HasValue)
                original.Mode = (GetDrawLineMode(source.IF_GetMode().Value));

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


        /*
         * EXPORT FOR BAR
         */
        public BarChartData ExportBarData(Widget.Charts.Models.BarChart.BarChartData bubbleChartData)
        {
            var dataSetItems = new List<BarChartDataSet>();

            foreach (var item in bubbleChartData.DataSets)
            {
                var entryOriginal = item.IF_GetValues().Select(obj => new BarChartDataEntry(obj.GetXPosition(), obj.GetYPosition()));
                var dataSet = new BarChartDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                OnIntializeDataSetBar(item, dataSet);
                dataSetItems.Add(dataSet);
            }
            var data = new BarChartData(dataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetBar(UltimateXF.Widget.Charts.Models.BarChart.IBarDataSet source, BarChartDataSet original)
        {
            /*
             * Properties could not set
             * IF_GetStackSize
             * IF_GetEntryCountStacks
             */

            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetBarShadowColor().HasValue)
                original.BarShadowColor = source.IF_GetBarShadowColor().Value.ToUIColor();

            if (source.IF_GetBarBorderWidth().HasValue)
                original.BarBorderWidth = source.IF_GetBarBorderWidth().Value;

            if (source.IF_GetBarBorderColor().HasValue)
                original.BarBorderColor = source.IF_GetBarBorderColor().Value.ToUIColor();

            if (source.IF_GetHighLightAlpha().HasValue)
                original.HighlightAlpha = source.IF_GetHighLightAlpha().Value;

            if (source.IF_GetStackLabels() != null && source.IF_GetStackLabels().Count > 0)
                original.StackLabels = (source.IF_GetStackLabels().ToArray());
        }


        /*
         * EXPORT FOR SCATTER
         */
        public ScatterChartData ExportScatterData(Widget.Charts.Models.ScatterChart.ScatterChartData bubbleChartData)
        {
            var dataSetItems = bubbleChartData.DataSets;
            var listDataSetItems = new List<ScatterChartDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetValues().Select(item => new ChartDataEntry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new ScatterChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetLabel());
                OnIntializeDataSetScatter(itemChild,dataSet);
                listDataSetItems.Add(dataSet);
            }
            var data = new ScatterChartData(listDataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetScatter(Widget.Charts.Models.ScatterChart.IScatterDataSet source, ScatterChartDataSet original)
        {
            OnSettingsLineScatterCandleRadarDataSet(source, original);

            if (source.IF_GetShapeSize().HasValue)
                original.ScatterShapeSize = (source.IF_GetShapeSize().Value);

            if (source.IF_GetScatterShapeHoleColor().HasValue)
                original.ScatterShapeHoleColor = (source.IF_GetScatterShapeHoleColor().Value.ToUIColor());

            if (source.IF_GetScatterShapeHoleRadius().HasValue)
                original.ScatterShapeHoleRadius = (source.IF_GetScatterShapeHoleRadius().Value);
        }


        /*
         * EXPORT FOR CANDLE STICK
         */
        public CandleChartData ExportCandleStickData(Widget.Charts.Models.CandleStickChart.CandleStickChartData bubbleChartData)
        {
            var dataSetItems = bubbleChartData.DataSets;
            var listDataSetItems = new List<CandleChartDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetValues().Select(item => new CandleChartDataEntry(item.GetXPosition(), item.GetHigh(), item.GetLow(), item.GetOpen(), item.GetClose()));
                CandleChartDataSet dataSet = new CandleChartDataSet(entryOriginal.ToArray(), itemChild.IF_GetLabel());
                OnIntializeDataSetCandle(itemChild, dataSet);
                listDataSetItems.Add(dataSet);
            }

            CandleChartData data = new CandleChartData(listDataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetCandle(ICandleStickDataSet source, CandleChartDataSet original)
        {
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetShadowWidth().HasValue)
                original.ShadowWidth = source.IF_GetShadowWidth().Value;

            if (source.IF_GetShowCandleBar().HasValue)
                original.ShowCandleBar = source.IF_GetShowCandleBar().Value;

            if (source.IF_GetBarSpace().HasValue)
                original.BarSpace = source.IF_GetBarSpace().Value;

            if (source.IF_GetShadowColorSameAsCandle().HasValue)
                original.ShadowColorSameAsCandle = source.IF_GetShadowColorSameAsCandle().Value;

            if (source.IF_GetIncreasingPaintStyle().HasValue)
                original.IncreasingFilled = ConvertPaintStyle(source.IF_GetIncreasingPaintStyle().Value);

            if (source.IF_GetDecreasingPaintStyle().HasValue)
                original.DecreasingFilled = ConvertPaintStyle(source.IF_GetDecreasingPaintStyle().Value);

            if (source.IF_GetNeutralColor().HasValue)
                original.NeutralColor = source.IF_GetNeutralColor().Value.ToUIColor();

            if (source.IF_GetDecreasingColor().HasValue)
                original.DecreasingColor = source.IF_GetDecreasingColor().Value.ToUIColor();

            if (source.IF_GetIncreasingColor().HasValue)
                original.IncreasingColor = source.IF_GetIncreasingColor().Value.ToUIColor();

            if (source.IF_GetShadowColor().HasValue)
                original.ShadowColor = source.IF_GetShadowColor().Value.ToUIColor();
        }

        private bool ConvertPaintStyle(PaintStyle source)
        {
            switch (source)
            {
                case PaintStyle.STROKE:
                    return false;
                default:
                    return true;
            }
        }




        /*
         * EXPORT SETTINGS
         */
        public void OnSettingsBaseDataSet<TEntry>(IBaseDataSetXF<TEntry> baseDataSetXF, ChartBaseDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            /*
                 * Properties could not set
                 * IF_GetGradientColor
                 * IF_GetValueTextSize
                 * IF_GetValueFormatter
                 */
            if (baseDataSetXF.IF_GetColors() != null && baseDataSetXF.IF_GetColors().Count > 0)
            {
                originalBaseDataSet.SetColors(baseDataSetXF.IF_GetColors().Select(obj => obj.ToUIColor()).ToArray(), 1f);
            }
            if (baseDataSetXF.IF_GetValueColors() != null && baseDataSetXF.IF_GetValueColors().Count > 0)
            {
                originalBaseDataSet.ValueColors = (baseDataSetXF.IF_GetValueColors().Select(obj => obj.ToUIColor()).ToArray());
            }
            if (baseDataSetXF.IF_GetHighlightEnabled().HasValue)
            {
                originalBaseDataSet.HighlightEnabled = baseDataSetXF.IF_GetHighlightEnabled().Value;
            }
            if (baseDataSetXF.IF_GetVisible().HasValue)
            {
                originalBaseDataSet.Visible = baseDataSetXF.IF_GetVisible().Value;
            }
            if (baseDataSetXF.IF_GetDrawIcons().HasValue)
            {
                originalBaseDataSet.DrawIconsEnabled = baseDataSetXF.IF_GetDrawIcons().Value ? 1 : 0;
            }
            if (baseDataSetXF.IF_GetDrawValues().HasValue)
            {
                originalBaseDataSet.DrawValuesEnabled = baseDataSetXF.IF_GetDrawValues().Value;
            }
            if (baseDataSetXF.IF_GetValueFormatter() != null)
            {
                originalBaseDataSet.ValueFormatter = new DataSetValueFormatterExport(baseDataSetXF.IF_GetValueFormatter());
            }
        }

        public void OnSettingsBarLineScatterCandleBubbleDataSet<TEntry>(IBarLineScatterCandleBubbleDataSetXF<TEntry> baseDataSetXF, BarLineScatterCandleBubbleChartDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            OnSettingsBaseDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetighLightColor().HasValue)
            {
                originalBaseDataSet.HighlightColor = baseDataSetXF.IF_GetighLightColor().Value.ToUIColor();
            }
        }

        public void OnSettingsLineScatterCandleRadarDataSet<TEntry>(ILineScatterCandleRadarDataSetXF<TEntry> baseDataSetXF, LineScatterCandleRadarChartDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            OnSettingsBarLineScatterCandleBubbleDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.DrawVerticalHighlightIndicatorEnabled = baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().Value;
            }
            if (baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.DrawHorizontalHighlightIndicatorEnabled = baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().Value;
            }
            if (baseDataSetXF.IF_GetHighlightLineWidth().HasValue)
            {
                originalBaseDataSet.HighlightLineWidth = baseDataSetXF.IF_GetHighlightLineWidth().Value;
            }
        }

        public void OnSettingsLineRadarDataSet<TEntry>(ILineRadarDataSetXF<TEntry> baseDataSetXF, LineRadarChartDataSet originalBaseDataSet) where TEntry : BaseEntry
        {
            OnSettingsLineScatterCandleRadarDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetFillColor().HasValue)
            {
                originalBaseDataSet.FillColor = baseDataSetXF.IF_GetFillColor().Value.ToUIColor();
            }

            if (baseDataSetXF.IF_GetFillAlpha().HasValue)
            {
                originalBaseDataSet.FillAlpha = baseDataSetXF.IF_GetFillAlpha().Value;
            }

            if (baseDataSetXF.IF_GetLineWidth().HasValue)
            {
                originalBaseDataSet.LineWidth = baseDataSetXF.IF_GetLineWidth().Value;
            }

            if (baseDataSetXF.IF_GetDrawFilled().HasValue)
            {
                originalBaseDataSet.DrawFilledEnabled = baseDataSetXF.IF_GetDrawFilled().Value;
            }
        }

        protected XAxisLabelPosition GetXAxisPosition(XAXISPosition mode)
        {
            switch (mode)
            {
                case XAXISPosition.BOTTOM:
                    return XAxisLabelPosition.Bottom;
                case XAXISPosition.TOP:
                    return XAxisLabelPosition.Top;
                case XAXISPosition.BOTTOM_INSIDE:
                    return XAxisLabelPosition.BottomInside;
                case XAXISPosition.TOP_INSIDE:
                    return XAxisLabelPosition.TopInside;
                case XAXISPosition.BOTH:
                    return XAxisLabelPosition.BothSided;
                default:
                    return XAxisLabelPosition.Top;
            }
        }

        protected LineChartMode GetDrawLineMode(LineDataSetMode mode)
        {
            switch (mode)
            {
                case LineDataSetMode.CUBIC_BEZIER:
                    return LineChartMode.CubicBezier;
                case LineDataSetMode.CUBIC_HORIZONTAL:
                    return LineChartMode.HorizontalBezier;
                case LineDataSetMode.STEPPED:
                    return LineChartMode.Stepped;
                case LineDataSetMode.LINEAR:
                    return LineChartMode.Linear;
                default:
                    return LineChartMode.Linear;
            }
        }
    }
}
