﻿
namespace EmailApp.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
