using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeMetric> EmployeeMetrics { get; set; }

    public virtual DbSet<Metric> Metrics { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionMetric> PositionMetrics { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("citext")
            .HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => e.Login, "employees_login_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_position_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_role_id_fkey");
        });

        modelBuilder.Entity<EmployeeMetric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_metrics_pkey");

            entity.ToTable("employee_metrics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AchievedAt).HasColumnName("achieved_at");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.MetricId).HasColumnName("metric_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeMetrics)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_metrics_employee_id_fkey");

            entity.HasOne(d => d.Metric).WithMany(p => p.EmployeeMetrics)
                .HasForeignKey(d => d.MetricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_metrics_metric_id_fkey");
        });

        modelBuilder.Entity<Metric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("metrics_pkey");

            entity.ToTable("metrics");

            entity.HasIndex(e => e.Name, "metrics_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsCommon).HasColumnName("is_common");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Weight)
                .HasPrecision(6, 2)
                .HasColumnName("weight");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.HasIndex(e => e.Name, "positions_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PositionMetric>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("position_metrics_pkey");

            entity.ToTable("position_metrics");

            entity.HasIndex(e => new { e.PositionId, e.MetricId }, "position_metrics_position_id_metric_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MetricId).HasColumnName("metric_id");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Metric).WithMany(p => p.PositionMetrics)
                .HasForeignKey(d => d.MetricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("position_metrics_metric_id_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.PositionMetrics)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("position_metrics_position_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Name, "roles_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
