using System;
using System.Collections.Generic;
using MediConnectSuiteAPI;
using Microsoft.EntityFrameworkCore;

namespace IServices.Models;

public partial class MediConnectSuiteApiContext : DbContext
{
    private readonly IEncryptionProvider2 _provider;
    public MediConnectSuiteApiContext()
    {
    }

    public MediConnectSuiteApiContext(DbContextOptions<MediConnectSuiteApiContext> options, IEncryptionProvider2 provider)
        : base(options)
    {
        _provider = provider;
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<DiagnoseRecord> DiagnoseRecords { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<LinkExpiry> LinkExpiries { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<RecordPermission> RecordPermissions { get; set; }

    public virtual DbSet<Vital> Vitals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=MediConnectSuiteAPI; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07A4A7F281");

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__Docto__5629CD9C");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__571DF1D5");
        });

        modelBuilder.Entity<DiagnoseRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diagnose__3214EC07593F2FBF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Diagnosis).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Treatment).HasMaxLength(100);

            entity.HasOne(d => d.Doctor).WithMany(p => p.DiagnoseRecords)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__DiagnoseR__Docto__4222D4EF");

            entity.HasOne(d => d.Patient).WithMany(p => p.DiagnoseRecords)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__DiagnoseR__Patie__412EB0B6");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctor__2DC00EBFBB9A1D46");

            entity.ToTable("Doctor");

            entity.Property(e => e.DoctorId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<LinkExpiry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LinkExpi__3214EC07809D96BB");

            entity.ToTable("LinkExpiry");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(255);

            entity.HasOne(d => d.Doctor).WithMany(p => p.LinkExpiries)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__LinkExpir__Docto__4F7CD00D");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC34674D6FE67");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(20);
        });

        modelBuilder.Entity<RecordPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RecordPe__3214EC0765E23C66");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.DiagnoseRecords).WithMany(p => p.RecordPermissions)
                .HasForeignKey(d => d.DiagnoseRecordsId)
                .HasConstraintName("FK__RecordPer__Diagn__5BE2A6F2");

            entity.HasOne(d => d.LinkExpiry).WithMany(p => p.RecordPermissions)
                .HasForeignKey(d => d.LinkExpiryId)
                .HasConstraintName("FK__RecordPer__LinkE__534D60F1");
        });

        modelBuilder.Entity<Vital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vitals__3214EC07CA6BBCAB");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BloodPressure).HasMaxLength(20);
            entity.Property(e => e.BreathingRate).HasMaxLength(10);
            entity.Property(e => e.DocumentType).HasMaxLength(100);
            entity.Property(e => e.HeartRate).HasMaxLength(10);
            entity.Property(e => e.HospitalName).HasMaxLength(100);
            entity.Property(e => e.SpO2).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Temperature).HasMaxLength(20);
            entity.Property(e => e.UploadedBy).HasMaxLength(100);

            entity.HasOne(d => d.Patient).WithMany(p => p.Vitals)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Vitals__PatientI__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
