using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context;

public class SuscriptionDBContext : DbContext
{
    public SuscriptionDBContext()
    {

    }

    public SuscriptionDBContext(DbContextOptions<SuscriptionDBContext> options) : base(options) { }

    public DbSet<Destination> Destinations{ get; set; }





    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));  
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=70162057;Database=travelers;", serverVersion);
        }
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Destination>().ToTable("Destinations");
        builder.Entity<Destination>().HasKey(p => p.id); //PK
        builder.Entity<Destination>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Destination>().Property(p => p.name).IsRequired();
        builder.Entity<Destination>().Property(p => p.isRisky).IsRequired();
        builder.Entity<Destination>().Property(p => p.maxUser).IsRequired();







    }


}

