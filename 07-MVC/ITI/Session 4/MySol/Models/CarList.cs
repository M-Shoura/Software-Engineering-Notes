namespace MySol.Models
{
    public class CarList
    {
        public static List<Car> Cars = new List<Car>() { new Car() { Num = 1, Color = "Red", Manfacture = "Toyota", Model = "Corolla" },
                                                         new Car() { Num = 2, Color = "Blue", Manfacture = "BMW", Model = "520i" },
                                                         new Car() { Num = 3, Color = "Green", Manfacture = "GMC", Model = "Denali" }
        };
    }
}
