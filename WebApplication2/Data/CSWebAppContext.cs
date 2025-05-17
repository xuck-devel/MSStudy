using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSWebApp.Models;

namespace CSWebApp.Data
{
    public class CSWebAppContext : DbContext
    {
        public CSWebAppContext (DbContextOptions<CSWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CSWebApp.Models.dbo_Table_3> dbo_Table_3 { get; set; } = default!;
    }
}
