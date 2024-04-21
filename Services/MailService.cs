using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MailService
    {
        public void Send(MailMessage message)
        {
        // Sender's email address and password
        string senderEmail = "your_email@example.com";
        string senderPassword = "your_password";

        // Recipient's email address
        string recipientEmail = "recipient@example.com";

        // Create an instance of the MailMessage class
        MailMessage mail = new MailMessage(senderEmail, recipientEmail);

        // Set the subject and body of the email
        mail.Subject = "Test Email";
        mail.Body = "This is a test email sent from a .NET application.";

        // Create an instance of the SmtpClient class
        SmtpClient smtpClient = new SmtpClient("smtp.example.com");

        // Set the port and credentials
        smtpClient.Port = 587; // Port for SMTP (usually 587 or 465)
        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        smtpClient.EnableSsl = true; // Enable SSL/TLS

        try
        {
            // Send the email
            smtpClient.Send(mail);
            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to send email: " + ex.Message);
        }
        finally
        {
        // Clean up resources
        mail.Dispose();
        smtpClient.Dispose();
        }
        }
    }
}
