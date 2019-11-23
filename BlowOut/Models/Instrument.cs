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

        [Display(Name ="Instrument Name")]
        public String Description { get; set; }

        [Display(Name = "New or Used")]
        public String Type { get; set; }

        [Display(Name = "Price")]
        public String Price { get; set; }

        
        public int? ClientID { get; set; }
    }
}