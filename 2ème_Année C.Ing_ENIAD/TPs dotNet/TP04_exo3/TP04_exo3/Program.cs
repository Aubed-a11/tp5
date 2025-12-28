using System;

namespace NotificationApp
{
 
    public interface INotificationService
    {
        void Envoyer(string message);
    }


    public class EmailNotificationService : INotificationService
    {
        public void Envoyer(string message)
        {
            Console.WriteLine($"📧 Email envoyé : {message}");
        }
    }

    public class SMSNotificationService : INotificationService
    {
        public void Envoyer(string message)
        {
            Console.WriteLine($"📱 SMS envoyé : {message}");
        }
    }
    public class Utilisateur
    {
        private readonly INotificationService _notificationService;
        public Utilisateur(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public void EnvoyerNotification(string message)
        {
            _notificationService.Envoyer(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application de notification");

            INotificationService emailService = new EmailNotificationService();
            Utilisateur user1 = new Utilisateur(emailService);
            user1.EnvoyerNotification("Bienvenue !");

            Console.WriteLine();

            INotificationService smsService = new SMSNotificationService();
            Utilisateur user2 = new Utilisateur(smsService);
            user2.EnvoyerNotification("Bienvenue !");
        }
    }
}
