using Umbraco.Core;
using Umbraco.Core.Composing;

namespace NKN.Core.Composers
{
    public class ServicesComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<Services.EmailComposer>();
            composition.Register(f =>
            {
                var emailSender = f.CreateInstance<Services.EmailSender>();
                emailSender.Init();
                return emailSender;
            });
        }
    }
}