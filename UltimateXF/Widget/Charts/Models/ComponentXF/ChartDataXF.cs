using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.ComponentXF;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class ChartDataXF<TDataSet,TEntry> : BaseDataXF where TDataSet : IDataSetXF<TEntry> where TEntry : BaseEntry
    {
        private List<string> _Titles;
        public List<string> Titles
        {
            get => _Titles;
            set
            {
                _Titles = value;
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

        private float? _LeftAxisMax;
        public float? LeftAxisMax
        {
            get => _LeftAxisMax;
            set
            {
                _LeftAxisMax = value;
                OnPropertyChanged();
            }
        }

        private float? _LeftAxisMin;
        public float? LeftAxisMin
        {
            get => _LeftAxisMin;
            set
            {
                _LeftAxisMin = value;
                OnPropertyChanged();
            }
        }

        private float? _RightAxisMax;
        public float? RightAxisMax
        {
            get => _RightAxisMax;
            set
            {
                _RightAxisMax = value;
                OnPropertyChanged();
            }
        }

        private float? _RightAxisMin;
        public float? RightAxisMin
        {
            get => _RightAxisMin;
            set
            {
                _RightAxisMin = value;
                OnPropertyChanged();
            }
        }

        private List<TDataSet> _DataSets;
        public List<TDataSet> DataSets
        {
            get => _DataSets;
            set
            {
                _DataSets = value;
                OnPropertyChanged();
            }
        }

        public ChartDataXF(TDataSet dataSet, List<string> _Titles)
        {
            DataSets = new List<TDataSet>()
            {
                dataSet
            };
            Titles = _Titles;
        }

        public ChartDataXF(List<TDataSet> dataSet,List<string> _Titles)
        {
            DataSets = dataSet;
            Titles = _Titles;
        } 
    }
}