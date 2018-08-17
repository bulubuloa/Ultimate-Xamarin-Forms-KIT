using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class DataSetXF<TEntry> : BaseDataSetXF<TEntry>,IDataSetXF<TEntry> where TEntry : BaseEntry
    {
        private List<TEntry> _Values;
        public List<TEntry> Values
        {
            get => _Values;
            set
            {
                _Values = value;
                OnPropertyChanged();
            }
        }

        private float? _YMax;
        public float? YMax
        {
            get => _YMax;
            set
            {
                _YMax = value;
                OnPropertyChanged();
            }
        }

        private float? _YMin;
        public float? YMin
        {
            get => _YMin;
            set
            {
                _YMin = value;
                OnPropertyChanged();
            }
        }

        private float? _XMax;
        public float? XMax
        {
            get => _XMax;
            set
            {
                _XMax = value;
                OnPropertyChanged();
            }
        }

        private float? _XMin;
        public float? XMin
        {
            get => _XMin;
            set
            {
                _XMin = value;
                OnPropertyChanged();
            }
        }

        public DataSetXF(List<TEntry> values, String label)
        {
            Values = values;
            Label = label;
        }

        public List<TEntry> IF_GetValues()
        {
            return Values;
        }

        public float? IF_GetYMax()
        {
            return YMax;
        }

        public float? IF_GetYMin()
        {
            return YMin;
        }

        public float? IF_GetXMax()
        {
            return XMax;
        }

        public float? IF_GetXMin()
        {
            return XMin;
        }
    }
}