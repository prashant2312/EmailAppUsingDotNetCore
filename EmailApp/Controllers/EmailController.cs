using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmailService _email;
        public EmailController(IEmailService service)
        {
            _email= service;
        }
        [HttpPost]
        public async Task<IActionResult> SentEmail(EmailDTO body)
        {
            _email.SendEmail(body);
            return Ok();

        }
    }
}
