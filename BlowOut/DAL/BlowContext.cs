using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlowOut.Models;

namespace BlowOut.DAL
{
    public class BlowContext : DbContext
    {
        public BlowContext() : base("BlowContext")
        {

        }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Instrument> Instruments { get; set; }
    }
}
