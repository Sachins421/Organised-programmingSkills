using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class File
    {
        public static void Main(string[] args)
        {
            var dataFile = new DataFile();
            dataFile.Title = "Azure portal password";
            var encryptFile = new EncryptFile();

            var mailService = new MailService();
            var comp = new CompletedMsgs();

            encryptFile.EncryptedFile += mailService.EncryptedFile;
            encryptFile.EncryptedFile += comp.EncryptedFile;

            encryptFile.Encrypt(dataFile);

            Console.ReadLine();

        }
    }
}
