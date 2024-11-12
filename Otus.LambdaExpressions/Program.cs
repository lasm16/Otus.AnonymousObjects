using System;
using System.Xml.Linq;

namespace Otus.LambdaExpressions
{
    internal class Program
    {
        private static int _invokeCount = 0;

        static void Main(string[] args)
        {
            var catalog = new PlanetCatalog();
            string[] planets = { "Земля", "Лимония", "Марс", "Плутон" };

            foreach (var planet in planets)
            {
                ShowPlanet(catalog, planet);
            }
        }

        private static void ShowPlanet(PlanetCatalog catalog, string planetName)
        {
            _invokeCount++;
            var (orderNumber, equatorLenght, error) = catalog.GetPlanet(planetName, x =>
            {
                if (_invokeCount % 3 == 0)
                {
                    return "Вы спрашиваете слишком часто";
                }
                return null;
            });

            var (orderNumber1, equatorLenght1, error1) = catalog.GetPlanet(planetName, x =>
            {
                if (planetName == "Лимония")
                {
                    return "Это запретная планета";
                }
                return null;
            });
            if (error != null && error1 != null)
            {
                Console.WriteLine(error1);
            }
            else if (error != null)
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine($"Порядковый номер планеты = {orderNumber}, длина экватора = {equatorLenght}");
            }
        }
    }
}
