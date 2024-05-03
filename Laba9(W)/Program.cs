
using static Car;

class Car
{
    public string Model { get; set; }
    public bool IsClean { get; set; }

    public Car(string model, bool isClean = true)
    {
        Model = model;
        IsClean = isClean;
    }
    public delegate void WashCarDelegate(Car car);
}

class Garage
{
    private List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public void WashAllCars(WashCarDelegate washMethod)
    {
        foreach (Car car in cars)
        {
            washMethod(car); // Вызов метода через делегат
        }
    }
}

class Washer
{
    public void Wash(Car car)
    {
        car.IsClean = true;
        Console.WriteLine($"Автомобиль {car.Model} помыт.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Mazda RX-7");
        Car car2 = new Car("Chevrolet Camaro", false); 

        Garage garage = new Garage();
        garage.AddCar(car1);
        garage.AddCar(car2);

        Washer washer = new Washer();

        // Создание делегата, ссылающегося на метод Wash
        WashCarDelegate washMethod = washer.Wash;

        garage.WashAllCars(washMethod); // Передача делегата в метод
    }
}
