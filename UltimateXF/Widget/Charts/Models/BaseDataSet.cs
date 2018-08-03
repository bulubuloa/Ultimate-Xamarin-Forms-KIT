using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models
{
    public class BaseDataSet<TEntry> : IBaseDataSet<TEntry>  where TEntry : BaseEntry
    {
        protected List<TEntry> EntryItems { set; get; }
        protected string Title { set; get; }

        public Color DataColor { set; private get; }
        public LineDataSetMode DrawMode { set; private get; }

        public float CircleRadius { set; private get; }
        public float CircleHoleRadius { set; private get; }
        public bool DrawCircle { set; private get; }
        public bool DrawValue { set; private get; }

        public List<Color> CircleColors { set; private get; }
        public Color CircleColor { set; private get; }

        public BaseDataSet(List<TEntry> _EntryItems,string _Title)
        {
            EntryItems = _EntryItems;
            Title = _Title;
            DataColor = Color.Black;
            DrawMode = LineDataSetMode.STEPPED;
            CircleRadius = 3f;
            CircleHoleRadius = 3f;
            DrawCircle = true;
            DrawValue = true;
            CircleColors = new List<Color>();
            CircleColor = Color.Black;
        }

        public List<TEntry> IF_GetEntry()
        {
            return EntryItems;
        }

        public string IF_GetTitle()
        {
            return Title;
        }

        public Color IF_GetDataColor()
        {
            return DataColor;
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

        public bool IF_GetDrawValue()
        {
            return DrawValue;
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

    public interface IBaseDataSet<TEntry>
    {
        List<TEntry> IF_GetEntry();
        string IF_GetTitle();
        Color IF_GetDataColor();
        LineDataSetMode IF_GetDrawMode();
        float IF_GetCircleRadius();
        float IF_GetCircleHoleRadius();
        bool IF_GetDrawCircle();
        bool IF_GetDrawValue();
        List<Color> IF_GetCircleColors();
        Color IF_GetCircleColor();
    }
}