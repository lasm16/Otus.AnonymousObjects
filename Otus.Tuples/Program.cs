﻿namespace Otus.Tuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var catalog = new PlanetCatalog();
            ShowPlanet(catalog, "Земля");
            ShowPlanet(catalog, "Лимония");
            ShowPlanet(catalog, "Марс");
        }

        private static void ShowPlanet(PlanetCatalog catalog, string planetName)
        {
            var (orderNumber, equatorLenght, error) = catalog.GetPlanet(planetName);
            if (error != null)
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
