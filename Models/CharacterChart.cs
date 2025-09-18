using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace characterDesignAPI.Models
{
    public class CharacterChart
    {
        [Key] //denote primary key
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CharacterId { get; set; }// = Guid.NewGuid();
        public string? FullName { get; set; }
        public string? ReasonName { get; set; }
        public string? Nickname { get; set; }
        public string? ReasonNickname { get; set; }
        public string? Birthdate { get; set; }
        public int? Age { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // why does using identity here work, and is there a cleaner/more robust way to insert current datetime?
        public DateTime DateCreated { get; set; } = DateTime.Now; // for global applications, datetime should probably be utc format, not localized

    }
}
