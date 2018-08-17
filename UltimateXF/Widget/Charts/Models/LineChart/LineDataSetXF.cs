using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.LineChart
{
    public class LineDataSetXF : LineRadarDataSetXF<EntryChart>,ILineDataSetXF
    {
        /*
         * 
         *  private DashPathEffect mDashPathEffect = null;
         *  private IFillFormatter mFillFormatter = new DefaultFillFormatter();
         */
        private LineDataSetMode? _Mode;
        public LineDataSetMode? Mode
        {
            get => _Mode;
            set
            {
                _Mode = value;
                OnPropertyChanged();
            }
        }

        private List<Color> _CircleColors;
        public List<Color> CircleColors
        {
            get => _CircleColors;
            set
            {
                _CircleColors = value;
                OnPropertyChanged();
            }
        }

        private Color? _CircleHoleColor;
        public Color? CircleHoleColor
        {
            get => _CircleHoleColor;
            set
            {
                _CircleHoleColor = value;
                OnPropertyChanged();
            }
        }

        private float? _CircleRadius;
        public float? CircleRadius
        {
            get => _CircleRadius;
            set
            {
                _CircleRadius = value;
                OnPropertyChanged();
            }
        }

        private float? _CircleHoleRadius;
        public float? CircleHoleRadius
        {
            get => _CircleHoleRadius;
            set
            {
                _CircleHoleRadius = value;
                OnPropertyChanged();
            }
        }

        private float? _CubicIntensity;
        public float? CubicIntensity
        {
            get => _CubicIntensity;
            set
            {
                _CubicIntensity = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawCircles;
        public bool? DrawCircles
        {
            get => _DrawCircles;
            set
            {
                _DrawCircles = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawCircleHole;
        public bool? DrawCircleHole
        {
            get => _DrawCircleHole;
            set
            {
                _DrawCircleHole = value;
                OnPropertyChanged();
            }
        }

        public LineDataSetXF(List<EntryChart> values, string label) : base(values, label)
        {
            
        }

        public LineDataSetMode? IF_GetMode()
        {
            return Mode;
        }

        public List<Color> IF_GetCircleColors()
        {
            return CircleColors;
        }

        public Color? IF_GetCircleHoleColor()
        {
            return CircleHoleColor;
        }

        public float? IF_GetCircleRadius()
        {
            return CircleRadius;
        }

        public float? IF_GetCircleHoleRadius()
        {
            return CircleHoleRadius;
        }

        public float? IF_GetCubicIntensity()
        {
            return CubicIntensity;
        }

        public bool? IF_GetDrawCircles()
        {
            return DrawCircles;
        }

        public bool? IF_GetDrawCircleHole()
        {
            return DrawCircleHole;
        }
    }
}