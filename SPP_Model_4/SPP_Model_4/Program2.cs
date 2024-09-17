using System;

public abstract class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public Employee(string name, double baseSalary)
    {
        Name = name;
        BaseSalary = baseSalary;
    }

    // Абстрактный метод для расчета зарплаты
    public abstract double CalculateSalary();
}

public class PermanentEmployee : Employee
{
    public PermanentEmployee(string name, double baseSalary)
        : base(name, baseSalary)
    {
    }

    public override double CalculateSalary()
    {
        return BaseSalary * 1.2; // Постоянный сотрудник получает 20% бонус
    }
}

public class ContractEmployee : Employee
{
    public ContractEmployee(string name, double baseSalary)
        : base(name, baseSalary)
    {
    }

    public override double CalculateSalary()
    {
        return BaseSalary * 1.1; // Контрактный сотрудник получает 10% бонус
    }
}

public class InternEmployee : Employee
{
    public InternEmployee(string name, double baseSalary)
        : base(name, baseSalary)
    {
    }

    public override double CalculateSalary()
    {
        return BaseSalary * 0.8; // Стажер получает 80% от базовой зарплаты
    }
}

public class FreelancerEmployee : Employee
{
    public FreelancerEmployee(string name, double baseSalary)
        : base(name, baseSalary)
    {
    }

    public override double CalculateSalary()
    {
        return BaseSalary * 1.15; // Фрилансер получает 15% бонус
    }
}

public class Program2
{
    public static void Main(string[] args)
    {
        Employee permanent = new PermanentEmployee("John", 1000);
        Employee contract = new ContractEmployee("Jane", 1000);
        Employee intern = new InternEmployee("Doe", 1000);
        Employee freelancer = new FreelancerEmployee("Alice", 1000);

        Console.WriteLine($"{permanent.Name} salary: {permanent.CalculateSalary()}");
        Console.WriteLine($"{contract.Name} salary: {contract.CalculateSalary()}");
        Console.WriteLine($"{intern.Name} salary: {intern.CalculateSalary()}");
        Console.WriteLine($"{freelancer.Name} salary: {freelancer.CalculateSalary()}");
    }
}
