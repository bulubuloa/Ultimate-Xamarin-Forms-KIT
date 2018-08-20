using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.ScatterChart
{
    public class ScatterDataSet : LineScatterCandleRadarDataSetXF<EntryChart>, IScatterDataSet
    {
        private float? _ShapeSize;
        public float? ShapeSize
        {
            get => _ShapeSize;
            set
            {
                _ShapeSize = value;
                OnPropertyChanged();
            }
        }

        //private IShapeRenderer _ShapeRenderer;

        private float? _ScatterShapeHoleRadius;
        public float? ScatterShapeHoleRadius
        {
            get => _ScatterShapeHoleRadius;
            set
            {
                _ScatterShapeHoleRadius = value;
                OnPropertyChanged();
            }
        }

        private Color? _ScatterShapeHoleColor;
        public Color? ScatterShapeHoleColor
        {
            get => _ScatterShapeHoleColor;
            set
            {
                _ScatterShapeHoleColor = value;
                OnPropertyChanged();
            }
        }

        public ScatterDataSet(List<EntryChart> _EntryItems, string _Title) : base(_EntryItems, _Title)
        {
        }

        public float? IF_GetShapeSize()
        {
            return ShapeSize;
        }

        public float? IF_GetScatterShapeHoleRadius()
        {
            return ScatterShapeHoleRadius;
        }

        public Color? IF_GetScatterShapeHoleColor()
        {
            return ScatterShapeHoleColor;
        }
    }
}