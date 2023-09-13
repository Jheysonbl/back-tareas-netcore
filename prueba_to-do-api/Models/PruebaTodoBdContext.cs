using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba_to_do_api.Models;

public partial class PruebaTodoBdContext : DbContext
{
    public PruebaTodoBdContext()
    {
    }

    public PruebaTodoBdContext(DbContextOptions<PruebaTodoBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASW3187\\SQLEXPRESS01;Database=PRUEBA_TODO_BD;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("TASK");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.IdTask)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_TASK");
            entity.Property(e => e.IsCompleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("IS_COMPLETED");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("IS_DELETED");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Task1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TASK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
