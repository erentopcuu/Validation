using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Validation.DMO;

public partial class PersonelContext : DbContext
{
    public PersonelContext()
    {
    }

    public PersonelContext(DbContextOptions<PersonelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    //Database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Server=EREXT\\SQLEXPRESS; Database=Personel; Trusted_Connection= true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.IdentityNo).HasMaxLength(11);
            entity.Property(e => e.LastName).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
