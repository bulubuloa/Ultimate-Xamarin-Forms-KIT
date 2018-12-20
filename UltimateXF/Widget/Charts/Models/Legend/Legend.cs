using System;
using UltimateXF.Widget.Charts.Models.Component;

namespace UltimateXF.Widget.Charts.Models.Legend
{
    public enum LegendForm
    {
        NONE,EMPTY,DEFAULT,SQUARE,CIRCLE,LINE
    }

    public enum LegendHorizontalAlignment
    {
        LEFT, CENTER, RIGHT
    }

    public enum LegendVerticalAlignment
    {
        TOP, CENTER, BOTTOM
    }

    public enum LegendOrientation
    {
        HORIZONTAL, VERTICAL
    }

    public enum LegendDirection
    {
        LEFT_TO_RIGHT, RIGHT_TO_LEFT
    }


    public class LegendXF : ConfigBase
    {
        private LegendHorizontalAlignment? _LegendHorizontalAlignment;
        public LegendHorizontalAlignment? LegendHorizontalAlignment
        {
            get => _LegendHorizontalAlignment;
            set
            {
                _LegendHorizontalAlignment = value;
                OnPropertyChanged();
            }
        }

        private LegendVerticalAlignment? _LegendVerticalAlignment;
        public LegendVerticalAlignment? LegendVerticalAlignment
        {
            get => _LegendVerticalAlignment;
            set
            {
                _LegendVerticalAlignment = value;
                OnPropertyChanged();
            }
        }

        private LegendOrientation? _LegendOrientation;
        public LegendOrientation? LegendOrientation
        {
            get => _LegendOrientation;
            set
            {
                _LegendOrientation = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawInsideEnabled;
        public bool? DrawInsideEnabled
        {
            get => _DrawInsideEnabled;
            set
            {
                _DrawInsideEnabled = value;
                OnPropertyChanged();
            }
        }

        private LegendDirection? _LegendDirection;
        public LegendDirection? LegendDirection
        {
            get => _LegendDirection;
            set
            {
                _LegendDirection = value;
                OnPropertyChanged();
            }
        }

        private LegendForm? _LegendForm;
        public LegendForm? LegendForm
        {
            get => _LegendForm;
            set
            {
                _LegendForm = value;
                OnPropertyChanged();
            }
        }

        private float? _FormSize;
        public float? FormSize
        {
            get => _FormSize;
            set
            {
                _FormSize = value;
                OnPropertyChanged();
            }
        }

        private float? _FormLineWidth;
        public float? FormLineWidth
        {
            get => _FormLineWidth;
            set
            {
                _FormLineWidth = value;
                OnPropertyChanged();
            }
        }

        //private float? _FormLineDashEffect;
        //public float? FormLineDashEffect
        //{
        //    get => _FormLineDashEffect;
        //    set
        //    {
        //        _FormLineDashEffect = value;
        //        OnPropertyChanged();
        //    }
        //}

        private float? _XEntrySpace;
        public float? XEntrySpace
        {
            get => _XEntrySpace;
            set
            {
                _XEntrySpace = value;
                OnPropertyChanged();
            }
        }

        private float? _YEntrySpace;
        public float? YEntrySpace
        {
            get => _YEntrySpace;
            set
            {
                _YEntrySpace = value;
                OnPropertyChanged();
            }
        }

        private float? _FormToTextSpace;
        public float? FormToTextSpace
        {
            get => _FormToTextSpace;
            set
            {
                _FormToTextSpace = value;
                OnPropertyChanged();
            }
        }

        private float? _StackSpace;
        public float? StackSpace
        {
            get => _StackSpace;
            set
            {
                _StackSpace = value;
                OnPropertyChanged();
            }
        }

        private bool? _WordWrapEnabled;
        public bool? WordWrapEnabled
        {
            get => _WordWrapEnabled;
            set
            {
                _WordWrapEnabled = value;
                OnPropertyChanged();
            }
        }

        private float? _MaxSizePercent;
        public float? MaxSizePercent
        {
            get => _MaxSizePercent;
            set
            {
                _MaxSizePercent = value;
                OnPropertyChanged();
            }
        }

        private float? _NeededWidth;
        public float? NeededWidth
        {
            get => _NeededWidth;
            set
            {
                _NeededWidth = value;
                OnPropertyChanged();
            }
        }

        private float? _NeededHeight;
        public float? NeededHeight
        {
            get => _NeededHeight;
            set
            {
                _NeededHeight = value;
                OnPropertyChanged();
            }
        }

        private float? _TextHeightMax;
        public float? TextHeightMax
        {
            get => _TextHeightMax;
            set
            {
                _TextHeightMax = value;
                OnPropertyChanged();
            }
        }

        private float? _TextWidthMax;
        public float? TextWidthMax
        {
            get => _TextWidthMax;
            set
            {
                _TextWidthMax = value;
                OnPropertyChanged();
            }
        }

        public LegendXF()
        {
        }
    }
}
