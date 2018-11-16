using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouisvileOccupationdata
{
    class BeerSearch : ISearch
    {

        string beerName = Console.ReadLine();
        public string BeerName { get => beerName; }
    }


}
