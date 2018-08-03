using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models
{
    public interface IBaseData<TEntry, TInterface> where TEntry : BaseEntry where TInterface : IBaseDataSet<TEntry>
    {
        List<TInterface> IF_GetDataSet();
        List<string> IF_GetTitleSet();
    }
}