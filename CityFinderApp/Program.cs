using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityFinderInterfaces;
using CityFinderBusinessLayer;

namespace CityFinderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ICityFinder cityFinder = new CityFinder();
                ICityResult results1 = cityFinder.Search("BANG");

                ICityResult results2 = cityFinder.Search("LA");

                ICityResult results3 = cityFinder.Search("ZE");

                Dump(results1, "BANG");
                Dump(results2, "LA");
                Dump(results3, "ZE");

            }
            catch (Exception)
            {

                Console.WriteLine("Sorry an error occurred");
            }

            Console.ReadKey();
        }

        private static void Dump(ICityResult results, string testCase)
        {
            Console.WriteLine(string.Format("=========RESULT SET '{0}'==========", testCase));

            if (results.NextCities.Count > 0)
            {
                Console.WriteLine(string.Format("Matched Cities = {0}", String.Join<string>(",", new List<string>(results.NextCities))));
            }
            else
            {
                Console.WriteLine("No matching cities found");
            }

            if (results.NextLetters.Count > 0)
            {
                var renderingList = new List<string>();
                foreach (var item in results.NextLetters)
                {
                    if (item == " ")
                    {
                        renderingList.Add("' '"); //just for rendering in UI Console app to show white shape like ' '
                    }
                    else
                    {
                        renderingList.Add(item);
                    }
                }
                Console.WriteLine(string.Format("Matched Next Letter = {0}", String.Join<string>(",", renderingList)));
            }
            else
            {
                Console.WriteLine("No matching next letter found");
            }
            Console.WriteLine("=========END OF RESULT SET ===========");
            Console.WriteLine("");
        }
    }
}
