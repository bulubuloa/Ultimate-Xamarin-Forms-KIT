using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.BubbleChart
{
    public class BubbleDataSet : BarLineScatterCandleBubbleDataSetXF<BubbleEntry>, IBubbleDataSet
    {
        private float? _MaxSize;
        public float? MaxSize
        {
            get => _MaxSize;
            set
            {
                _MaxSize = value;
                OnPropertyChanged();
            }
        }

        private bool? _NormalizeSize;
        public bool? NormalizeSize
        {
            get => _NormalizeSize;
            set
            {
                _NormalizeSize = value;
                OnPropertyChanged();
            }
        }

        private float? _HighlightCircleWidth;
        public float? HighlightCircleWidth
        {
            get => _HighlightCircleWidth;
            set
            {
                _HighlightCircleWidth = value;
                OnPropertyChanged();
            }
        }

        public BubbleDataSet(List<BubbleEntry> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }

        public float? IF_GetMaxSize()
        {
            return MaxSize;
        }

        public bool? IF_GetNormalizeSize()
        {
            return NormalizeSize;
        }

        public float? IF_GetHighlightCircleWidth()
        {
            return HighlightCircleWidth;
        }
    }
}