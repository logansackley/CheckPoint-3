using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class Instrument
    {
        [Required]
        public int InstrumentID { get; set; }
        public string InstrumentName { get; set; }
        public int NewPrice { get; set; }
        public int OldPrice { get; set; }
    }
}