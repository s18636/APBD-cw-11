using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APBD_cw_11.Models
{
    public class DoctorsDbContext : DbContext
    {

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        public DoctorsDbContext(DbContextOptions<DoctorsDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18747;Integrated Security=True");
                              
            }
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Jakub", LastName = "tymanski", Email = "tymek@gamil.com" });
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Zuzanna", LastName = "Krecipieta", Email = "krecik@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Sebastian", LastName = "Blokowski", Email = "seba@gmail.pl" });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("Doctor_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(doctors);
            });

            List<Medicament> medicaments = new List<Medicament>();
            medicaments.Add(new Medicament { IdMedicament = 1, Name = "rutinosal", Description = "udraznia drogi oddechowe", Type = "spray" });
            medicaments.Add(new Medicament { IdMedicament = 2, Name = "pantesol", Description = "na bol piety", Type = "masc" });
            medicaments.Add(new Medicament { IdMedicament = 3, Name = "pandemics", Description = "zabija korona wirusa", Type = "dozylny" });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament)
                    .HasName("Medicament_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(medicaments);
            });

            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient { FirstName = "tymoteusz", LastName = "Rybiak", IdPatient = 1, Birthdate = DateTime.Parse("8-12-1997") });
            patients.Add(new Patient { FirstName = "Karolina", LastName = "Koterska", IdPatient = 2, Birthdate = DateTime.Parse("11-09-1972") });
            patients.Add(new Patient { FirstName = "Aleksandra", LastName = "Samochodowa", IdPatient = 3, Birthdate = DateTime.Parse("1-01-2004") });


            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(patients);
            });

            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(90), IdPatient = 2, IdDoctor = 3 });
            prescriptions.Add(new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(90), IdPatient = 1, IdDoctor = 2 });
            prescriptions.Add(new Prescription { IdPrescription = 3, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(90), IdPatient = 3, IdDoctor = 1 });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription)
                    .HasName("Prescription_pk");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(prescriptions);

            });

            List<PrescriptionMedicament> prescriptionMecidaments = new List<PrescriptionMedicament>();
            prescriptionMecidaments.Add(new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 7, Details = "dwa razy dziennie" });
            prescriptionMecidaments.Add(new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 10, Details = "raz dziennie przed posilkiem" });
            prescriptionMecidaments.Add(new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 3, Dose = 20, Details = "raz dziennie wieczorem przed zasnieciem" });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription })
                    .HasName("Prescription_Medicament_pk");

                entity.ToTable("Prescription_Medicament");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Medicament)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull);



                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

        }
    }
}
