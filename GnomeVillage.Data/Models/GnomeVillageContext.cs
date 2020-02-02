using Microsoft.EntityFrameworkCore;

namespace GnomeVillage.Data.Models
{
   public partial class GnomeVillageContext : DbContext
    {
        public GnomeVillageContext()
        {
        }

        public GnomeVillageContext(DbContextOptions<GnomeVillageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Habitant> Habitant { get; set; }
        public virtual DbSet<HabitantFriends> HabitantFriends { get; set; }
        public virtual DbSet<HabitantProfessions> HabitantProfessions { get; set; }
        public virtual DbSet<HairColor> HairColor { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habitant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HairColorId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Thumbnail)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsFixedLength();

                entity.HasOne(d => d.HairColor)
                    .WithMany(p => p.Habitant)
                    .HasForeignKey(d => d.HairColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Habitant_HairColors");
            });

            modelBuilder.Entity<HabitantFriends>(entity =>
            {
                entity.HasIndex(e => new { e.HabitantId, e.FriendId })
                    .HasName("IX_HabitantFriends")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.HabitantFriendsFriend)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HabitantFriends_Habitant1");

                entity.HasOne(d => d.Habitant)
                    .WithMany(p => p.HabitantFriendsHabitant)
                    .HasForeignKey(d => d.HabitantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HabitantFriends_Habitant");
            });

            modelBuilder.Entity<HabitantProfessions>(entity =>
            {
                entity.HasIndex(e => new { e.HabitantId, e.ProfessionId })
                    .HasName("IX_HabitantProfessions")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProfessionId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.HasOne(d => d.Habitant)
                    .WithMany(p => p.HabitantProfessions)
                    .HasForeignKey(d => d.HabitantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HabitantProfessions_Habitant");

                entity.HasOne(d => d.Profession)
                    .WithMany(p => p.HabitantProfessions)
                    .HasForeignKey(d => d.ProfessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HabitantProfessions_Professions");
            });

            modelBuilder.Entity<HairColor>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK_HairColors");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK_Professions");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsFixedLength();
            });

        }
    }
}
