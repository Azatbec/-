using System;

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    // Order only stores data, no logic for calculation, payment or email
}

public class PriceCalculator
{
    public double CalculateTotalPrice(Order order)
    {
        // Рассчет стоимости с учетом скидок
        return order.Quantity * order.Price * 0.9;
    }
}

public class PaymentProcessor
{
    public void ProcessPayment(Order order, string paymentDetails)
    {
        // Логика обработки платежа
        Console.WriteLine($"Payment for {order.ProductName} processed using: {paymentDetails}");
    }
}

public class EmailService
{
    public void SendConfirmationEmail(Order order, string email)
    {
        // Логика отправки уведомления
        Console.WriteLine($"Confirmation email for {order.ProductName} sent to: {email}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Order order = new Order { ProductName = "Laptop", Quantity = 1, Price = 1000 };

        PriceCalculator priceCalculator = new PriceCalculator();
        double totalPrice = priceCalculator.CalculateTotalPrice(order);
        Console.WriteLine($"Total price: {totalPrice}");

        PaymentProcessor paymentProcessor = new PaymentProcessor();
        paymentProcessor.ProcessPayment(order, "Credit Card");

        EmailService emailService = new EmailService();
        emailService.SendConfirmationEmail(order, "customer@example.com");
    }
}
