
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spp_Model4_Laba2
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public string Position { get; set; }

        public Employee(string name, int employeeId, string position)
        {
            Name = name;
            EmployeeId = employeeId;
            Position = position;
        }

       
        public abstract double CalculateSalary();
    }

    
    public class Worker : Employee
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        public Worker(string name, int employeeId, string position, double hourlyRate, int hoursWorked)
            : base(name, employeeId, position)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Переопределенный метод для расчета зарплаты
        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }

    // Класс Менеджер (Manager)
    public class Manager : Employee
    {
        public double FixedSalary { get; set; }
        public double Bonus { get; set; }

        public Manager(string name, int employeeId, string position, double fixedSalary, double bonus)
            : base(name, employeeId, position)
        {
            FixedSalary = fixedSalary;
            Bonus = bonus;
        }

        // Переопределенный метод для расчета зарплаты
        public override double CalculateSalary()
        {
            return FixedSalary + Bonus;
        }
    }

   
    public class EmployeeSystem
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            Console.WriteLine($"Сотрудник {employee.Name} добавлен в систему.");
        }

        public void DisplaySalaries()
        {
            foreach (var employee in Employees)
            {
                Console.WriteLine($"Сотрудник: {employee.Name}, Должность: {employee.Position}, Зарплата: {employee.CalculateSalary()}");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаем систему учета сотрудников
            EmployeeSystem employeeSystem = new EmployeeSystem();

            // Ввод данных для сотрудников
            Console.Write("Сколько сотрудников вы хотите добавить? ");
            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                Console.WriteLine($"\nВведите данные для сотрудника {i + 1}:");

                Console.Write("Введите имя: ");
                string name = Console.ReadLine();

                Console.Write("Введите идентификатор сотрудника: ");
                int employeeId = int.Parse(Console.ReadLine());

                Console.Write("Введите должность (Рабочий или Менеджер): ");
                string position = Console.ReadLine();

                if (position.ToLower() == "рабочий")
                {
                    Console.Write("Введите ставку за час: ");
                    double hourlyRate = double.Parse(Console.ReadLine());

                    Console.Write("Введите количество отработанных часов: ");
                    int hoursWorked = int.Parse(Console.ReadLine());

                    // Создаем объект Worker
                    Worker worker = new Worker(name, employeeId, "Рабочий", hourlyRate, hoursWorked);
                    employeeSystem.AddEmployee(worker);
                }
                else if (position.ToLower() == "менеджер")
                {
                    Console.Write("Введите фиксированную зарплату: ");
                    double fixedSalary = double.Parse(Console.ReadLine());

                    Console.Write("Введите премию: ");
                    double bonus = double.Parse(Console.ReadLine());

                    // Создаем объект Manager
                    Manager manager = new Manager(name, employeeId, "Менеджер", fixedSalary, bonus);
                    employeeSystem.AddEmployee(manager);
                }
                else
                {
                    Console.WriteLine("Неверная должность. Повторите ввод.");
                    i--; 
                }
            }

            
            Console.WriteLine("\nЗарплаты сотрудников:");
            employeeSystem.DisplaySalaries();

            Console.ReadKey();
        }
    }


}
