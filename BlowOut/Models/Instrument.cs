using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }
        public String Price { get; set; }
        public int ClientID { get; set; }
    }
}