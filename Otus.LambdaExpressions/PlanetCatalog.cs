namespace Otus.LambdaExpressions
{
    internal class PlanetCatalog
    {
        private List<Planet> _planets = [];

        public PlanetCatalog()
        {
            Initialize();
        }

        public (int orderNumber, int equatorLenght, string? error) GetPlanet(string name, Func<string, string?> validator)
        {
            var result = validator(name);
            if (result != null)
            {
                return (0, 0, result);
            }
            var planet = FindPlanet(name);
            if (planet == null)
            {
                return (0, 0, "Не удалось найти планету");
            }
            return (planet.OrderNumber, planet.EquatorLenght, null);
        }

        private Planet? FindPlanet(string name) => _planets.Find(x => x.Name == name);

        private void Initialize()
        {
            var venus = new Planet("Венера", 2, 38025, null);
            var earth = new Planet("Земля", 3, 40075, venus);
            var mars = new Planet("Марс", 4, 21344, earth);
            _planets.AddRange([venus, earth, mars]);
        }
    }
}
