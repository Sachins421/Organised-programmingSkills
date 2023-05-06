using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class EncryptFile
    {
        // 1 - Define a delegate
        // 2 - Define an event based on delegate
        // 3 - Raise the event


        /*
        public delegate void EncryptFileEventHandler(object source, FileEncryptArgs e);

        public event EncryptFileEventHandler EncryptedFile;
        */ // Old way to define Delegate and event handler 


        public event EventHandler<FileEncryptArgs> EncryptedFile; // recommended way to define event and delegate together

        public void Encrypt(DataFile dataFile) 
        {
            Console.WriteLine("File is encrypting...");
            Thread.Sleep(3000);

            OnEncryptedFile(dataFile);
        }

        protected virtual void OnEncryptedFile(DataFile dataFile) 
        { 
            if (EncryptedFile != null)
                EncryptedFile(this, new FileEncryptArgs { DataFile = dataFile });
           
        
        }
    }
}
