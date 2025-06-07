using Microsoft.EntityFrameworkCore;

namespace characterDesignAPI
{
    public class CharacterDesignFormContext : DbContext
    {
        public CharacterDesignFormContext(DbContextOptions<CharacterDesignFormContext> options) : base(options)
        {
        }
        public DbSet<CharacterChart> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterChart>().ToTable("character_chart");
            // Configure the primary key for CharacterModel
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.CharacterId)
                    .IsRequired()
                    .HasMaxLength(50) // Id is a GUID
                    //.HasConversion(
                    //    v => v.ToString(), // Convert to string for storage
                    //    v => v // Convert back to string when reading
                    //)
                    .HasColumnName("character_id");
            }
            );
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.FullName)
                    .HasMaxLength(50)
                    .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("full_name");
            }
            );
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.ReasonName)
                    .HasMaxLength(220)
                    .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("reason_name");
            }
            );
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.Nickname)
                    .HasMaxLength(50)
                    .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("nickname");
            }
            );
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.ReasonNickname)
                    .HasMaxLength(220)
                    .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("reason_nickname");
            }
            );
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.Birthdate)
                .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                .HasColumnName("birthdate");
            }
            );
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.Age)
                    .HasColumnName("age");
            }
            );
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime2(0)");
            }
            );

            
        }
    }
}
