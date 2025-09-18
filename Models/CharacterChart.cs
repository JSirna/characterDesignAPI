using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace characterDesignAPI.Models
{
    public class CharacterChart
    {
        [Key] //denote primary key
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public Guid CharacterId { get; set; }// = Guid.NewGuid();
        public string? FullName { get; set; }
        public string? ReasonName { get; set; }
        public string? Nickname { get; set; }
        public string? ReasonNickname { get; set; }
        public string? Birthdate { get; set; }
        public int? Age { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore]
        public DateTime DateCreated { get; set; } //= DateTime.Now;

    }
}
