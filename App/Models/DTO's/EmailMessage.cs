using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace Models.DTO_s
{
    public class EmailMessage
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage(IEnumerable<EmailAdress> to, string subject, string content)
        {
            this.To = new List<MailboxAddress>();

            this.To.AddRange(to.Select(x => new MailboxAddress(x.UserName, x.Adress)));
            this.Subject = subject;
            this.Content = content;
        }
    }
}
