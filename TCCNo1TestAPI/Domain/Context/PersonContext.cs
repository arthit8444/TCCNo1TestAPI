using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TCCNo1TestAPI.Domain.Entities;

namespace TCCNo1TestAPI.Domain.Context;

public partial class PersonContext : DbContext
{
    public PersonContext()
    {
    }

    public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=person.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("NVARCHAR(300)")
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Birthday)
                .HasColumnType("DATETIME")
                .HasColumnName("birthday");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValue("system")
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("datetime('now')")
                .HasColumnType("DATETIME")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("DATETIME")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
