using Microsoft.EntityFrameworkCore;

namespace characterDesignAPI
{
    public class CharacterDesignFormContext : DbContext
    {
        public CharacterDesignFormContext(DbContextOptions<CharacterDesignFormContext> options) : base(options)
        {
        }
        public DbSet<CharacterChart> Characters { get; set; }
        public DbSet<CharacterFamily> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Character Chart Configuration
            modelBuilder.Entity<CharacterChart>().ToTable("character_chart");
            // Configure the primary key for CharacterModel
            modelBuilder.Entity<CharacterChart>(entity =>
            {
                entity.Property(c => c.CharacterId)
                    .IsRequired()
                    .HasMaxLength(50) // Id is a GUID
                    .HasColumnName("character_id");
                entity.HasKey(c => c.CharacterId); // Set CharacterId as the primary key
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
            #endregion

            #region Character Family Configuration
            modelBuilder.Entity<CharacterFamily>().ToTable("character_family");
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.FamilyId)
                    .IsRequired()
                    .HasMaxLength(50) // Id is a GUID
                    .HasColumnName("family_id");
                entity.HasKey(c => c.FamilyId); // Set CharacterId as the primary key
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.CharacterId)
                    .IsRequired()
                    .HasColumnName("character_id_fk");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.Mother)
                    .HasMaxLength(50)
                        .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("mother");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.RelationshipWithMother)
                    .HasMaxLength(220)
                            .HasConversion(
                            v => v.ToString(), // Convert to string for storage
                            v => v // Convert back to string when reading
                        )
                    .HasColumnName("relationship_with_mother");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.Father)
                    .HasMaxLength(50)
                        .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("father");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.RelationshipWithFather)
                    .HasMaxLength(220)
                            .HasConversion(
                            v => v.ToString(), // Convert to string for storage
                            v => v // Convert back to string when reading
                        )
                    .HasColumnName("relationship_with_father");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.Siblings)
                    .HasMaxLength(50)
                        .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("siblings");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.RelationshipWithSiblings)
                    .HasMaxLength(220)
                            .HasConversion(
                            v => v.ToString(), // Convert to string for storage
                            v => v // Convert back to string when reading
                        )
                    .HasColumnName("relationship_with_siblings");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.Spouse)
                    .HasMaxLength(50)
                        .HasConversion(
                        v => v.ToString(), // Convert to string for storage
                        v => v // Convert back to string when reading
                    )
                    .HasColumnName("spouse");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.RelationshipWithSpouse)
                    .HasMaxLength(220)
                            .HasConversion(
                            v => v.ToString(), // Convert to string for storage
                            v => v // Convert back to string when reading
                        )
                    .HasColumnName("relationship_with_spouse");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.Children)
                    .HasMaxLength(50)
                            .HasConversion(
                            v => v.ToString(), // Convert to string for storage
                            v => v // Convert back to string when reading
                        )
                    .HasColumnName("children");
            }
            );
            modelBuilder.Entity<CharacterFamily>(entity =>
            {
                entity.Property(c => c.OtherFamily)
                    .HasMaxLength(50)
                            .HasConversion(
                            v => v.ToString(), // Convert to string for storage
                            v => v // Convert back to string when reading
                        )
                    .HasColumnName("other_family");
            }
            );
            #endregion

        }
    }
}
