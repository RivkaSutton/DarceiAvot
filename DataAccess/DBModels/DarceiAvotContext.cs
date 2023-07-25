using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DBModels
{
    public partial class DarceiAvotContext : DbContext
    {
        public DarceiAvotContext()
        {
        }

        public DarceiAvotContext(DbContextOptions<DarceiAvotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<SeminarDetail> SeminarDetails { get; set; } = null!;
        public virtual DbSet<SeminarParticipant> SeminarParticipants { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<StudentDetail> StudentDetails { get; set; } = null!;
        public virtual DbSet<StudentsDocument> StudentsDocuments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=DarceiAvot;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.HistoryId).HasColumnName("HISTORY_ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .HasColumnName("ADRESS");

                entity.Property(e => e.ArmiUnit)
                    .HasMaxLength(50)
                    .HasColumnName("ARMI_UNIT");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EntranceDate)
                    .HasColumnType("date")
                    .HasColumnName("ENTRANCE_DATE");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.HomeStatus)
                    .HasMaxLength(50)
                    .HasColumnName("HOME_STATUS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Picture)
                    .HasMaxLength(50)
                    .HasColumnName("PICTURE");

                entity.Property(e => e.Profession)
                    .HasMaxLength(50)
                    .HasColumnName("PROFESSION");

                entity.Property(e => e.School)
                    .HasMaxLength(50)
                    .HasColumnName("SCHOOL");

                entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .HasColumnName("STUDENT_ID");

                entity.Property(e => e.WantChavruta).HasColumnName("WANT_CHAVRUTA");

                entity.Property(e => e.WasInSeminar).HasColumnName("WAS_IN_SEMINAR");

                entity.Property(e => e.WifeEmail)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_EMAIL");

                entity.Property(e => e.WifeLastName)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_LAST_NAME");

                entity.Property(e => e.WifeLearningPlace)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_LEARNING_PLACE");

                entity.Property(e => e.WifeName)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_NAME");

                entity.Property(e => e.WifePhone)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_PHONE");

                entity.Property(e => e.ZipCode).HasColumnName("ZIP_CODE");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_Status");
            });

            modelBuilder.Entity<SeminarDetail>(entity =>
            {
                entity.HasKey(e => e.SeminarId);

                entity.Property(e => e.SeminarId).HasColumnName("SEMINAR_ID");

                entity.Property(e => e.Crowed)
                    .HasMaxLength(50)
                    .HasColumnName("CROWED");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Lectures)
                    .HasMaxLength(50)
                    .HasColumnName("LECTURES");

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .HasColumnName("PLACE");

                entity.Property(e => e.Program)
                    .HasMaxLength(100)
                    .HasColumnName("PROGRAM");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<SeminarParticipant>(entity =>
            {
                entity.HasKey(e => e.ParticipantId);

                entity.Property(e => e.ParticipantId).HasColumnName("PARTICIPANT_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.SeminarId).HasColumnName("SEMINAR_ID");

                entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK_StudentDetails_1");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .HasColumnName("STUDENT_ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .HasColumnName("ADRESS");

                entity.Property(e => e.ArmiUnit)
                    .HasMaxLength(50)
                    .HasColumnName("ARMI_UNIT");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EntranceDate)
                    .HasColumnType("date")
                    .HasColumnName("ENTRANCE_DATE");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.HomeStatus)
                    .HasMaxLength(50)
                    .HasColumnName("HOME_STATUS");

                entity.Property(e => e.IdCardAttachment)
                    .HasMaxLength(50)
                    .HasColumnName("ID_CARD_ATTACHMENT");

                entity.Property(e => e.IdCardBack)
                    .HasMaxLength(50)
                    .HasColumnName("ID_CARD_BACK");

                entity.Property(e => e.IdCardFront)
                    .HasMaxLength(50)
                    .HasColumnName("ID_CARD_FRONT");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Picture)
                    .HasMaxLength(50)
                    .HasColumnName("PICTURE");

                entity.Property(e => e.Profession)
                    .HasMaxLength(50)
                    .HasColumnName("PROFESSION");

                entity.Property(e => e.School)
                    .HasMaxLength(50)
                    .HasColumnName("SCHOOL");

                entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

                entity.Property(e => e.WantChavruta).HasColumnName("WANT_CHAVRUTA");

                entity.Property(e => e.WasInSeminar).HasColumnName("WAS_IN_SEMINAR");

                entity.Property(e => e.WifeEmail)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_EMAIL");

                entity.Property(e => e.WifeLastName)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_LAST_NAME");

                entity.Property(e => e.WifeLearningPlace)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_LEARNING_PLACE");

                entity.Property(e => e.WifeName)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_NAME");

                entity.Property(e => e.WifePhone)
                    .HasMaxLength(50)
                    .HasColumnName("WIFE_PHONE");

                entity.Property(e => e.ZipCode).HasColumnName("ZIP_CODE");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDetails_Status");
            });

            modelBuilder.Entity<StudentsDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("StudentsDocument");

                entity.Property(e => e.DocumentId).HasColumnName("DOCUMENT_ID");

                entity.Property(e => e.Image).HasColumnName("IMAGE");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .HasColumnName("STUDENT_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsDocuments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsDocument_StudentsDocument");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
