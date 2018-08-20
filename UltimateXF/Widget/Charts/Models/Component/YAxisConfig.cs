using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public class YAxisConfig : AxisConfigBase
    {
        private bool? _Inverted;
        public bool? Inverted
        {
            get => _Inverted;
            set
            {
                _Inverted = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawZeroLine;
        public bool? DrawZeroLine
        {
            get => _DrawZeroLine;
            set
            {
                _DrawZeroLine = value;
                OnPropertyChanged();
            }
        }

        private float? _SpacePercentTop;
        public float? SpacePercentTop
        {
            get => _SpacePercentTop;
            set
            {
                _SpacePercentTop = value;
                OnPropertyChanged();
            }
        }

        private float? _SpacePercentBottom;
        public float? SpacePercentBottom
        {
            get => _SpacePercentBottom;
            set
            {
                _SpacePercentBottom = value;
                OnPropertyChanged();
            }
        }

        private float? _MinWidth;
        public float? MinWidth
        {
            get => _MinWidth;
            set
            {
                _MinWidth = value;
                OnPropertyChanged();
            }
        }

        private float? _MaxWidth;
        public float? MaxWidth
        {
            get => _MaxWidth;
            set
            {
                _MaxWidth = value;
                OnPropertyChanged();
            }
        }

        private float? _ZeroLineWidth;
        public float? ZeroLineWidth
        {
            get => _ZeroLineWidth;
            set
            {
                _ZeroLineWidth = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawTopYLabelEntry;
        public bool? DrawTopYLabelEntry
        {
            get => _DrawTopYLabelEntry;
            set
            {
                _DrawTopYLabelEntry = value;
                OnPropertyChanged();
            }
        }

        private bool? _UseAutoScaleRestrictionMin;
        public bool? UseAutoScaleRestrictionMin
        {
            get => _UseAutoScaleRestrictionMin;
            set
            {
                _UseAutoScaleRestrictionMin = value;
                OnPropertyChanged();
            }
        }

        private bool? _UseAutoScaleRestrictionMax;
        public bool? UseAutoScaleRestrictionMax
        {
            get => _UseAutoScaleRestrictionMax;
            set
            {
                _UseAutoScaleRestrictionMax = value;
                OnPropertyChanged();
            }
        }

        private Color? _ZeroLineColor;
        public Color? ZeroLineColor
        {
            get => _ZeroLineColor;
            set
            {
                _ZeroLineColor = value;
                OnPropertyChanged();
            }
        }

        private YAXISLabelPosition? _YAXISLabelPosition;
        public YAXISLabelPosition? YAXISLabelPosition
        {
            get => _YAXISLabelPosition;
            set
            {
                _YAXISLabelPosition = value;
                OnPropertyChanged();
            }
        }

        private AXISDependency? _AxisDependency;
        public AXISDependency? AxisDependency
        {
            get => _AxisDependency;
            set
            {
                _AxisDependency = value;
                OnPropertyChanged();
            }
        }
    }
}