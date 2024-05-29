using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CabBookingPortal.Models;

public partial class CabBookingPortalContext : DbContext
{
    public CabBookingPortalContext()
    {
    }

    public CabBookingPortalContext(DbContextOptions<CabBookingPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CostCenter> CostCenters { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleStatus> VehicleStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CabBookingPortal;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CostCenter>(entity =>
        {
            entity.HasKey(e => e.CostCode).HasName("PK__CostCent__7A8D3137369139FD");

            entity.ToTable("CostCenter");

            entity.Property(e => e.CostCode)
                .ValueGeneratedNever()
                .HasColumnName("cost_code");
            entity.Property(e => e.CenterName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("center_name");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Driver__A411C5BD6A133D88");

            entity.ToTable("Driver");

            entity.Property(e => e.DriverId)
                .ValueGeneratedNever()
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverBloodgrp)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("driver_bloodgrp");
            entity.Property(e => e.DriverGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("driver_gender");
            entity.Property(e => e.DriverName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("driver_name");
            entity.Property(e => e.DriverPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("driver_phone");
            entity.Property(e => e.DriverStatus).HasColumnName("driver_status");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Driver__vehicle___49C3F6B7");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__1299A861015EB47C");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("emp_id");
            entity.Property(e => e.CostCode).HasColumnName("cost_code");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_address");
            entity.Property(e => e.EmpStatus).HasColumnName("emp_status");
            entity.Property(e => e.EmpType).HasColumnName("emp_type");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Pfp)
                .HasColumnType("image")
                .HasColumnName("pfp");
            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.CostCodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CostCode)
                .HasConstraintName("FK__Employee__cost_c__3F466844");

            entity.HasOne(d => d.EmpTypeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmpType)
                .HasConstraintName("FK__Employee__emp_ty__412EB0B6");

            entity.HasOne(d => d.Shift).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK__Employee__shift___403A8C7D");
        });

        modelBuilder.Entity<EmployeeType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Employee__2C00059827F659F4");

            entity.ToTable("EmployeeType");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.ReqId).HasName("PK__Request__1513A6FB01E20C51");

            entity.ToTable("Request");

            entity.Property(e => e.ReqId).HasColumnName("req_id");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.CostCode).HasColumnName("cost_code");
            entity.Property(e => e.CreationDate).HasColumnName("creation_date");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.InputAddress)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("input_address");
            entity.Property(e => e.IsDrop).HasColumnName("is_drop");
            entity.Property(e => e.IsPickup).HasColumnName("is_pickup");
            entity.Property(e => e.ReqStatus).HasColumnName("req_status");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.CostCodeNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.CostCode)
                .HasConstraintName("FK__Request__cost_co__5165187F");

            entity.HasOne(d => d.Emp).WithMany(p => p.Requests)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__Request__emp_id__5070F446");

            entity.HasOne(d => d.ReqStatusNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ReqStatus)
                .HasConstraintName("FK__Request__req_sta__4F7CD00D");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Requests)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Request__vehicle__52593CB8");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__RequestS__3683B531064E9B36");

            entity.ToTable("RequestStatus");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PK__Route__28F706FE1C79C932");

            entity.ToTable("Route");

            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.RouteName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("route_name");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shift__7B26722009533857");

            entity.ToTable("Shift");

            entity.Property(e => e.ShiftId)
                .ValueGeneratedNever()
                .HasColumnName("shift_id");
            entity.Property(e => e.ShiftIn).HasColumnName("shift_in");
            entity.Property(e => e.ShiftName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("shift_name");
            entity.Property(e => e.ShiftOut).HasColumnName("shift_out");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__Vehicle__F2947BC1385B2533");

            entity.ToTable("Vehicle");

            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.MaxCapacity).HasColumnName("max_capacity");
            entity.Property(e => e.RouteName).HasColumnName("route_name");
            entity.Property(e => e.ShiftId).HasColumnName("shift_id");
            entity.Property(e => e.VehicleNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("vehicle_number");

            entity.HasOne(d => d.RouteNameNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.RouteName)
                .HasConstraintName("FK__Vehicle__route_n__46E78A0C");

            entity.HasOne(d => d.Shift).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK__Vehicle__shift_i__45F365D3");
        });

        modelBuilder.Entity<VehicleStatus>(entity =>
        {
            entity.HasKey(e => e.VehicleId).HasName("PK__VehicleS__F2947BC1FE32F25F");

            entity.ToTable("VehicleStatus");

            entity.Property(e => e.VehicleId)
                .ValueGeneratedNever()
                .HasColumnName("vehicle_id");
            entity.Property(e => e.BookingDate).HasColumnName("booking_date");
            entity.Property(e => e.IncomingApproved).HasColumnName("incoming_approved");
            entity.Property(e => e.OutgoingApproved).HasColumnName("outgoing_approved");

            entity.HasOne(d => d.Vehicle).WithOne(p => p.VehicleStatus)
                .HasForeignKey<VehicleStatus>(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VehicleSt__vehic__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
