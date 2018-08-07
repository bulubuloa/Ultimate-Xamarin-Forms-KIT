using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.BarChart;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using UltimateXF.Widget.Charts.Models.LineChart;
using UltimateXF.Widget.Charts.Models.ScatterChart;

namespace UltimateXF.Widget.Charts.Models.CombinedChart
{
    public class CombinedChartData : BaseData<BaseEntry, IBaseDataSet<BaseEntry>>
    {
        public LineChartData LineChartData { set; private get; }
        public BarChartData BarChartData { set; private get; }
        public ScatterChartData ScatterChartData { set; private get; }
        public CandleStickChartData CandleStickChartData { set; private get; }
        public BubbleChartData BubbleChartData { set; private get; }

        public CombinedChartData(List<IBaseDataSet<BaseEntry>> _DataSetItems, List<string> _TitleItems) : base(_DataSetItems, _TitleItems)
        {
            
        }

        public BubbleChartData GetBubbleData()
        {
            return BubbleChartData;
        }

        public LineChartData GetLineData()
        {
            return LineChartData;
        }

        public BarChartData GetBarData()
        {
            return BarChartData;
        }

        public ScatterChartData GetScatterData()
        {
            return ScatterChartData;
        }

        public CandleStickChartData GetCandleData()
        {
            return CandleStickChartData;
        }
    }
}