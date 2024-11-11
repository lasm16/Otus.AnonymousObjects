namespace Otus.AnonymousObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SolveProgram1();
        }

        private static void SolveProgram1()
        {
            var venus = new
            {
                Name = "Венера",
                OrderNumber = 2,
                EquatorLenght = 38025,
                PreviousPlanet = "Меркурий"
            };

            var earth = new
            {
                Name = "Земля",
                OrderNumber = 3,
                EquatorLenght = 40075,
                PreviousPlanet = "Венера"
            };

            var mars = new
            {
                Name = "Марс",
                OrderNumber = 4,
                EquatorLenght = 21344,
                PreviousPlanet = "Земля"
            };

            var venus2 = new
            {
                Name = "Венера",
                OrderNumber = 2,
                EquatorLenght = 38025,
                PreviousPlanet = "Меркурий"
            };


            Console.WriteLine(venus);

            Console.WriteLine(earth);
            Console.WriteLine(earth.Equals(venus));

            Console.WriteLine(mars);
            Console.WriteLine(mars.Equals(venus));

            Console.WriteLine(venus2);
            Console.WriteLine(venus2.Equals(venus));
        }
    }
}
