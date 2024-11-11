namespace Otus.Delegates
{
    internal class Program
    {
        private static int _invokeCount = 0;

        delegate bool IsDevideBy3(int number);
        delegate bool IsCorrectPlanetName(string name);

        static void Main(string[] args)
        {
            var catalog = new PlanetCatalog();

            bool isDevided(int x) => x % 3 == 0;
            bool correctPlanetName(string x) => !x.Equals("Лимония");
            string[] planets = { "Земля", "Лимония", "Марс", "Плутон" };

            foreach (var planet in planets)
            {
                ShowPlanet(catalog, planet, correctPlanetName, isDevided);
            }
        }

        private static void ShowPlanet(PlanetCatalog catalog, string planetName, IsCorrectPlanetName correctPlanetName, IsDevideBy3 devidedBy3)
        {
            _invokeCount++;
            if (devidedBy3(_invokeCount))
            {
                Console.WriteLine("Вы спрашиваете слишком часто");
                return;
            }
            if (!correctPlanetName(planetName))
            {
                Console.WriteLine("Это запретная планета");
                return;
            }

            // не нравится такой вызов валидатора
            var (orderNumber, equatorLenght, error) = catalog.GetPlanet(planetName, catalog.PlanetValidator);
            if (!error.Equals(string.Empty))
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
