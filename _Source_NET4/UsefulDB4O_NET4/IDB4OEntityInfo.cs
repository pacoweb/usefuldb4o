using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsefulDB4O
{
    public enum FillDB4OMode
    {
        JustGlobalID = 0,
        JustLocalID,
        JustVersion,
        All
    }

    public interface IDB4OEntityInfo
    {
        string GlobalID { get; set; }
        long   LocalID  { get; set; }
        long   Version  { get; set; }
    }
}
