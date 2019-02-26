using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsNameComparer : IComparer<clsWork>
    {
        public int Compare(clsWork x, clsWork y)
        {
     
            string lcNameX = x.GetName();
            string lcNameY = y.GetName();

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
