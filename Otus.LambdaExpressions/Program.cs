namespace Otus.LambdaExpressions
{
    internal class Program
    {
        private static int _invokeCount = 0;

        static void Main(string[] args)
        {
            var catalog = new PlanetCatalog();

            ShowPlanet(catalog, "Земля");
            ShowPlanet(catalog, "Лимония");
            ShowPlanet(catalog, "Марс");
            ShowPlanet(catalog, "Плутон");
        }

        private static void ShowPlanet(PlanetCatalog catalog, string planetName)
        {
            _invokeCount++;
            var func = ValidatePlanet(planetName);
            var (orderNumber, equatorLenght, error) = catalog.GetPlanet(planetName, func);
            if (error != null)
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine($"Порядковый номер планеты = {orderNumber}, длина экватора = {equatorLenght}");
            }
        }

        private static Func<string, string?> ValidatePlanet(string name)
        {
            return validator =>
            {
                if (_invokeCount % 3 == 0)
                {
                    return "Вы спрашиваете слишком часто";
                }
                if (name == "Лимония")
                {
                    return "Это запретная планета";
                }
                return null;
            };
        }
    }
}
