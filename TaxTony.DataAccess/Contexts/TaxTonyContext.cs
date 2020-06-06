using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaxTony.DataAccess.Entities;

namespace TaxTony.DataAccess.Contexts
{
    public class TaxTonyContext : DbContext
    {
        public TaxTonyContext() : base(){}

        public TaxTonyContext(DbContextOptions options): base(options){}


        public virtual DbSet<TaxCalculation> TaxCalculations { get; set; }
    }
}
