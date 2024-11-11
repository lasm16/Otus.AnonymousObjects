namespace Otus.LambdaExpressions
{
    internal class Planet(string name, int orderNumber, int equatorLenght, Planet? previousPlanet)
    {
        public string? Name { get; set; } = name;
        public int OrderNumber { get; set; } = orderNumber;
        public int EquatorLenght { get; set; } = equatorLenght;
        public Planet? PreviousPlanet { get; set; } = previousPlanet;
    }
}
