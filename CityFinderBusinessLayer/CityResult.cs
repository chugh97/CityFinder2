using CityFinderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityFinderBusinessLayer
{
    public class CityResult : ICityResult
    {
        public CityResult()
        {

        }

        public ICollection<string> NextLetters { get; set; }

        public ICollection<string> NextCities { get; set; }
    }
}
