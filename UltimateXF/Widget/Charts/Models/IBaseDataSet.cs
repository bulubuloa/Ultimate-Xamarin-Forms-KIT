using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models
{
    public interface IBaseDataSet<TEntry>
    {
        List<TEntry> IF_GetEntry();
        string IF_GetTitle();
        Color IF_GetDataColor();
        bool IF_GetDrawValue();
    }
}