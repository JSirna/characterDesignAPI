using System.ComponentModel.DataAnnotations;

namespace characterDesignAPI
{
    public class CharacterChart
    {
        [Key]
        public required string CharacterId { get; set; }
        public string? FullName { get; set; }
        public string? ReasonName { get; set; }
        public string? Nickname { get; set; }
        public string? ReasonNickname { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? Age { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
