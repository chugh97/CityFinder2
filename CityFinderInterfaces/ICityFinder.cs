﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityFinderInterfaces
{
    public interface ICityFinder
    {
        ICityResult Search(string searchString);
    }
}
