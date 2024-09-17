using System;
using System.Collections.Generic;
using System.Linq;

public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle(string brand, string model, int year)
    {
        Brand = brand;
        Model = model;
        Year = year;
    }

    public virtual void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Запуск мотора .");
    }

    public virtual void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Остановка мотора.");
    }
}
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public string TransmissionType { get; set; }

    public Car(string brand, string model, int year, int numberOfDoors, string transmissionType)
        : base(brand, model, year)
    {
        NumberOfDoors = numberOfDoors;
        TransmissionType = transmissionType;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Запуск мотора автомобиля.");
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Остановка мотора автомобиля.");
    }
}

public class Motorcycle : Vehicle
{
    public string BodyType { get; set; }
    public bool HasStorageBox { get; set; }

    public Motorcycle(string brand, string model, int year, string bodyType, bool hasStorageBox)
        : base(brand, model, year)
    {
        BodyType = bodyType;
        HasStorageBox = hasStorageBox;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Двигатель мотоцикла завелся.");
    }

    public override void StopEngine()
    {
        Console.WriteLine($"{Brand} {Model}: Двигатель мотоцикла закглох.");
    }
}
public class Garage
{
    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
        Console.WriteLine($"{vehicle.Brand} {vehicle.Model} добавлен в гараж.");
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
        Console.WriteLine($"{vehicle.Brand} {vehicle.Model} вывезен из гаража.");
    }
}
public class Fleet
{
    public List<Garage> Garages { get; set; } = new List<Garage>();

    public void AddGarage(Garage garage)
    {
        Garages.Add(garage);
        Console.WriteLine("К автопарку добавлен гараж.");
    }

    public void RemoveGarage(Garage garage)
    {
        Garages.Remove(garage);
        Console.WriteLine("Гараж выведен из автопарка.");
    }

    public Vehicle FindVehicle(string brand, string model)
    {
        foreach (var garage in Garages)
        {
            var vehicle = garage.Vehicles.FirstOrDefault(v => v.Brand == brand && v.Model == model);
            if (vehicle != null)
            {
                return vehicle;
            }
        }
        return null;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        // Ввод данных для автомобиля
        Console.WriteLine("Введите данные для автомобиля:");
        Console.Write("Марка: ");
        string carBrand = Console.ReadLine();

        Console.Write("Модель: ");
        string carModel = Console.ReadLine();

        Console.Write("Год выпуска: ");
        int carYear = int.Parse(Console.ReadLine());

        Console.Write("Количество дверей: ");
        int carDoors = int.Parse(Console.ReadLine());

        Console.Write("Тип трансмиссии: ");
        string carTransmission = Console.ReadLine();

        Car car1 = new Car(carBrand, carModel, carYear, carDoors, carTransmission);

        // Ввод данных для мотоцикла
        Console.WriteLine("\nВведите данные для мотоцикла:");
        Console.Write("Марка: ");
        string motoBrand = Console.ReadLine();

        Console.Write("Модель: ");
        string motoModel = Console.ReadLine();

        Console.Write("Год выпуска: ");
        int motoYear = int.Parse(Console.ReadLine());

        Console.Write("Тип кузова: ");
        string motoBodyType = Console.ReadLine();

        Console.Write("Есть ли багажник (введите true или false): ");
        bool hasStorageBox = bool.Parse(Console.ReadLine());

        Motorcycle moto1 = new Motorcycle(motoBrand, motoModel, motoYear, motoBodyType, hasStorageBox);

        // Создаем гараж и добавляем транспортные средства
        Garage garage1 = new Garage();
        garage1.AddVehicle(car1);
        garage1.AddVehicle(moto1);

        // Создаем автопарк и добавляем гараж
        Fleet fleet = new Fleet();
        fleet.AddGarage(garage1);

        // Тестируем поиск и удаление транспортных средств
        Console.Write("\nВведите марку транспортного средства для поиска: ");
        string searchBrand = Console.ReadLine();

        Console.Write("Введите модель транспортного средства для поиска: ");
        string searchModel = Console.ReadLine();

        Vehicle foundVehicle = fleet.FindVehicle(searchBrand, searchModel);
        if (foundVehicle != null)
        {
            Console.WriteLine($"Найдено транспортное средство: {foundVehicle.Brand} {foundVehicle.Model}");
        }
        else
        {
            Console.WriteLine("Транспортное средство не найдено.");
        }

        // Удаление транспортного средства
        Console.WriteLine("\nУдаление автомобиля из гаража.");
        garage1.RemoveVehicle(car1);

        Console.ReadKey();
    }

}

