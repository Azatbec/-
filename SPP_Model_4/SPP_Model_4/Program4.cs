using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_Model_4
{
    internal class Program4
    {
        public interface INotificationSender
        {
            void Send(string message);
        }
        public class EmailSender : INotificationSender
        {
            public void Send(string message)
            {
                Console.WriteLine("Email sent: " + message);
            }
        }

        public class SmsSender : INotificationSender
        {
            public void Send(string message)
            {
                Console.WriteLine("SMS sent: " + message);
            }
        }

        public class MessengerSender : INotificationSender
        {
            public void Send(string message)
            {
                Console.WriteLine("Message sent via Messenger: " + message);
            }
        }
        public class NotificationService
        {
            private readonly List<INotificationSender> _notificationSenders;

            public NotificationService(List<INotificationSender> notificationSenders)
            {
                _notificationSenders = notificationSenders;
            }

            public void SendNotification(string message)
            {
                foreach (var sender in _notificationSenders)
                {
                    sender.Send(message);
                }
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                // Создаем список отправщиков уведомлений
                List<INotificationSender> senders = new List<INotificationSender>
        {
            new EmailSender(),
            new SmsSender(),
            new MessengerSender()
        };

                // Передаем список в NotificationService
                NotificationService notificationService = new NotificationService(senders);
                notificationService.SendNotification("This is a test notification.");
            }
        }

    }
}
