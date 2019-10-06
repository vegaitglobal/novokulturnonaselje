using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Smtp;
using NKN.Common;
using System.Net;
using System.Net.Mail;
using Umbraco.Core.Composing;

namespace NKN.Core.Services
{
    public class EmailSender : IDiscoverable
    {
        public void Init()
        {
            NetworkCredential networkCredential = new NetworkCredential(AppSettings.SmtpUsername, AppSettings.SmtpPassword);
            SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = networkCredential,
                Port = 587
            };

            Email.DefaultSender = new SmtpSender(smtpClient);
        }

        public SendResponse Send(IFluentEmail email) => email.Send();
    }
}