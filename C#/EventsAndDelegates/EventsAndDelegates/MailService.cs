using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class MailService
    {
        public void EncryptedFile(Object source, FileEncryptArgs e)
        {
            Console.WriteLine("MailService : Mail is sending...{0}",e.DataFile.Title);
        }
    }
}
