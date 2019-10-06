using FluentEmail.Core;
using System.Text;
using Umbraco.Core.Composing;

namespace NKN.Core.Services
{
    public class EmailComposer : IDiscoverable
    {
        private const string SenderEmailAddress = "test.nkn.test@gmail.com";
        private const string ReceiverName = "NKN";
        private const string Subject = "Contact us";

        public IFluentEmail ComposeEmail(Models.ContactUsModel model)
        {
            var emailBodyBuilder = new StringBuilder()
                .Append("Kontaktirao/la nas je ")
                .Append(model.FullName)
                .Append(", njegova/njena imejl adresa je ")
                .Append(model.Email)
                .Append(" sa porukom:")
                .AppendLine()
                .Append(model.Message);

            return Email
                .From(SenderEmailAddress)
                .To(SenderEmailAddress, ReceiverName)
                .Subject(Subject)
                .Body(emailBodyBuilder.ToString());
        }
    }
}