﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class FileEncryptArgs : EventArgs
    {
        public DataFile DataFile { get; set; }
    }
}
