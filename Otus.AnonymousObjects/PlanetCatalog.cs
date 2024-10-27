namespace Otus.AnonymousObjects
{
    internal class PlanetCatalog
    {
        public List<Planet> Planets = [];
        private int _invokeCount = 0;

        public PlanetCatalog()
        {
            Initialize();
        }

        public (int orderNumber, int equatorLenght, string error) GetPlanet(string name)
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
            return (planet.OrderNumber, planet.EquatorLenght, string.Empty);
        }

        public (int orderNumber, int equatorLenght, string error) GetPlanet(string name, Func<string, string> validator)
        {
            var error = validator(name);
            if (!error.Equals(string.Empty))
            {
                return (0, 0, error);
            }
            var planet = FindPlanet(name);
            return (planet!.OrderNumber, planet.EquatorLenght, string.Empty);
        }

        public string PlanetValidator(string name)
        {
            var planet = FindPlanet(name);
            if (planet == null)
            {
                return "Не удалось найти планету";
            }
            return string.Empty;
        }

        private Planet? FindPlanet(string name) => Planets.Find(x => x.Name == name);

        private void Initialize()
        {
            // не очень красиво
            var venus = new Planet("Венера", 2, 38025, null);
            var earth = new Planet("Земля", 3, 40075, venus);
            var mars = new Planet("Марс", 4, 21344, earth);
            Planets.Add(venus);
            Planets.Add(earth);
            Planets.Add(mars);
        }
    }
}
