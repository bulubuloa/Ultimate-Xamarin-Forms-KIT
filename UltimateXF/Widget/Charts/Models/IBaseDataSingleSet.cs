using System;
using System.Collections.Generic;

namespace UltimateXF.Widget.Charts.Models
{
    public interface IBaseDataSingleSet<TEntry,TInterface> where TEntry : BaseEntry where TInterface : IBaseDataSet<TEntry> 
    {
        TInterface IF_GetDataSet();
        List<string> IF_GetTitleSet();
    }
}