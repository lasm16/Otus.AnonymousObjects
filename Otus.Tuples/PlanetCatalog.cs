namespace Otus.Tuples
{
    internal class PlanetCatalog
    {
        private List<Planet> _planets = [];
        private int _invokeCount = 0;

        public PlanetCatalog()
        {
            Initialize();
        }

        public (int orderNumber, int equatorLenght, string? error) GetPlanet(string name)
        {
            _invokeCount++;
            var planet = FindPlanet(name);
            if (_invokeCount % 3 == 0)
            {
                return (0, 0, "Вы спрашиваете слишком часто");
            }
            if (planet == null)
            {
                return (0, 0, "Не удалось найти планету");
            }
            return (planet.OrderNumber, planet.EquatorLenght, null);
        }
        private Planet? FindPlanet(string name) => _planets.Find(x => x.Name == name);

        private void Initialize()
        {
            var venus = new Planet("Венера", 2, 38025);
            var earth = new Planet("Земля", 3, 40075);
            var mars = new Planet("Марс", 4, 21344);
            _planets.AddRange([venus, earth, mars]);
        }
    }
}
