using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvileOccupationdata
{
    // This is used to sort the ABV beer 
    public class AbvComparer : IComparer<Beer>
    {
        public int Compare(Beer x, Beer y)
        {
            return x.Abv.CompareTo(y.Abv) * -1;
        }
    }
}
