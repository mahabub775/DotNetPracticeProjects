using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ORM_EntityFramework.Models;

public partial class DotNetPracticeProjectContext : DbContext
{
    public DotNetPracticeProjectContext()
    {
    }

    public DotNetPracticeProjectContext(DbContextOptions<DotNetPracticeProjectContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=Mahabub; Database=DotNetPracticeProject;user Id=sa; Password=12774;Trusted_Connection=True; TrustServerCertificate=True;");
        => optionsBuilder.UseSqlServer("Server=103.125.254.20,9433; Database=DotNetPracticeProject;user Id=mahabub775; Password=12774;TrustServerCertificate=True;");

   public virtual DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
