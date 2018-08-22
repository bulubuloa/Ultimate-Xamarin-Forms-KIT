using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.BarChart
{
    public class BarDataSet : BarLineScatterCandleBubbleDataSetXF<EntryChart>, IBarDataSet
    {
        private int? _StackSize;
        public int? StackSize
        {
            get => _StackSize;
            set
            {
                _StackSize = value;
                OnPropertyChanged();
            }
        }

        private Color? _BarShadowColor;
        public Color? BarShadowColor
        {
            get => _BarShadowColor;
            set
            {
                _BarShadowColor = value;
                OnPropertyChanged();
            }
        }

        private float? _BarBorderWidth;
        public float? BarBorderWidth
        {
            get => _BarBorderWidth;
            set
            {
                _BarBorderWidth = value;
                OnPropertyChanged();
            }
        }

        private Color? _BarBorderColor;
        public Color? BarBorderColor
        {
            get => _BarBorderColor;
            set
            {
                _BarBorderColor = value;
                OnPropertyChanged();
            }
        }

        private int? _HighLightAlpha;
        public int? HighLightAlpha
        {
            get => _HighLightAlpha;
            set
            {
                _HighLightAlpha = value;
                OnPropertyChanged();
            }
        }

        private int? _EntryCountStacks;
        public int? EntryCountStacks
        {
            get => _EntryCountStacks;
            set
            {
                _EntryCountStacks = value;
                OnPropertyChanged();
            }
        }

        private List<string> _StackLabels;
        public List<string> StackLabels
        {
            get => _StackLabels;
            set
            {
                _StackLabels = value;
                OnPropertyChanged();
            }
        }

        public BarDataSet(List<EntryChart> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
            
        }

        public int? IF_GetStackSize()
        {
            return StackSize;
        }

        public Color? IF_GetBarShadowColor()
        {
            return BarShadowColor;
        }

        public float? IF_GetBarBorderWidth()
        {
            return BarBorderWidth;
        }

        public Color? IF_GetBarBorderColor()
        {
            return BarBorderColor;
        }

        public int? IF_GetHighLightAlpha()
        {
            return HighLightAlpha;
        }

        public int? IF_GetEntryCountStacks()
        {
            return EntryCountStacks;
        }

        public List<string> IF_GetStackLabels()
        {
            return StackLabels;
        }
    }
}