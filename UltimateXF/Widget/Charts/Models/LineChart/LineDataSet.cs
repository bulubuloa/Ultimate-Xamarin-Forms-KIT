using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.LineChart
{
    public class LineDataSet : BaseDataSet<EntryChart>, ILineDataSet
    {
        public LineDataSetMode DrawMode { set; private get; }
        public float CircleRadius { set; private get; }
        public float CircleHoleRadius { set; private get; }
        public bool DrawCircle { set; private get; }
        public List<Color> CircleColors { set; private get; }
        public Color CircleColor { set; private get; }

        public LineDataSet(List<EntryChart> _EntryItems, string _Title) : base(_EntryItems,_Title)
        {
            DrawMode = LineDataSetMode.STEPPED;
            CircleRadius = 3f;
            CircleHoleRadius = 3f;
            DrawCircle = true;
            CircleColors = new List<Color>();
            CircleColor = Color.Black;
        }

        public LineDataSetMode IF_GetDrawMode()
        {
            return DrawMode;
        }

        public float IF_GetCircleRadius()
        {
            return CircleRadius;
        }

        public float IF_GetCircleHoleRadius()
        {
            return CircleHoleRadius;
        }

        public bool IF_GetDrawCircle()
        {
            return DrawCircle;
        }

        public List<Color> IF_GetCircleColors()
        {
            return CircleColors;
        }

        public Color IF_GetCircleColor()
        {
            return CircleColor;
        }
    }
}