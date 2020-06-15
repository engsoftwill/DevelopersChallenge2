using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SRC.Model
{
    public class ofx
    {   
        public int TRNTYPE { get; set; }
        public string DTPOSTED { get; set; }
        public string TRNAMT { get; set; }
        public int MEMO { get; set; }
    }
}
