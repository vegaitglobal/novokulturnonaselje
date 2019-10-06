using NKN.Core.Extensions;
using NKN.Core.Models;
using NKN.Core.Services;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace NKN.Core.Controllers.Api
{
    public class FormsController : UmbracoApiController
    {
        private readonly EmailComposer _emailComposer;
        private readonly EmailSender _emailSender;

        public FormsController(EmailComposer emailComposer, EmailSender emailSender)
        {
            _emailComposer = emailComposer;
            _emailSender = emailSender;
        }

        [HttpPost]
        public IHttpActionResult ContactUs([FromBody] ContactUsModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not valid request");

            var email = _emailComposer.ComposeEmail(model);
            var sendResponse = _emailSender.Send(email);

            if (!sendResponse.Successful)
                return InternalServerError(sendResponse.ToException());

            return Ok();
        }
    }
}