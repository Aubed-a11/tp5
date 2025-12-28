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
            Console.WriteLine("Email envoyé : " + message);
        }
    }

    public class SMSNotificationService : INotificationService
    {
        public void Envoyer(string message)
        {
            Console.WriteLine("SMS envoyé : " + message);
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
            Console.WriteLine("Notification App");
            INotificationService emailService = new EmailNotificationService();
            Utilisateur userEmail = new Utilisateur(emailService);
            Console.WriteLine(" Envoi via Email");
            userEmail.EnvoyerNotification("Bienvenue !");
            INotificationService smsService = new SMSNotificationService();
            Utilisateur userSMS = new Utilisateur(smsService);
            Console.WriteLine(" Envoi via SMS ");
            userSMS.EnvoyerNotification("Bienvenue !");
        }
    }
}


