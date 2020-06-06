using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxTony.DataAccess.Contexts
{
    public class TaxTonyContext : DbContext
    {
        public TaxTonyContext() : base(){}

        public TaxTonyContext(DbContextOptions options): base(options){}


    }
}
