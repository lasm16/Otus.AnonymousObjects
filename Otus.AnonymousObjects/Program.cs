namespace Otus.AnonymousObjects
{
    internal class Program
    {
        private static int _invokeCount = 0;
        static void Main(string[] args)
        {
            SolveProgram1();
            Console.WriteLine(new string('-', 30));
            SolveProgram2();
            Console.WriteLine(new string('-', 30));
            SolveProgram3();
        }

        private static void SolveProgram1()
        {
            var venus = new
            {
                Name = "Венера",
                OrderNumber = 2,
                EquatorLenght = 38025,
            };

            var earth = new
            {
                Name = "Земля",
                OrderNumber = 3,
                EquatorLenght = 40075,
                PreviousPlanet = venus
            };

            var mars = new
            {
                Name = "Марс",
                OrderNumber = 4,
                EquatorLenght = 21344,
                PreviousPlanet = earth
            };

            var venus2 = new
            {
                Name = "Венера",
                OrderNumber = 2,
                EquatorLenght = 38025,
                PreviousPlanet = mars
            };


            Console.WriteLine(venus);
            Console.WriteLine(venus.EquatorLenght.Equals(venus.EquatorLenght));

            Console.WriteLine(earth);
            Console.WriteLine(earth.EquatorLenght.Equals(venus.EquatorLenght));

            Console.WriteLine(mars);
            Console.WriteLine(mars.EquatorLenght.Equals(venus.EquatorLenght));

            Console.WriteLine(venus2);
            Console.WriteLine(venus2.EquatorLenght.Equals(venus.EquatorLenght));
        }

        private static void SolveProgram2()
        {
            var catalog = new PlanetCatalog();
            ShowPlanet(catalog, "Земля");
            ShowPlanet(catalog, "Лимония");
            ShowPlanet(catalog, "Марс");
        }

        private static void ShowPlanet(PlanetCatalog catalog, string planetName)
        {
            var (orderNumber, equatorLenght, error) = catalog.GetPlanet(planetName);
            if (!error.Equals(string.Empty))
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine($"Порядковый номер планеты = {orderNumber}, длина экватора = {equatorLenght}");
            }
        }

        private static void SolveProgram3()
        {
            var catalog = new PlanetCatalog();

            bool isDevided(int x) => x % 3 == 0;
            bool correctPlanetName(string x) => !x.Equals("Лимония");

            ShowPlanet(catalog, "Земля", correctPlanetName, isDevided);
            ShowPlanet(catalog, "Лимония", correctPlanetName, isDevided);
            ShowPlanet(catalog, "Марс", correctPlanetName, isDevided);
            ShowPlanet(catalog, "Плутон", correctPlanetName, isDevided);
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


        delegate bool IsDevideBy3(int number);
        delegate bool IsCorrectPlanetName(string name);
    }
}
