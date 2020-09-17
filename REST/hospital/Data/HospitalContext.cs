using Microsoft.EntityFrameworkCore;
using hospital.Models;

namespace hospital.Data
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> opt) : base(opt)
        {

        }

        public virtual DbSet<AffiliatedWith> AffiliatedWith { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Medication> Medication { get; set; }
        public virtual DbSet<Nurse> Nurse { get; set; }
        public virtual DbSet<Nurses> Nurses { get; set; }
        public virtual DbSet<OnCall> OnCall { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Physician> Physician { get; set; }
        public virtual DbSet<Prescribes> Prescribes { get; set; }
        public virtual DbSet<Procedures> Procedures { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Stay> Stay { get; set; }
        public virtual DbSet<TrainedIn> TrainedIn { get; set; }
        public virtual DbSet<Undergoes> Undergoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=hospital_rnwa;uid=root;pwd=+venY/6%+^PW", x => x.ServerVersion("10.3.23-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffiliatedWith>(entity =>
            {
                entity.HasKey(e => new { e.Physician, e.Department })
                    .HasName("PRIMARY");

                entity.ToTable("Affiliated_With");

                entity.HasIndex(e => e.Department)
                    .HasName("fk_Affiliated_With_Department_DepartmentID");

                entity.Property(e => e.Physician).HasColumnType("int(11)");

                entity.Property(e => e.Department).HasColumnType("int(11)");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.AffiliatedWith)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Affiliated_With_Department_DepartmentID");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.AffiliatedWith)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Affiliated_With_Physician_EmployeeID");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasIndex(e => e.Patient)
                    .HasName("fk_Appointment_Patient_SSN");

                entity.HasIndex(e => e.Physician)
                    .HasName("fk_Appointment_Physician_EmployeeID");

                entity.HasIndex(e => e.PrepNurse)
                    .HasName("fk_Appointment_Nurse_EmployeeID");

                entity.Property(e => e.AppointmentId)
                    .HasColumnName("AppointmentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.ExaminationRoom)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Patient).HasColumnType("int(11)");

                entity.Property(e => e.Physician).HasColumnType("int(11)");

                entity.Property(e => e.PrepNurse).HasColumnType("int(11)");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.Patient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Appointment_Patient_SSN");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Appointment_Physician_EmployeeID");

                entity.HasOne(d => d.PrepNurseNavigation)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PrepNurse)
                    .HasConstraintName("fk_Appointment_Nurse_EmployeeID");
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.HasKey(e => new { e.BlockFloor, e.BlockCode })
                    .HasName("PRIMARY");

                entity.Property(e => e.BlockFloor).HasColumnType("int(11)");

                entity.Property(e => e.BlockCode).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.Head)
                    .HasName("fk_Department_Physician_EmployeeID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Head).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.HeadNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.Head)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Department_Physician_EmployeeID");
            });

            modelBuilder.Entity<Medication>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.Property(e => e.Code).HasColumnType("int(11)");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PRIMARY");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Nurses>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("nurses");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId1)
                    .HasColumnName("EmployeeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Registered)
                    .HasColumnName("registered")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ssn)
                    .HasColumnName("ssn")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<OnCall>(entity =>
            {
                entity.HasKey(e => new { e.Nurse, e.BlockFloor, e.BlockCode, e.OnCallStart, e.OnCallEnd })
                    .HasName("PRIMARY");

                entity.ToTable("On_Call");

                entity.HasIndex(e => new { e.BlockFloor, e.BlockCode })
                    .HasName("fk_OnCall_Block_Floor");

                entity.Property(e => e.Nurse).HasColumnType("int(11)");

                entity.Property(e => e.BlockFloor).HasColumnType("int(11)");

                entity.Property(e => e.BlockCode).HasColumnType("int(11)");

                entity.Property(e => e.OnCallStart).HasColumnType("datetime");

                entity.Property(e => e.OnCallEnd).HasColumnType("datetime");

                entity.HasOne(d => d.NurseNavigation)
                    .WithMany(p => p.OnCall)
                    .HasForeignKey(d => d.Nurse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OnCall_Nurse_EmployeeID");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.OnCall)
                    .HasForeignKey(d => new { d.BlockFloor, d.BlockCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OnCall_Block_Floor");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Pcp)
                    .HasName("fk_Patient_Physician_EmployeeID");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.InsuranceId)
                    .HasColumnName("InsuranceID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Pcp)
                    .HasColumnName("PCP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.PcpNavigation)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.Pcp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Patient_Physician_EmployeeID");
            });

            modelBuilder.Entity<Physician>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PRIMARY");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Prescribes>(entity =>
            {
                entity.HasKey(e => new { e.Physician, e.Patient, e.Medication, e.Date })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Appointment)
                    .HasName("fk_Prescribes_Appointment_AppointmentID");

                entity.HasIndex(e => e.Medication)
                    .HasName("fk_Prescribes_Medication_Code");

                entity.HasIndex(e => e.Patient)
                    .HasName("fk_Prescribes_Patient_SSN");

                entity.Property(e => e.Physician).HasColumnType("int(11)");

                entity.Property(e => e.Patient).HasColumnType("int(11)");

                entity.Property(e => e.Medication).HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Appointment).HasColumnType("int(11)");

                entity.Property(e => e.Dose)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.AppointmentNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Appointment)
                    .HasConstraintName("fk_Prescribes_Appointment_AppointmentID");

                entity.HasOne(d => d.MedicationNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Medication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Prescribes_Medication_Code");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Patient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Prescribes_Patient_SSN");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Prescribes_Physician_EmployeeID");
            });

            modelBuilder.Entity<Procedures>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.Property(e => e.Code).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomNumber)
                    .HasName("PRIMARY");

                entity.HasIndex(e => new { e.BlockFloor, e.BlockCode })
                    .HasName("fk_Room_Block_PK");

                entity.Property(e => e.RoomNumber).HasColumnType("int(11)");

                entity.Property(e => e.BlockCode).HasColumnType("int(11)");

                entity.Property(e => e.BlockFloor).HasColumnType("int(11)");

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => new { d.BlockFloor, d.BlockCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Room_Block_PK");
            });

            modelBuilder.Entity<Stay>(entity =>
            {
                entity.HasIndex(e => e.Patient)
                    .HasName("fk_Stay_Patient_SSN");

                entity.HasIndex(e => e.Room)
                    .HasName("fk_Stay_Room_Number");

                entity.Property(e => e.StayId)
                    .HasColumnName("StayID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Patient).HasColumnType("int(11)");

                entity.Property(e => e.Room).HasColumnType("int(11)");

                entity.Property(e => e.StayEnd).HasColumnType("datetime");

                entity.Property(e => e.StayStart).HasColumnType("datetime");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Stay)
                    .HasForeignKey(d => d.Patient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Stay_Patient_SSN");

                entity.HasOne(d => d.RoomNavigation)
                    .WithMany(p => p.Stay)
                    .HasForeignKey(d => d.Room)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Stay_Room_Number");
            });

            modelBuilder.Entity<TrainedIn>(entity =>
            {
                entity.HasKey(e => new { e.Physician, e.Treatment })
                    .HasName("PRIMARY");

                entity.ToTable("Trained_In");

                entity.HasIndex(e => e.Treatment)
                    .HasName("fk_Trained_In_Procedures_Code");

                entity.Property(e => e.Physician).HasColumnType("int(11)");

                entity.Property(e => e.Treatment).HasColumnType("int(11)");

                entity.Property(e => e.CertificationDate).HasColumnType("datetime");

                entity.Property(e => e.CertificationExpires).HasColumnType("datetime");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.TrainedIn)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Trained_In_Physician_EmployeeID");

                entity.HasOne(d => d.TreatmentNavigation)
                    .WithMany(p => p.TrainedIn)
                    .HasForeignKey(d => d.Treatment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Trained_In_Procedures_Code");
            });

            modelBuilder.Entity<Undergoes>(entity =>
            {
                entity.HasKey(e => new { e.Patient, e.Procedures, e.Stay, e.DateUndergoes })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AssistingNurse)
                    .HasName("fk_Undergoes_Nurse_EmployeeID");

                entity.HasIndex(e => e.Physician)
                    .HasName("fk_Undergoes_Physician_EmployeeID");

                entity.HasIndex(e => e.Procedures)
                    .HasName("fk_Undergoes_Procedures_Code");

                entity.HasIndex(e => e.Stay)
                    .HasName("fk_Undergoes_Stay_StayID");

                entity.Property(e => e.Patient).HasColumnType("int(11)");

                entity.Property(e => e.Procedures).HasColumnType("int(11)");

                entity.Property(e => e.Stay).HasColumnType("int(11)");

                entity.Property(e => e.DateUndergoes).HasColumnType("datetime");

                entity.Property(e => e.AssistingNurse).HasColumnType("int(11)");

                entity.Property(e => e.Physician).HasColumnType("int(11)");

                entity.HasOne(d => d.AssistingNurseNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.AssistingNurse)
                    .HasConstraintName("fk_Undergoes_Nurse_EmployeeID");

                entity.HasOne(d => d.PatientNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Patient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Undergoes_Patient_SSN");

                entity.HasOne(d => d.PhysicianNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Physician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Undergoes_Physician_EmployeeID");

                entity.HasOne(d => d.ProceduresNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Procedures)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Undergoes_Procedures_Code");

                entity.HasOne(d => d.StayNavigation)
                    .WithMany(p => p.Undergoes)
                    .HasForeignKey(d => d.Stay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Undergoes_Stay_StayID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}