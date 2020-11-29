using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Backend.Model
{
    public class MailRequest
    {
        /*private string toEmail;
        private string subject;
        private string body;

        public MailRequest(string toEmail, string subject, string body)
        {
            this.toEmail = toEmail;
            this.subject = subject;
            this.body = body;
        }*/

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public List<IFormFile> Attachments { get; set; }

    }
}
