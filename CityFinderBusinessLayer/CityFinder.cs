using CityFinderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityFinderBusinessLayer
{
    public class CityFinder : ICityFinder
    {
        private List<string> _cities = new List<string>();

        public CityFinder()
        {
            _cities = CityRepository.CachedCities.Cities();
        }

        public ICityResult Search(string searchString)
        {
            var nextCities = new List<string>();
            var nextLetters = new List<string>();

            var cityResult = new CityResult() { NextCities = nextCities, NextLetters = nextLetters };

            if (string.IsNullOrWhiteSpace(searchString))
            {
                return cityResult;
            }

            searchString = searchString.Trim();

            List<string> matchingCities = FindMatchingCitiesStartingWithInput(searchString);

            if (matchingCities != null && matchingCities.Count > 0)
            {
                cityResult.NextCities = matchingCities;

                var nextCharactersList = FindNextCharacter(matchingCities, searchString);

                if (nextCharactersList != null && nextCharactersList.Count > 0)
                {
                    cityResult.NextLetters = nextCharactersList;
                }

            }

            return cityResult;
        }

        private List<string> FindMatchingCitiesStartingWithInput(string searchString)
        {
            return _cities.Where(x => x.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase)).Select(y => y).Distinct().OrderBy(z => z).ToList();
        }

        private List<string> FindNextCharacter(List<string> matches, string searchTerm)
        {
            var charList = new List<string>();
            foreach (var match in matches)
            {
                if (searchTerm.Length >= match.Length)
                {
                    continue;
                }
                charList.Add(match.Substring(searchTerm.Length, 1));

            }
            return charList.Distinct().OrderBy(c => c).ToList();
        }
    }
}
