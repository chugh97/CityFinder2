using System;
using System.Collections.Generic;
using CityFinderBusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CityFinderTests
{
    [TestClass]
    public class CityFinderUnitTests
    {
        [TestMethod]
        public void CityFinderTestsStartingWithInput_EmptyInput()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search(string.Empty);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count == 0);
            Assert.IsTrue(result.NextLetters.Count == 0);
        }

        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("BANG");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count > 0);
            Assert.IsTrue(result.NextCities.Count == 3); //doing this as we just limited data, do do when we have an integration test with an api or db
            Assert.IsTrue(result.NextCities.Contains("BANGALORE"));
            Assert.IsTrue(result.NextCities.Contains("BANGKOK"));
            Assert.IsTrue(result.NextCities.Contains("BANGUI"));
            Assert.IsTrue(result.NextLetters.Contains("A"));
            Assert.IsTrue(result.NextLetters.Contains("K"));
            Assert.IsTrue(result.NextLetters.Contains("U"));

            var nextLetterList = new List<string>(result.NextLetters);
            Assert.IsTrue(nextLetterList[0] == "A");
            Assert.IsTrue(nextLetterList[1] == "K");
            Assert.IsTrue(nextLetterList[2] == "U");

        }

        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered_LowerCase()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("bang");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count > 0);
            Assert.IsTrue(result.NextCities.Count == 3); //doing this as we just limited data, do do when we have an integration test with an api or db
            Assert.IsTrue(result.NextCities.Contains("BANGALORE"));
            Assert.IsTrue(result.NextCities.Contains("BANGKOK"));
            Assert.IsTrue(result.NextCities.Contains("BANGUI"));
            Assert.IsTrue(result.NextLetters.Contains("A"));
            Assert.IsTrue(result.NextLetters.Contains("K"));
            Assert.IsTrue(result.NextLetters.Contains("U"));
        }

        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered_MixedCase()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("Bang");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count > 0);
            Assert.IsTrue(result.NextCities.Count == 3); //doing this as we just limited data, do do when we have an integration test with an api or db
            Assert.IsTrue(result.NextCities.Contains("BANGALORE"));
            Assert.IsTrue(result.NextCities.Contains("BANGKOK"));
            Assert.IsTrue(result.NextCities.Contains("BANGUI"));
            Assert.IsTrue(result.NextLetters.Contains("A"));
            Assert.IsTrue(result.NextLetters.Contains("K"));
            Assert.IsTrue(result.NextLetters.Contains("U"));
        }

        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered_ScenarioB_StartsWith_LA()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("LA");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count > 0);
            Assert.IsTrue(result.NextCities.Count == 3); //doing this as we just limited data, do do when we have an integration test with an api or db
            Assert.IsTrue(result.NextLetters.Count > 0);
            Assert.IsTrue(result.NextLetters.Count == 2);

            Assert.IsTrue(result.NextCities.Contains("LA PAZ"));
            Assert.IsTrue(result.NextCities.Contains("LA PLATA"));
            Assert.IsTrue(result.NextCities.Contains("LAGOS"));
            Assert.IsTrue(result.NextLetters.Contains(" "));
            Assert.IsTrue(result.NextLetters.Contains("G"));

            var nextLetterList = new List<string>(result.NextLetters);
            Assert.IsTrue(nextLetterList[0] == " ");
            Assert.IsTrue(nextLetterList[1] == "G");

        }


        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered_ScenarioC_StartsWith_ZE()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("ZE");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count == 0);
            Assert.IsTrue(result.NextLetters.Count == 0);
        }

        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered_LongInput()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("BANGALOR");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count == 1);
            Assert.IsTrue(result.NextLetters.Count == 1);

        }


        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered_ExactMatch()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("BANGALORE");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count == 1);
            Assert.IsTrue(result.NextLetters.Count == 0);

        }

        [TestMethod]
        public void CityFinderTestsStartingWithInput_InputEntered_ExactMatch_With_Copy_AndHasWhiteSpace()
        {
            var cities = CityRepository.CachedCities.Cities();
            var cityFinder = new CityFinder();
            var result = cityFinder.Search("BANGALORE ");

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.NextCities);
            Assert.IsNotNull(result.NextLetters);
            Assert.IsTrue(result.NextCities.Count == 1);
            Assert.IsTrue(result.NextLetters.Count == 0);

        }
    }
}
