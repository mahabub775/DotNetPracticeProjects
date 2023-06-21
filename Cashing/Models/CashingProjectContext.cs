using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cashing.Models;

public partial class CashingProjectContext : DbContext
{
    public CashingProjectContext()
    {
    }

    public CashingProjectContext(DbContextOptions<CashingProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Mahabub; Database=DotNetPracticeProject; user Id=sa; Password=12774; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.JoinDate).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(30, 5)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasMaxLength(512);
            entity.Property(e => e.Password).HasMaxLength(512);
            entity.Property(e => e.Username).HasMaxLength(512);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
