using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShares2022.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options){}

        public virtual DbSet<RequestDocument> requestDocument { get; set; }
        public virtual DbSet<DataItem_Customer> dataItem_Customer { get; set; }
        public virtual DbSet<LoggingErrors> logErrors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestDocument>().HasKey(rd => new { rd.request_Document_Id });
            modelBuilder.Entity<DataItem_Customer>().HasKey(dic => new { dic.customer_id });
            modelBuilder.Entity<LoggingErrors>().HasKey(e => new { e.errorID });
        }

    }
}
