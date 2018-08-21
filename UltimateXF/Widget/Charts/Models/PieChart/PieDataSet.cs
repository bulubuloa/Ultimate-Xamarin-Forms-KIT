using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.PieChart
{
    public enum ValuePosition
    {
        INSIDE_SLICE,
        OUTSIDE_SLICE
    }

    public class PieDataSet : BaseDataSetXF<PieEntry>, IPieDataSet
    {
        public PieDataSet(List<PieEntry> entries, string _label) : base(entries, _label)
        {
        }

        private float? _SliceSpace;
        public float? SliceSpace
        {
            get => _SliceSpace;
            set
            {
                _SliceSpace = value;
                OnPropertyChanged();
            }
        }

        private bool? _AutomaticallyDisableSliceSpacing;
        public bool? AutomaticallyDisableSliceSpacing
        {
            get => _AutomaticallyDisableSliceSpacing;
            set
            {
                _AutomaticallyDisableSliceSpacing = value;
                OnPropertyChanged();
            }
        }

        private float? _Shift;
        public float? Shift
        {
            get => _Shift;
            set
            {
                _Shift = value;
                OnPropertyChanged();
            }
        }

        private ValuePosition? _XValuePosition;
        public ValuePosition? XValuePosition
        {
            get => _XValuePosition;
            set
            {
                _XValuePosition = value;
                OnPropertyChanged();
            }
        }

        private ValuePosition? _YValuePosition;
        public ValuePosition? YValuePosition
        {
            get => _YValuePosition;
            set
            {
                _YValuePosition = value;
                OnPropertyChanged();
            }
        }

        private bool? _UsingSliceColorAsValueLineColor;
        public bool? UsingSliceColorAsValueLineColor
        {
            get => _UsingSliceColorAsValueLineColor;
            set
            {
                _UsingSliceColorAsValueLineColor = value;
                OnPropertyChanged();
            }
        }

        private Color? _ValueLineColor;
        public Color? ValueLineColor
        {
            get => _ValueLineColor;
            set
            {
                _ValueLineColor = value;
                OnPropertyChanged();
            }
        }

        private float? _ValueLineWidth;
        public float? ValueLineWidth
        {
            get => _ValueLineWidth;
            set
            {
                _ValueLineWidth = value;
                OnPropertyChanged();
            }
        }

        private float? _ValueLinePart1OffsetPercentage;
        public float? ValueLinePart1OffsetPercentage
        {
            get => _ValueLinePart1OffsetPercentage;
            set
            {
                _ValueLinePart1OffsetPercentage = value;
                OnPropertyChanged();
            }
        }
        private float? _ValueLinePart1Length;
        public float? ValueLinePart1Length
        {
            get => _ValueLinePart1Length;
            set
            {
                _ValueLinePart1Length = value;
                OnPropertyChanged();
            }
        }

        private float? _ValueLinePart2Length;
        public float? ValueLinePart2Length
        {
            get => _ValueLinePart2Length;
            set
            {
                _ValueLinePart2Length = value;
                OnPropertyChanged();
            }
        }

        private bool? _ValueLineVariableLength;
        public bool? ValueLineVariableLength
        {
            get => _ValueLineVariableLength;
            set
            {
                _ValueLineVariableLength = value;
                OnPropertyChanged();
            }
        }

        public float? IF_GetXMax()
        {
            
            throw new NotImplementedException();
        }

        public float? IF_GetXMin()
        {
            throw new NotImplementedException();
        }

        public float? IF_GetYMax()
        {
            throw new NotImplementedException();
        }

        public float? IF_GetYMin()
        {
            throw new NotImplementedException();
        }

        public float? IF_GetSliceSpace()
        {
            return SliceSpace;
        }

        public bool? IF_GetAutomaticallyDisableSliceSpacing()
        {
            return AutomaticallyDisableSliceSpacing;
        }

        public float? IF_GetShift()
        {
            return Shift;
        }

        public ValuePosition? IF_GetXValuePosition()
        {
            return XValuePosition;
        }

        public ValuePosition? IF_GetYValuePosition()
        {
            return YValuePosition;
        }

        public bool? IF_GetUsingSliceColorAsValueLineColor()
        {
            return UsingSliceColorAsValueLineColor;
        }

        public Color? IF_GetValueLineColor()
        {
            return ValueLineColor;
        }

        public float? IF_GetValueLineWidth()
        {
            return ValueLineWidth;
        }

        public float? IF_GetValueLinePart1OffsetPercentage()
        {
            return ValueLinePart1OffsetPercentage;
        }

        public float? IF_GetValueLinePart1Length()
        {
            return ValueLinePart1Length;
        }

        public float? IF_GetValueLinePart2Length()
        {
            return ValueLinePart2Length;
        }

        public bool? IF_GetValueLineVariableLength()
        {
            return ValueLineVariableLength;
        }
    }
}