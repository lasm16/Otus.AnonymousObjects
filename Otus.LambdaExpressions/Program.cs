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
                var validator = ValidateInvokeCount();
                ShowPlanet(catalog, planet, validator);
            }

            Console.WriteLine(new string('-', 50));

            foreach (var planet in planets)
            {
                var validator = ValidateForbiddenPlanet(planet);
                ShowPlanet(catalog, planet, validator);
            }
        }

        private static void ShowPlanet(PlanetCatalog catalog, string planetName, Func<string, string?> validator)
        {
            _invokeCount++;
            var (orderNumber, equatorLenght, error) = catalog.GetPlanet(planetName, validator);
            if (error != null)
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine($"Порядковый номер планеты = {orderNumber}, длина экватора = {equatorLenght}");
            }
        }

        private static Func<string, string?> ValidateInvokeCount() => validator =>
        {
            if (_invokeCount % 3 == 0)
            {
                return "Вы спрашиваете слишком часто";
            }
            return null;
        };

        private static Func<string, string?> ValidateForbiddenPlanet(string name) => validator =>
        {
            if (name == "Лимония")
            {
                return "Это запретная планета";
            }
            return null;
        };
    }
}
