using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Todo_DotNet_Backend.Models;

public partial class TasksDbContext : DbContext
{
    public TasksDbContext()
    {
    }

    public TasksDbContext(DbContextOptions<TasksDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Label>(entity =>
        {
            entity.HasKey(e => e.LabelId).HasName("Label_pk");

            entity.Property(e => e.LabelName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Tasks");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.TaskDesc)
                .HasMaxLength(180)
                .IsUnicode(false);
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Label).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.LabelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Tasks");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
