using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TeleAtlanticoClients_API.Models
{
    public partial class ProyectoB61309_B74849Context : DbContext
    {
        public ProyectoB61309_B74849Context()
        {
        }

        public ProyectoB61309_B74849Context(DbContextOptions<ProyectoB61309_B74849Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<UsersService> UsersServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DATA SOURCE=LOCALHOST\\SQLEXPRESS;DATABASE=TELE_ATLANTICO_CLIENT;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.Firstsurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_SURNAME");

                entity.Property(e => e.Fulladdress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULL_ADDRESS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Registrationdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REGISTRATION_DATE");

                entity.Property(e => e.Secondcontact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SECON_CONTACT");

                entity.Property(e => e.Secondsurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SECOND_SURNAME");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COMMENT");

                entity.Property(e => e.CommentTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("COMMENT_TIMESTAMP");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IssueNumber).HasColumnName("ISSUE_NUMBER");

                entity.Property(e => e.SendingPersonName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SENDING_PERSON_NAME");

                entity.HasOne(d => d.IssueNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IssueNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMMENT__ISSUE_N__2E1BDC42");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.IssueNumber)
                    .HasName("PK__ISSUE__5A5E16A08F2DA9D9");

                entity.ToTable("ISSUE");

                entity.Property(e => e.IssueNumber).HasColumnName("ISSUE_NUMBER");

                entity.Property(e => e.ClientFullname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_FULLNAME");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.RegisterTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("REGISTER_TIMESTAMP");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SupporterName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SUPPORTER_NAME");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ISSUE__CLIENT_ID__2B3F6F97");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServiceCode)
                    .HasName("PK__SERVICE__4F8A9EAEC23BF090");

                entity.ToTable("SERVICE");

                entity.Property(e => e.ServiceCode).HasColumnName("SERVICE_CODE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<UsersService>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USERS_SERVICES");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.ContractDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTRACT_DATE");

                entity.Property(e => e.ServiceCode).HasColumnName("SERVICE_CODE");

                entity.HasOne(d => d.Client)
                    .WithMany()
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USERS_SER__CLIEN__276EDEB3");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USERS_SER__SERVI__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
