using Microsoft.EntityFrameworkCore;

namespace characterDesignAPI
{
    public class CharacterDesignFormContext : DbContext
    {
        public CharacterDesignFormContext(DbContextOptions<CharacterDesignFormContext> options) : base(options)
        {
        }
        public DbSet<CharacterChart> CharacterChart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the primary key for CharacterModel
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.CharacterId)
                    .IsRequired()
                    .HasMaxLength(36) // Id is a GUID
                    .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("character_id");
            }
            );
            //    .HasColumnName("character_id")  
            //    .HasKey(c => c.Id);
            //// Configure other properties if needed
            //modelBuilder.Entity<CharacterModel>()
            //    .Property(c => c.FullName)
            //    .HasMaxLength(50);
            //modelBuilder.Entity<CharacterModel>()
            //    .Property(c => c.Nickname)
            //    .HasMaxLength(50);
            //modelBuilder.Entity<CharacterModel>()
            //    .Property(c => c.ReasonName)
            //    .HasMaxLength(220);
            //modelBuilder.Entity<CharacterModel>()
            //    .Property(c => c.ReasonNickname)
            //    .HasMaxLength(220);
            //modelBuilder.Entity<CharacterModel>()
            //    .Property(c => c.BirthDate)
            //    .HasColumnType("date");
            //modelBuilder.Entity<CharacterModel>()
            //    .Property(c => c.DateCreated)
            //    .HasColumnType("datetime");
            // Add more configurations as necessary
        }
    }
}
