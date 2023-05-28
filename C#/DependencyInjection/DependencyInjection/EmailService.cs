using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    /*
     * In the above example, we have an IEmailService interface that defines the contract for sending emails. 
     * The EmailService class is an implementation of this interface.

     The NotificationService class depends on the IEmailService interface and receives it through its constructor. 
     This is an example of constructor injection. The SendNotification method in NotificationService uses the injected IEmailService instance to send a notification email.

     In the Main method, we create an instance of EmailService and pass it to the NotificationService constructor. 
     This way, the NotificationService has access to a concrete implementation of the IEmailService interface.
     * 
     * 
     */
    public class EmailService : IEmailService
    {
        public void SendEmail(string recepient, string subject, string body) 
        {
            Console.WriteLine($"Email is sending to {recepient} : {subject} : {body}");
        }
    }

    public class Notification
    {
        public IEmailService _emailService { get; set; }

        //public Notification(IEmailService emailService) // this is for costructor injection, commenting this code to implement property injection 
        //{
        //    _emailService = emailService;
        //}

        public void setNotification(IEmailService emailService) // method injection
        {
            _emailService = emailService;
        }
        

        public void SendNotification(string receipient, string body)
        {
            _emailService.SendEmail(receipient, "Notification", body);
        }
    }
}
