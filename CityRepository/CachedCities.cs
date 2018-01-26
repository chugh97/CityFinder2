using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityRepository
{
    public class CachedCities
    {
        private List<string> _cityList;
        private static CachedCities instance;

        private CachedCities()
        {
            _cityList = new List<string>();
            _cityList.Add("BANDUNG");
            _cityList.Add("BANGUI");
            _cityList.Add("BANGKOK");
            _cityList.Add("BANGALORE");
            _cityList.Add("LA PAZ");
            _cityList.Add("LA PLATA");
            _cityList.Add("LAGOS");
            _cityList.Add("LEEDS");
            _cityList.Add("ZARIA");
            _cityList.Add("ZHUGHAI");
            _cityList.Add("BANGKOK");
            _cityList.Add("ZIBO");
            instance = null;
        }

        public static List<string> Cities()
        {
            if (instance == null)
            {
                instance = new CachedCities();
            }

            return instance._cityList;
        }
    }
}

