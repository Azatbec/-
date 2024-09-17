using System;

public interface IPrinter
{
    void Print(string content);
}

public interface IScanner
{
    void Scan(string content);
}

public interface IFax
{
    void Fax(string content);
}
public class AllInOnePrinter : IPrinter, IScanner, IFax
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }

    public void Fax(string content)
    {
        Console.WriteLine("Faxing: " + content);
    }
}
public class BasicPrinter : IPrinter
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }
}
public class PrinterWithScanner : IPrinter, IScanner
{
    public void Print(string content)
    {
        Console.WriteLine("Printing: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Scanning: " + content);
    }
}
public class Program3
{
    public static void Main(string[] args)
    {
        // Базовый принтер, поддерживает только печать
        IPrinter basicPrinter = new BasicPrinter();
        basicPrinter.Print("Basic Printer Document");

        // Многофункциональный принтер, поддерживает печать, сканирование и факс
        AllInOnePrinter allInOnePrinter = new AllInOnePrinter();
        allInOnePrinter.Print("All-In-One Printer Document");
        allInOnePrinter.Scan("All-In-One Printer Document");
        allInOnePrinter.Fax("All-In-One Printer Document");

        // Принтер со сканером, поддерживает только печать и сканирование
        PrinterWithScanner printerWithScanner = new PrinterWithScanner();
        printerWithScanner.Print("Printer With Scanner Document");
        printerWithScanner.Scan("Printer With Scanner Document");
    }
}
