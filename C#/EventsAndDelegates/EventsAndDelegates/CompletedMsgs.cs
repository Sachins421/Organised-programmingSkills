using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class CompletedMsgs
    {
        public void EncryptedFile(Object source,FileEncryptArgs e)
        {
            Console.WriteLine("Transaction: File is Encrypted..");
        }
    }
}
