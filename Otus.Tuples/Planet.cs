namespace Otus.Tuples
{
    internal class Planet(string name, int orderNumber, int equatorLenght)
    {
        public string? Name { get; set; } = name;
        public int OrderNumber { get; set; } = orderNumber;
        public int EquatorLenght { get; set; } = equatorLenght;
    }
}
