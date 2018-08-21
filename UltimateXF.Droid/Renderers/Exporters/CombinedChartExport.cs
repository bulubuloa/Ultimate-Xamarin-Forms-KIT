using System;
using System.Collections.Generic;
using System.Linq;
using MikePhil.Charting.Components;
using MikePhil.Charting.Data;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using UltimateXF.Widget.Charts.Models.Component;
using UltimateXF.Widget.Charts.Models.ComponentXF;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class ExtendedChartExport
    {
        /*
         * EXPORT FOR BUBBLE
         */
        public BubbleData ExportBubbleData(Widget.Charts.Models.BubbleChart.BubbleChartData bubbleChartData)
        {
            var dataSetItems = new List<BubbleDataSet>();
            foreach (var item in bubbleChartData.DataSets)
            {
                var entryOriginal = item.IF_GetValues().Select(obj => new BubbleEntry(obj.GetXPosition(), obj.GetYPosition(), obj.GetSize()));
                var dataSet = new BubbleDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                OnIntializeDataSetBubble(item, dataSet);
                dataSetItems.Add(dataSet);
            }
            var data = new BubbleData(dataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetBubble(UltimateXF.Widget.Charts.Models.BubbleChart.IBubbleDataSet source, MikePhil.Charting.Data.BubbleDataSet original)
        {
            /*
             * Properties could not setting 
             * IF_GetMaxSize
             */
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetNormalizeSize().HasValue)
                original.SetNormalizeSizeEnabled(source.IF_GetNormalizeSize().Value);

            if (source.IF_GetHighlightCircleWidth().HasValue)
                original.HighlightCircleWidth = (source.IF_GetHighlightCircleWidth().Value);
        }

        
        /*
         * EXPORT FOR LINE
         */
        public LineData ExportLineData(Widget.Charts.Models.LineChart.LineChartData bubbleChartData)
        {
            var dataSetItems = new List<LineDataSet>();
            foreach (var item in bubbleChartData.DataSets)
            {
                var entryOriginal = item.IF_GetValues().Select(obj => new MikePhil.Charting.Data.Entry(obj.GetXPosition(), obj.GetYPosition()));
                var dataSet = new LineDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                OnIntializeDataSetLine(item, dataSet);
                dataSetItems.Add(dataSet);
            }
            var data = new LineData(dataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetLine(ILineDataSetXF source, LineDataSet original)
        {
            OnSettingsLineRadarDataSet(source, original);

            if (source.IF_GetMode().HasValue)
                original.SetMode(GetDrawLineMode(source.IF_GetMode().Value));

            if (source.IF_GetCircleColors() != null && source.IF_GetCircleColors().Count > 0)
                original.SetCircleColors(source.IF_GetCircleColors().Select(item => item.ToAndroid().ToArgb()).ToArray());

            if (source.IF_GetCircleHoleColor().HasValue)
                original.SetCircleColorHole(source.IF_GetCircleHoleColor().Value.ToAndroid());

            if (source.IF_GetCircleRadius().HasValue)
                original.CircleRadius = source.IF_GetCircleRadius().Value;

            if (source.IF_GetCircleHoleRadius().HasValue)
                original.CircleHoleRadius = source.IF_GetCircleHoleRadius().Value;

            if (source.IF_GetCubicIntensity().HasValue)
                original.CubicIntensity = source.IF_GetCubicIntensity().Value;

            if (source.IF_GetDrawCircles().HasValue)
                original.SetDrawCircles(source.IF_GetDrawCircles().Value);

            if (source.IF_GetDrawCircleHole().HasValue)
                original.SetDrawCircleHole(source.IF_GetDrawCircleHole().Value);
        }


        /*
         * EXPORT FOR BAR
         */
        public BarData ExportBarData(Widget.Charts.Models.BarChart.BarChartData bubbleChartData)
        {
            var dataSetItems = new List<BarDataSet>();
            foreach (var item in bubbleChartData.DataSets)
            {
                var entryOriginal = item.IF_GetValues().Select(obj => new BarEntry(obj.GetXPosition(), obj.GetYPosition()));
                var dataSet = new BarDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                OnIntializeDataSetBar(item, dataSet);
                dataSetItems.Add(dataSet);
            }

            var data = new BarData(dataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetBar(UltimateXF.Widget.Charts.Models.BarChart.IBarDataSet source, BarDataSet original)
        {
            /*
             * Properties could not set
             * IF_GetStackSize
             * IF_GetEntryCountStacks
             */
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetBarShadowColor().HasValue)
                original.BarShadowColor = source.IF_GetBarShadowColor().Value.ToAndroid();

            if (source.IF_GetBarBorderWidth().HasValue)
                original.BarBorderWidth = source.IF_GetBarBorderWidth().Value;

            if (source.IF_GetBarBorderColor().HasValue)
                original.BarBorderColor = source.IF_GetBarBorderColor().Value.ToAndroid();

            if (source.IF_GetHighLightAlpha().HasValue)
                original.HighLightAlpha = source.IF_GetHighLightAlpha().Value;

            if (source.IF_GetStackLabels() != null && source.IF_GetStackLabels().Count > 0)
                original.SetStackLabels(source.IF_GetStackLabels().ToArray());
        }


        /*
         * EXPORT FOR SCATTER
         */
        public ScatterData ExportScatterData(Widget.Charts.Models.ScatterChart.ScatterChartData bubbleChartData)
        {
            var dataSetItems = bubbleChartData.DataSets;
            var listDataSetItems = new List<MikePhil.Charting.Data.ScatterDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetValues().Select(item => new MikePhil.Charting.Data.Entry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new MikePhil.Charting.Data.ScatterDataSet(entryOriginal.ToArray(), itemChild.IF_GetLabel());
                OnIntializeDataSetScatter(itemChild,dataSet);
                listDataSetItems.Add(dataSet);
            }
            var data = new MikePhil.Charting.Data.ScatterData(listDataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetScatter(Widget.Charts.Models.ScatterChart.IScatterDataSet source, ScatterDataSet original)
        {
            OnSettingsLineScatterCandleRadarDataSet(source, original);

            if (source.IF_GetShapeSize().HasValue)
                original.ScatterShapeSize = (source.IF_GetShapeSize().Value);

            if (source.IF_GetScatterShapeHoleColor().HasValue)
                original.ScatterShapeHoleColor = (source.IF_GetScatterShapeHoleColor().Value.ToAndroid());

            if (source.IF_GetScatterShapeHoleRadius().HasValue)
                original.ScatterShapeHoleRadius = (source.IF_GetScatterShapeHoleRadius().Value);
        }


        /*
         * EXPORT FOR CANDLE STICK
         */
        public CandleData ExportCandleStickData(Widget.Charts.Models.CandleStickChart.CandleStickChartData bubbleChartData)
        {
            var dataSetItems = bubbleChartData.DataSets;
            var listDataSetItems = new List<MikePhil.Charting.Data.CandleDataSet>();

            foreach (var itemChild in dataSetItems)
            {
                var entryOriginal = itemChild.IF_GetValues().Select(item => new MikePhil.Charting.Data.CandleEntry(item.GetXPosition(), (float)item.GetHigh(), (float)item.GetLow(), (float)item.GetOpen(), (float)item.GetClose()));
                var dataSet = new MikePhil.Charting.Data.CandleDataSet(entryOriginal.ToArray(), itemChild.IF_GetLabel());
                OnIntializeDataSetCandle(itemChild, dataSet);
                listDataSetItems.Add(dataSet);
            }

            var data = new MikePhil.Charting.Data.CandleData(listDataSetItems.ToArray());
            return data;
        }

        private void OnIntializeDataSetCandle(ICandleStickDataSet source, MikePhil.Charting.Data.CandleDataSet original)
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
                original.IncreasingPaintStyle = ConvertPaintStyle(source.IF_GetIncreasingPaintStyle().Value);

            if (source.IF_GetDecreasingPaintStyle().HasValue)
                original.DecreasingPaintStyle = ConvertPaintStyle(source.IF_GetDecreasingPaintStyle().Value);

            if (source.IF_GetNeutralColor().HasValue)
                original.NeutralColor = source.IF_GetNeutralColor().Value.ToAndroid();

            if (source.IF_GetDecreasingColor().HasValue)
                original.DecreasingColor = source.IF_GetDecreasingColor().Value.ToAndroid();

            if (source.IF_GetIncreasingColor().HasValue)
                original.IncreasingColor = source.IF_GetIncreasingColor().Value.ToAndroid();

            if (source.IF_GetShadowColor().HasValue)
                original.ShadowColor = source.IF_GetShadowColor().Value.ToAndroid();
        }

        private Android.Graphics.Paint.Style ConvertPaintStyle(PaintStyle source)
        {
            switch (source)
            {
                case PaintStyle.STROKE:
                    return Android.Graphics.Paint.Style.Stroke;
                case PaintStyle.FILL_AND_STROKE:
                    return Android.Graphics.Paint.Style.FillAndStroke;
                default:
                    return Android.Graphics.Paint.Style.Fill;
            }
        }




        /*
         * EXPORT SETTINGS
         */
        public void OnSettingsBaseDataSet<TEntry>(IBaseDataSetXF<TEntry> baseDataSetXF, MikePhil.Charting.Data.BaseDataSet originalBaseDataSet) where TEntry : Widget.Charts.Models.BaseEntry
        {
            /*
                 * Properties could not set
                 * IF_GetGradientColor
                 */
            if (baseDataSetXF.IF_GetColors() != null && baseDataSetXF.IF_GetColors().Count > 0)
            {
                originalBaseDataSet.SetColors(baseDataSetXF.IF_GetColors().Select(obj => obj.ToAndroid().ToArgb()).ToArray());
            }
            if (baseDataSetXF.IF_GetValueColors() != null && baseDataSetXF.IF_GetValueColors().Count > 0)
            {
                originalBaseDataSet.SetValueTextColors(baseDataSetXF.IF_GetValueColors().Select(obj => new Java.Lang.Integer(obj.ToAndroid().ToArgb())).ToList());
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
                originalBaseDataSet.SetDrawIcons(baseDataSetXF.IF_GetDrawIcons().Value);
            }
            if (baseDataSetXF.IF_GetDrawValues().HasValue)
            {
                originalBaseDataSet.SetDrawValues(baseDataSetXF.IF_GetDrawValues().Value);
            }
            if (baseDataSetXF.IF_GetValueFormatter() != null)
            {
                originalBaseDataSet.ValueFormatter = new DataSetValueFormatterExport(baseDataSetXF.IF_GetValueFormatter());
            }
            if (baseDataSetXF.IF_GetValueTextSize().HasValue)
            {
                originalBaseDataSet.ValueTextSize = (baseDataSetXF.IF_GetValueTextSize().Value);
            }
        }

        public void OnSettingsBarLineScatterCandleBubbleDataSet<TEntry>(IBarLineScatterCandleBubbleDataSetXF<TEntry> baseDataSetXF, MikePhil.Charting.Data.BarLineScatterCandleBubbleDataSet originalBaseDataSet) where TEntry : Widget.Charts.Models.BaseEntry
        {
            OnSettingsBaseDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetighLightColor().HasValue)
            {
                originalBaseDataSet.HighLightColor = baseDataSetXF.IF_GetighLightColor().Value.ToAndroid();
            }
        }

        public void OnSettingsLineScatterCandleRadarDataSet<TEntry>(ILineScatterCandleRadarDataSetXF<TEntry> baseDataSetXF, MikePhil.Charting.Data.LineScatterCandleRadarDataSet originalBaseDataSet) where TEntry : Widget.Charts.Models.BaseEntry
        {
            OnSettingsBarLineScatterCandleBubbleDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.SetDrawVerticalHighlightIndicator(baseDataSetXF.IF_GetDrawVerticalHighlightIndicator().Value);
            }
            if (baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().HasValue)
            {
                originalBaseDataSet.SetDrawHorizontalHighlightIndicator(baseDataSetXF.IF_GetDrawHorizontalHighlightIndicator().Value);
            }
            if (baseDataSetXF.IF_GetHighlightLineWidth().HasValue)
            {
                originalBaseDataSet.HighlightLineWidth = baseDataSetXF.IF_GetHighlightLineWidth().Value;
            }
        }

        public void OnSettingsLineRadarDataSet<TEntry>(ILineRadarDataSetXF<TEntry> baseDataSetXF, MikePhil.Charting.Data.LineRadarDataSet originalBaseDataSet) where TEntry : Widget.Charts.Models.BaseEntry
        {
            OnSettingsLineScatterCandleRadarDataSet(baseDataSetXF, originalBaseDataSet);

            if (baseDataSetXF.IF_GetFillColor().HasValue)
            {
                originalBaseDataSet.FillColor = baseDataSetXF.IF_GetFillColor().Value.ToAndroid();
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
                originalBaseDataSet.SetDrawFilled(baseDataSetXF.IF_GetDrawFilled().Value);
            }
        }

        private LineDataSet.Mode GetDrawLineMode(LineDataSetMode mode)
        {
            switch (mode)
            {
                case LineDataSetMode.CUBIC_BEZIER:
                    return LineDataSet.Mode.CubicBezier;
                case LineDataSetMode.CUBIC_HORIZONTAL:
                    return LineDataSet.Mode.HorizontalBezier;
                case LineDataSetMode.STEPPED:
                    return LineDataSet.Mode.Stepped;
                case LineDataSetMode.LINEAR:
                    return LineDataSet.Mode.Linear;
                default:
                    return LineDataSet.Mode.Linear;
            }
        }

        private XAxis.XAxisPosition GetXAxisPosition(XAXISPosition mode)
        {
            switch (mode)
            {
                case XAXISPosition.BOTTOM:
                    return XAxis.XAxisPosition.Bottom;
                case XAXISPosition.TOP:
                    return XAxis.XAxisPosition.Top;
                case XAXISPosition.BOTTOM_INSIDE:
                    return XAxis.XAxisPosition.BottomInside;
                case XAXISPosition.TOP_INSIDE:
                    return XAxis.XAxisPosition.TopInside;
                case XAXISPosition.BOTH:
                    return XAxis.XAxisPosition.BothSided;
                default:
                    return XAxis.XAxisPosition.Top;
            }
        }
    }
}
