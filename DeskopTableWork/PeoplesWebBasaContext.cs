using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DeskopTableWork
{
    public partial class PeoplesWebBasaContext : DbContext
    {
        public PeoplesWebBasaContext()
        {
        }

        public PeoplesWebBasaContext(DbContextOptions<PeoplesWebBasaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessRight> AccessRights { get; set; }
        public virtual DbSet<PeopleWork> PeopleWorks { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-G4B9IB0;DataBase=PeoplesWebBasa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AccessRight>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.NameAccess)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PeopleWork>(entity =>
            {
                entity.HasKey(e => e.Idwork);

                entity.ToTable("PeopleWork");

                entity.Property(e => e.Idwork)
                    .ValueGeneratedNever()
                    .HasColumnName("IDWork");

                entity.Property(e => e.IdaccessRights).HasColumnName("IDAccessRights");

                entity.Property(e => e.NameWork)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordWork)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdaccessRightsNavigation)
                    .WithMany(p => p.PeopleWorks)
                    .HasForeignKey(d => d.IdaccessRights)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleWork_AccessRights");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
